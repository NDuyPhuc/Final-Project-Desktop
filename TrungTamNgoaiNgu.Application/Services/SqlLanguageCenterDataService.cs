using System.Data;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using TrungTamNgoaiNgu.Application.Configuration;
using TrungTamNgoaiNgu.Application.Contracts;
using TrungTamNgoaiNgu.Application.Data;
using TrungTamNgoaiNgu.Application.Infrastructure;
using TrungTamNgoaiNgu.Application.Localization;
using TrungTamNgoaiNgu.Application.Models;
using TrungTamNgoaiNgu.Application.Repositories;
using TrungTamNgoaiNgu.Application.Security;
using TrungTamNgoaiNgu.Domain.Entities;
using TrungTamNgoaiNgu.Domain.Enums;

namespace TrungTamNgoaiNgu.Application.Services;

public class SqlLanguageCenterDataService : ILanguageCenterDataService
{
    private readonly DbContextOptions<LanguageCenterDbContext> _options;
    private readonly IAccountRepository _accountRepository;
    private readonly CultureInfo _culture = CultureInfo.GetCultureInfo("vi-VN");

    public SqlLanguageCenterDataService(string? connectionString = null)
    {
        var databaseOptions = LanguageCenterDatabaseConfiguration.Load();
        _options = new DbContextOptionsBuilder<LanguageCenterDbContext>()
            .UseSqlServer(
                string.IsNullOrWhiteSpace(connectionString) ? databaseOptions.ConnectionString : connectionString,
                builder =>
                {
                    builder.EnableRetryOnFailure();
                    if (databaseOptions.CommandTimeoutSeconds > 0)
                    {
                        builder.CommandTimeout(databaseOptions.CommandTimeoutSeconds);
                    }
                })
            .Options;
        _accountRepository = new SqlAccountRepository(_options);
    }

    public void EnsureDatabaseReady()
    {
        try
        {
            if (!_accountRepository.CanConnect())
            {
                throw new InvalidOperationException("Khong the ket noi toi co so du lieu SQL Server.");
            }

            using var context = CreateContext();
            if (ShouldSeedSampleData(context))
            {
                SeedData(context);
            }
        }
        catch (Exception exception)
        {
            ErrorLogger.Log(exception, "EnsureDatabaseReady");
            throw;
        }
    }

    public AccountEntity? Authenticate(string username, string password)
    {
        try
        {
            var account = _accountRepository.FindActiveByUsername(username);

            return account is not null && PasswordHasher.Verify(password, account.PasswordHash)
                ? account
                : null;
        }
        catch (Exception exception)
        {
            ErrorLogger.Log(exception, "Authenticate");
            throw;
        }
    }

    public string GetNextAccountId()
    {
        return _accountRepository.GetNextId();
    }

    public string GetNextStudentId()
    {
        using var context = CreateContext();
        return GetNextCode(context.Students.Select(x => x.Id).ToList(), "HV");
    }

    public string GetNextTeacherId()
    {
        using var context = CreateContext();
        return GetNextCode(context.Teachers.Select(x => x.Id).ToList(), "GV");
    }

    public string GetNextCourseId()
    {
        using var context = CreateContext();
        return GetNextCode(context.Courses.Select(x => x.Id).ToList(), "KH");
    }

    public string GetNextClassId()
    {
        using var context = CreateContext();
        return GetNextCode(context.Classes.Select(x => x.Id).ToList(), "LP");
    }

    public string GetNextEnrollmentId()
    {
        using var context = CreateContext();
        return GetNextCode(context.Enrollments.Select(x => x.Id).ToList(), "GD");
    }

    public string GetNextReceiptId()
    {
        using var context = CreateContext();
        return GetNextCode(context.Receipts.Select(x => x.Id).ToList(), "PT");
    }

    public IReadOnlyList<AccountEntity> GetAccounts()
    {
        return _accountRepository.GetAccounts();
    }

    public AccountEntity SaveAccount(AccountEntity account)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(account.PasswordHash))
            {
                account.PasswordHash = PasswordHasher.Hash("123456");
            }

            return _accountRepository.Save(account);
        }
        catch (Exception exception)
        {
            ErrorLogger.Log(exception, "SaveAccount");
            throw;
        }
    }

    public void ToggleAccountStatus(string accountId)
    {
        try
        {
            _accountRepository.ToggleStatus(accountId);
        }
        catch (Exception exception)
        {
            ErrorLogger.Log(exception, "ToggleAccountStatus");
            throw;
        }
    }

    public void ResetAccountPassword(string accountId, string newPassword)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                throw new InvalidOperationException("Mat khau moi khong duoc de trong.");
            }

            _accountRepository.ResetPassword(accountId, PasswordHasher.Hash(newPassword.Trim()));
        }
        catch (Exception exception)
        {
            ErrorLogger.Log(exception, "ResetAccountPassword");
            throw;
        }
    }

    public DataTable GetAccessMatrix()
    {
        var table = CreateTable("Linh vuc chuc nang", "Admin", "Staff", "Teacher", "Pham vi");
        table.Rows.Add("Quan ly tai khoan", "Co", "Khong", "Khong", "He thong");
        table.Rows.Add("Thu hoc phi va bien lai", "Xem", "Co", "Khong", "Tai chinh");
        table.Rows.Add("Ghi danh va xep lop", "Xem", "Co", "Khong", "Van hanh");
        table.Rows.Add("Diem danh", "Xem", "Xem", "Co", "Giang day");
        table.Rows.Add("Nhap diem", "Xem", "Khong", "Co", "Giang day");
        table.Rows.Add("Bao cao doanh thu", "Co", "Xem", "Khong", "Bao cao");
        return table;
    }

    public DataTable GetAdminWarnings()
    {
        using var context = CreateContext();
        var table = CreateTable("Muc do", "Noi dung", "Han xu ly");

        var nearlyFull = context.Classes
            .Include(x => x.Enrollments)
            .Where(x => !x.IsDeleted)
            .AsEnumerable()
            .Count(x => GetActiveEnrollmentCount(x) >= Math.Max(1, x.MaxStudents - 1));
        var debtCount = BuildDebtRows(context).Count(x => x.Outstanding > 0);
        var lockedCount = context.Accounts.Count(x => !x.IsDeleted && x.Status == AccountStatus.Locked);

        if (nearlyFull > 0)
        {
            table.Rows.Add("Cao", $"{nearlyFull} lop sap het cho trong", "Hom nay");
        }

        if (debtCount > 0)
        {
            table.Rows.Add("Trung binh", $"{debtCount} hoc vien con cong no", "Ngay mai");
        }

        if (lockedCount > 0)
        {
            table.Rows.Add("Thap", $"{lockedCount} tai khoan dang bi khoa", "Tuan nay");
        }

        if (table.Rows.Count == 0)
        {
            table.Rows.Add("Thap", "He thong dang on dinh", "Khong");
        }

        return table;
    }

    public DataTable GetMonitorActivity()
    {
        using var context = CreateContext();
        var table = CreateTable("Phan he", "Chi so", "Gia tri", "Ghi chu");
        var today = DateTime.Today;

        table.Rows.Add("Hoc vien", "Tiep nhan moi", context.Students.Count(x => !x.IsDeleted && x.BirthDate <= today).ToString(_culture), "Tong ho so hoat dong");
        table.Rows.Add(
            "Ghi danh",
            "Dang hoc",
            context.Enrollments
                .AsNoTracking()
                .Where(x => !x.IsDeleted)
                .AsEnumerable()
                .Count(x => LanguageCenterValueMapper.NormalizeEnrollmentStatus(x.Status) == "Active")
                .ToString(_culture),
            "Bao gom ca bao luu");
        table.Rows.Add("Tai chinh", "Bien lai", context.Receipts.Count(x => !x.IsDeleted && x.PayDate.Date == today).ToString(_culture), "Bien lai trong ngay");
        table.Rows.Add(
            "Dao tao",
            "Lop dang mo",
            context.Classes
                .Include(x => x.Enrollments)
                .AsEnumerable()
                .Count(x => !x.IsDeleted && GetEffectiveClassStatus(x) != "Da dong")
                .ToString(_culture),
            "Theo lich hien tai");
        return table;
    }

    public DataTable GetMonitorDetailedLog()
    {
        using var context = CreateContext();
        var table = CreateTable("THOI GIAN", "DOI TUONG", "PHAN HE", "HANH DONG", "CHI TIET");

        var receipts = context.Receipts
            .AsNoTracking()
            .Include(x => x.Enrollment!).ThenInclude(x => x.Student)
            .OrderByDescending(x => x.PayDate)
            .Take(5)
            .ToList();

        foreach (var receipt in receipts)
        {
            table.Rows.Add(
                receipt.PayDate.ToString("HH:mm:ss", _culture),
                receipt.Enrollment?.Student?.FullName ?? "N/A",
                "Thanh toan",
                "THU HOC PHI",
                receipt.Id);
        }

        return table;
    }

    public DataTable GetAccountList()
    {
        using var context = CreateContext();
        var table = CreateTable("Username", "Display Name", "Vai tro", "Trang thai");

        var accounts = context.Accounts
            .AsNoTracking()
            .Where(x => !x.IsDeleted)
            .OrderBy(x => x.DisplayName)
            .ToList();

        foreach (var account in accounts)
        {
            table.Rows.Add(
                account.Username,
                account.DisplayName,
                account.Role.ToString(),
                account.Status == AccountStatus.Active ? "Active" : "Locked");
        }

        return table;
    }

    public DataTable GetRecentReceipts()
    {
        using var context = CreateContext();
        var table = CreateTable("So bien nhan", "Hoc vien", "Lop", "So tien", "Ngay nop");
        var receipts = context.Receipts
            .AsNoTracking()
            .Include(x => x.Enrollment!).ThenInclude(x => x.Student)
            .Include(x => x.Enrollment!).ThenInclude(x => x.Class)
            .Where(x => !x.IsDeleted)
            .OrderByDescending(x => x.PayDate)
            .Take(10)
            .ToList();

        foreach (var receipt in receipts)
        {
            table.Rows.Add(
                receipt.Id,
                receipt.Enrollment?.Student?.FullName ?? string.Empty,
                receipt.Enrollment?.Class?.Name ?? string.Empty,
                FormatMoney(receipt.AmountPaid),
                receipt.PayDate.ToString("dd/MM/yyyy", _culture));
        }

        return table;
    }

    public DataTable GetStudentList(string? keyword = null, string? status = null)
    {
        using var context = CreateContext();
        var students = context.Students
            .AsNoTracking()
            .Where(x => !x.IsDeleted)
            .OrderBy(x => x.FullName)
            .ToList();
        var normalizedStatus = string.IsNullOrWhiteSpace(status) || status.Equals("Tat ca", StringComparison.OrdinalIgnoreCase)
            ? null
            : LanguageCenterValueMapper.NormalizeStudentStatus(status);

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            students = students.Where(student =>
                    student.Id.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    student.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    student.Phone.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        if (!string.IsNullOrWhiteSpace(normalizedStatus))
        {
            students = students
                .Where(student => LanguageCenterValueMapper.NormalizeStudentStatus(student.Status).Equals(normalizedStatus, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        var table = CreateTable("Ma hoc vien", "Ho ten", "Ngay sinh", "Dien thoai", "Trang thai");
        foreach (var student in students)
        {
            table.Rows.Add(
                student.Id,
                student.FullName,
                student.BirthDate.ToString("dd/MM/yyyy", _culture),
                student.Phone,
                LanguageCenterValueMapper.ToStudentStatusDisplay(student.Status));
        }

        return table;
    }

    public DataTable GetTeacherList(string? keyword = null, string? status = null)
    {
        using var context = CreateContext();
        var teachers = context.Teachers
            .AsNoTracking()
            .Where(x => !x.IsDeleted)
            .OrderBy(x => x.FullName)
            .ToList();
        var normalizedStatus = string.IsNullOrWhiteSpace(status) || status.Equals("Tat ca", StringComparison.OrdinalIgnoreCase)
            ? null
            : LanguageCenterValueMapper.NormalizeTeacherStatus(status);

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            teachers = teachers.Where(teacher =>
                    teacher.Id.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    teacher.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    teacher.Phone.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        if (!string.IsNullOrWhiteSpace(normalizedStatus))
        {
            teachers = teachers
                .Where(teacher => LanguageCenterValueMapper.NormalizeTeacherStatus(teacher.Status).Equals(normalizedStatus, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        var table = CreateTable("Ma giao vien", "Ho ten", "Dien thoai", "Email", "Chuyen mon");
        foreach (var teacher in teachers)
        {
            table.Rows.Add(
                teacher.Id,
                teacher.FullName,
                teacher.Phone,
                teacher.Email,
                teacher.Specialization ?? string.Empty);
        }

        return table;
    }

    public DataTable GetCourseList(string? keyword = null, string? status = null)
    {
        using var context = CreateContext();
        var courses = context.Courses
            .AsNoTracking()
            .Where(x => !x.IsDeleted)
            .OrderBy(x => x.Name)
            .ToList();
        var normalizedStatus = string.IsNullOrWhiteSpace(status) || status.Equals("Tat ca", StringComparison.OrdinalIgnoreCase)
            ? null
            : LanguageCenterValueMapper.NormalizeCourseStatus(status);

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            courses = courses.Where(course =>
                    course.Id.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    course.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        if (!string.IsNullOrWhiteSpace(normalizedStatus))
        {
            courses = courses
                .Where(course => LanguageCenterValueMapper.NormalizeCourseStatus(course.Status).Equals(normalizedStatus, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        var table = CreateTable("Ma khoa", "Ten khoa", "Level", "Hoc phi", "Trang thai");
        foreach (var course in courses)
        {
            table.Rows.Add(
                course.Id,
                course.Name,
                ExtractCourseLevel(course.Name, course.Description),
                FormatMoney(course.TuitionFee),
                LanguageCenterValueMapper.ToCourseStatusDisplay(course.Status));
        }

        return table;
    }

    public DataTable GetClassList(string? keyword = null, string? status = null, string? courseId = null)
    {
        using var context = CreateContext();
        var classes = context.Classes
            .AsNoTracking()
            .Include(x => x.Course)
            .Include(x => x.Teacher)
            .Include(x => x.Enrollments)
            .Where(x => !x.IsDeleted)
            .OrderBy(x => x.Name)
            .ToList();
        var normalizedStatus = string.IsNullOrWhiteSpace(status)
                               || status.Equals("Tat ca", StringComparison.OrdinalIgnoreCase)
                               || status.Equals("Tất cả", StringComparison.OrdinalIgnoreCase)
                               || status.Equals("Day", StringComparison.OrdinalIgnoreCase)
                               || status.Equals("Đầy", StringComparison.OrdinalIgnoreCase)
            ? null
            : LanguageCenterValueMapper.NormalizeClassStatus(status);

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            classes = classes.Where(classItem =>
                    classItem.Id.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    classItem.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        if (!string.IsNullOrWhiteSpace(courseId))
        {
            classes = classes.Where(classItem =>
                    classItem.CourseId.Equals(courseId, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(classItem.Course?.Name, courseId, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        if (!string.IsNullOrWhiteSpace(status)
            && !status.Equals("Tat ca", StringComparison.OrdinalIgnoreCase)
            && !status.Equals("Tất cả", StringComparison.OrdinalIgnoreCase))
        {
            classes = status.Equals("Day", StringComparison.OrdinalIgnoreCase) || status.Equals("Đầy", StringComparison.OrdinalIgnoreCase)
                ? classes.Where(classItem => GetEffectiveClassStatus(classItem).Equals("Day", StringComparison.OrdinalIgnoreCase)).ToList()
                : classes.Where(classItem => LanguageCenterValueMapper.NormalizeClassStatus(classItem.Status).Equals(normalizedStatus, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        var table = CreateTable("Ma lop", "Ten lop", "Khoa hoc", "Giao vien", "Lich hoc", "Si so", "Trang thai");
        foreach (var classItem in classes)
        {
            var activeCount = GetActiveEnrollmentCount(classItem);
            table.Rows.Add(
                classItem.Id,
                classItem.Name,
                classItem.Course?.Name ?? string.Empty,
                classItem.Teacher?.FullName ?? string.Empty,
                classItem.Schedule ?? string.Empty,
                $"{activeCount}/{classItem.MaxStudents}",
                GetEffectiveClassStatus(classItem));
        }

        return table;
    }

    public DataTable GetClassStudents(string? classId = null)
    {
        using var context = CreateContext();
        var targetClassId = classId;
        if (string.IsNullOrWhiteSpace(targetClassId))
        {
            targetClassId = context.Classes
                .AsNoTracking()
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.Name)
                .Select(x => x.Id)
                .FirstOrDefault();
        }

        var table = CreateTable("Ma hoc vien", "Ho ten", "Ngay ghi danh", "Trang thai");
        if (string.IsNullOrWhiteSpace(targetClassId))
        {
            return table;
        }

        var enrollments = context.Enrollments
            .AsNoTracking()
            .Include(x => x.Student)
            .Where(x => !x.IsDeleted && x.ClassId == targetClassId)
            .OrderBy(x => x.Student!.FullName)
            .ToList();

        foreach (var enrollment in enrollments)
        {
            table.Rows.Add(
                enrollment.Student?.Id ?? string.Empty,
                enrollment.Student?.FullName ?? string.Empty,
                enrollment.EnrollDate.ToString("dd/MM/yyyy", _culture),
                LanguageCenterValueMapper.ToEnrollmentStatusDisplay(enrollment.Status));
        }

        return table;
    }

    public DataTable GetSessions(string? classId = null)
    {
        using var context = CreateContext();
        var classItem = context.Classes
            .AsNoTracking()
            .Where(x => !x.IsDeleted && (classId == null || x.Id == classId))
            .OrderBy(x => x.Name)
            .FirstOrDefault();

        var table = CreateTable("Buoi", "Ngay hoc", "Khung gio", "Phong", "Trang thai");
        if (classItem is null)
        {
            return table;
        }

        var sessionDate = classItem.StartDate.Date;
        for (var index = 1; index <= 6; index++)
        {
            var status = sessionDate.Date < DateTime.Today
                ? "Da hoc"
                : sessionDate.Date == DateTime.Today ? "Hom nay" : "Sap dien ra";

            table.Rows.Add(
                $"Buoi {index:00}",
                sessionDate.ToString("dd/MM/yyyy", _culture),
                classItem.Schedule ?? "18:00 - 19:30",
                classItem.Room ?? "P101",
                status);

            sessionDate = sessionDate.AddDays(7);
            if (sessionDate > classItem.EndDate)
            {
                break;
            }
        }

        return table;
    }

    public DataTable GetEnrollmentStudents(string? keyword = null)
    {
        return GetStudentList(keyword, null);
    }

    public DataTable GetEnrollmentClasses(string? courseId = null, bool onlyAvailable = true)
    {
        using var context = CreateContext();
        var classes = context.Classes
            .AsNoTracking()
            .Include(x => x.Course)
            .Include(x => x.Teacher)
            .Include(x => x.Enrollments)
            .Where(x => !x.IsDeleted)
            .OrderBy(x => x.Name)
            .ToList();

        if (!string.IsNullOrWhiteSpace(courseId))
        {
            classes = classes.Where(x => x.CourseId == courseId || string.Equals(x.Course!.Name, courseId, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (onlyAvailable)
        {
            classes = classes.Where(ClassHasAvailableSlot).ToList();
        }
        else
        {
            classes = classes.Where(classItem => GetEffectiveClassStatus(classItem) != "Da dong").ToList();
        }

        var table = CreateTable("Ma lop", "Ten lop", "Khoa hoc", "Giao vien", "Lich hoc", "Con cho", "Hoc phi");
        foreach (var classItem in classes)
        {
            var activeCount = GetActiveEnrollmentCount(classItem);
            table.Rows.Add(
                classItem.Id,
                classItem.Name,
                classItem.Course?.Name ?? string.Empty,
                classItem.Teacher?.FullName ?? string.Empty,
                classItem.Schedule ?? string.Empty,
                (classItem.MaxStudents - activeCount).ToString(_culture),
                FormatMoney(classItem.Course?.TuitionFee ?? 0M));
        }

        return table;
    }

    public DataTable GetReceiptHistory(string? enrollmentId = null, string? studentId = null)
    {
        using var context = CreateContext();
        var receipts = context.Receipts
            .AsNoTracking()
            .Include(x => x.Enrollment!).ThenInclude(x => x.Student)
            .Where(x => !x.IsDeleted)
            .OrderByDescending(x => x.PayDate)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(enrollmentId))
        {
            receipts = receipts.Where(x => x.EnrollmentId == enrollmentId);
        }

        if (!string.IsNullOrWhiteSpace(studentId))
        {
            receipts = receipts.Where(x => x.Enrollment != null && x.Enrollment.StudentId == studentId);
        }

        var table = CreateTable("So bien nhan", "Ngay nop", "Phuong thuc", "So tien", "Ghi chu");
        foreach (var receipt in receipts.ToList())
        {
            table.Rows.Add(
                receipt.Id,
                receipt.PayDate.ToString("dd/MM/yyyy", _culture),
                LanguageCenterValueMapper.ToPaymentMethodDisplay(receipt.PaymentMethod),
                FormatMoney(receipt.AmountPaid),
                receipt.Note ?? string.Empty);
        }

        return table;
    }

    public DataTable GetDebtList(string? courseName = null, string? className = null, DateTime? fromDate = null, DateTime? toDate = null)
    {
        using var context = CreateContext();
        var debtRows = BuildDebtRows(context);

        if (!string.IsNullOrWhiteSpace(courseName) && !courseName.Equals("Tat ca", StringComparison.OrdinalIgnoreCase))
        {
            debtRows = debtRows.Where(x => x.CourseName.Equals(courseName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (!string.IsNullOrWhiteSpace(className) && !className.Equals("Tat ca", StringComparison.OrdinalIgnoreCase))
        {
            debtRows = debtRows.Where(x => x.ClassName.Equals(className, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (fromDate.HasValue || toDate.HasValue)
        {
            var start = fromDate?.Date ?? DateTime.MinValue;
            var end = toDate?.Date ?? DateTime.MaxValue;
            debtRows = debtRows.Where(x => x.ReferenceDate.Date >= start && x.ReferenceDate.Date <= end).ToList();
        }

        var table = CreateTable("Ma hoc vien", "Hoc vien", "Lop", "Khoa hoc", "Phai thu", "Da thu", "Con no", "Trang thai");
        foreach (var row in debtRows.Where(x => x.Outstanding > 0))
        {
            table.Rows.Add(
                row.StudentId,
                row.StudentName,
                row.ClassName,
                row.CourseName,
                FormatMoney(row.RequiredAmount),
                FormatMoney(row.PaidAmount),
                FormatMoney(row.Outstanding),
                row.Status);
        }

        return table;
    }

    public DataTable GetTeachingClasses(string? teacherAccountId = null)
    {
        using var context = CreateContext();
        var teacherId = ResolveTeacherIdByAccount(context, teacherAccountId);
        var classes = context.Classes
            .AsNoTracking()
            .Include(x => x.Course)
            .Include(x => x.Enrollments)
            .Where(x => !x.IsDeleted && (teacherId == null || x.TeacherId == teacherId))
            .OrderBy(x => x.Name)
            .ToList();

        var table = CreateTable("Ma lop", "Ten lop", "Khoa hoc", "Lich hoc", "Si so", "Trang thai", "Thao tac");
        foreach (var classItem in classes)
        {
            table.Rows.Add(
                classItem.Id,
                classItem.Name,
                classItem.Course?.Name ?? string.Empty,
                classItem.Schedule ?? string.Empty,
                $"{GetActiveEnrollmentCount(classItem)}/{classItem.MaxStudents}",
                GetEffectiveClassStatus(classItem),
                string.Empty);
        }

        return table;
    }

    public DataTable GetAttendanceList(string? classId = null, DateTime? attendanceDate = null)
    {
        using var context = CreateContext();
        var targetClassId = classId ?? context.Classes.Where(x => !x.IsDeleted).OrderBy(x => x.Name).Select(x => x.Id).FirstOrDefault();
        var targetDate = (attendanceDate ?? DateTime.Today).Date;
        var table = CreateTable("EnrollmentId", "Ma hoc vien", "Ho ten", "Trang thai", "Ghi chu");
        if (string.IsNullOrWhiteSpace(targetClassId))
        {
            return table;
        }

        var enrollments = context.Enrollments
            .AsNoTracking()
            .Include(x => x.Student)
            .Include(x => x.Attendances)
            .Where(x => !x.IsDeleted && x.ClassId == targetClassId)
            .OrderBy(x => x.Student!.FullName)
            .ToList();

        foreach (var enrollment in enrollments)
        {
            var attendance = enrollment.Attendances.FirstOrDefault(x => x.AttendanceDate.Date == targetDate);
            table.Rows.Add(
                enrollment.Id,
                enrollment.Student?.Id ?? string.Empty,
                enrollment.Student?.FullName ?? string.Empty,
                attendance?.Status ?? "Present",
                attendance?.Note ?? string.Empty);
        }

        return table;
    }

    public DataTable GetScoreList(string? classId = null)
    {
        using var context = CreateContext();
        var targetClassId = classId ?? context.Classes.Where(x => !x.IsDeleted).OrderBy(x => x.Name).Select(x => x.Id).FirstOrDefault();
        var table = CreateTable("EnrollmentId", "Ma hoc vien", "Ho ten", "Diem giua ky", "Diem cuoi ky", "Ghi chu");
        if (string.IsNullOrWhiteSpace(targetClassId))
        {
            return table;
        }

        var enrollments = context.Enrollments
            .AsNoTracking()
            .Include(x => x.Student)
            .Include(x => x.Score)
            .Where(x => !x.IsDeleted && x.ClassId == targetClassId)
            .OrderBy(x => x.Student!.FullName)
            .ToList();

        foreach (var enrollment in enrollments)
        {
            table.Rows.Add(
                enrollment.Id,
                enrollment.Student?.Id ?? string.Empty,
                enrollment.Student?.FullName ?? string.Empty,
                enrollment.Score?.MidtermScore?.ToString("0.##", _culture) ?? string.Empty,
                enrollment.Score?.FinalScore?.ToString("0.##", _culture) ?? string.Empty,
                enrollment.Score?.Note ?? string.Empty);
        }

        return table;
    }

    public DataTable GetReportDetail(string reportType = "Doanh thu tong hop", DateTime? fromDate = null, DateTime? toDate = null)
    {
        var normalized = reportType.ToLowerInvariant();
        return normalized.Contains("tuyen")
            ? BuildEnrollmentReportDetail(fromDate, toDate)
            : normalized.Contains("no")
                ? BuildDebtReportDetail(fromDate, toDate)
                : BuildRevenueReportDetail(fromDate, toDate);
    }

    public DashboardStats GetAdminDashboardStats()
    {
        using var context = CreateContext();
        var totalDebt = BuildDebtRows(context).Sum(x => x.Outstanding);
        var currentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        var activeClassCount = context.Classes
            .Include(x => x.Enrollments)
            .AsEnumerable()
            .Count(x => !x.IsDeleted && GetEffectiveClassStatus(x) != "Da dong");

        return new DashboardStats
        {
            TotalStaff = context.Accounts.Count(x => !x.IsDeleted && x.Role == AccountRole.Staff),
            TotalTeachers = context.Teachers.Count(x => !x.IsDeleted),
            TotalActiveClasses = activeClassCount,
            TotalStudents = context.Students.Count(x => !x.IsDeleted),
            TotalReceipts = context.Receipts.Count(x => !x.IsDeleted),
            TotalRevenue = context.Receipts.Where(x => !x.IsDeleted).Sum(x => (decimal?)x.AmountPaid) ?? 0M,
            TotalDebt = totalDebt,
            NewStudentsThisMonth = context.Enrollments
                .Where(x => !x.IsDeleted && x.EnrollDate >= currentMonth)
                .Select(x => x.StudentId)
                .Distinct()
                .Count()
        };
    }

    public DashboardStats GetStaffDashboardStats()
    {
        using var context = CreateContext();
        var stats = GetAdminDashboardStats();
        return new DashboardStats
        {
            TotalStaff = stats.TotalStaff,
            TotalTeachers = stats.TotalTeachers,
            TotalActiveClasses = stats.TotalActiveClasses,
            TotalStudents = stats.TotalStudents,
            TotalReceipts = stats.TotalReceipts,
            TotalRevenue = stats.TotalRevenue,
            TotalDebt = stats.TotalDebt,
            NewStudentsThisMonth = stats.NewStudentsThisMonth
        };
    }

    public TeacherDashboardStats GetTeacherDashboardStats(string? teacherAccountId = null)
    {
        using var context = CreateContext();
        var teacherId = ResolveTeacherIdByAccount(context, teacherAccountId);
        var classes = context.Classes
            .Include(x => x.Enrollments)
            .Where(x => !x.IsDeleted && (teacherId == null || x.TeacherId == teacherId))
            .ToList();

        var classIds = classes.Select(x => x.Id).ToList();
        var today = DateTime.Today;
        var pendingScores = context.Enrollments
            .Include(x => x.Score)
            .Count(x => !x.IsDeleted && classIds.Contains(x.ClassId) && x.Score == null);

        return new TeacherDashboardStats
        {
            TeachingClassCount = classes.Count,
            TeachingStudentCount = classes.Sum(GetActiveEnrollmentCount),
            TodaySessionCount = classes.Count(x => GetEffectiveClassStatus(x) != "Da dong"),
            PendingScoreCount = pendingScores
        };
    }

    public IReadOnlyList<ReportPoint> GetMonthlyRevenue(DateTime? fromDate = null, DateTime? toDate = null)
    {
        using var context = CreateContext();
        var start = fromDate ?? new DateTime(DateTime.Today.Year, 1, 1);
        var end = toDate ?? DateTime.Today;

        return context.Receipts
            .AsNoTracking()
            .Where(x => !x.IsDeleted && x.PayDate.Date >= start.Date && x.PayDate.Date <= end.Date)
            .GroupBy(x => new { x.PayDate.Year, x.PayDate.Month })
            .OrderBy(x => x.Key.Year)
            .ThenBy(x => x.Key.Month)
            .Select(group => new ReportPoint
            {
                Label = $"{group.Key.Month:00}/{group.Key.Year}",
                Value = group.Sum(x => x.AmountPaid)
            })
            .ToList();
    }

    public IReadOnlyList<ReportPoint> GetMonthlyEnrollmentCounts(DateTime? fromDate = null, DateTime? toDate = null)
    {
        using var context = CreateContext();
        var start = fromDate ?? new DateTime(DateTime.Today.Year, 1, 1);
        var end = toDate ?? DateTime.Today;

        return context.Enrollments
            .AsNoTracking()
            .Where(x => !x.IsDeleted && x.EnrollDate.Date >= start.Date && x.EnrollDate.Date <= end.Date)
            .GroupBy(x => new { x.EnrollDate.Year, x.EnrollDate.Month })
            .OrderBy(x => x.Key.Year)
            .ThenBy(x => x.Key.Month)
            .Select(group => new ReportPoint
            {
                Label = $"{group.Key.Month:00}/{group.Key.Year}",
                Value = group.Count()
            })
            .ToList();
    }

    public StudentEntity? GetStudentById(string studentId)
    {
        using var context = CreateContext();
        var student = context.Students.AsNoTracking().FirstOrDefault(x => x.Id == studentId && !x.IsDeleted);
        if (student is not null)
        {
            student.Status = LanguageCenterValueMapper.ToStudentStatusDisplay(student.Status);
        }

        return student;
    }

    public TeacherEntity? GetTeacherById(string teacherId)
    {
        using var context = CreateContext();
        var teacher = context.Teachers.AsNoTracking().FirstOrDefault(x => x.Id == teacherId && !x.IsDeleted);
        if (teacher is not null)
        {
            teacher.Status = LanguageCenterValueMapper.ToTeacherStatusDisplay(teacher.Status);
        }

        return teacher;
    }

    public CourseEntity? GetCourseById(string courseId)
    {
        using var context = CreateContext();
        var course = context.Courses.AsNoTracking().FirstOrDefault(x => x.Id == courseId && !x.IsDeleted);
        if (course is not null)
        {
            course.Status = LanguageCenterValueMapper.ToCourseStatusDisplay(course.Status);
        }

        return course;
    }

    public ClassEntity? GetClassById(string classId)
    {
        using var context = CreateContext();
        var classItem = context.Classes.AsNoTracking().FirstOrDefault(x => x.Id == classId && !x.IsDeleted);
        if (classItem is not null)
        {
            classItem.Status = LanguageCenterValueMapper.ToClassStatusDisplay(classItem.Status);
        }

        return classItem;
    }

    public EnrollmentEntity? GetEnrollmentById(string enrollmentId)
    {
        using var context = CreateContext();
        var enrollment = context.Enrollments
            .AsNoTracking()
            .Include(x => x.Student)
            .Include(x => x.Class!).ThenInclude(x => x.Course)
            .FirstOrDefault(x => x.Id == enrollmentId && !x.IsDeleted);
        if (enrollment is not null)
        {
            enrollment.Status = LanguageCenterValueMapper.ToEnrollmentStatusDisplay(enrollment.Status);
        }

        return enrollment;
    }

    public ReceiptEntity? GetReceiptById(string receiptId)
    {
        using var context = CreateContext();
        var receipt = context.Receipts
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == receiptId && !x.IsDeleted);
        if (receipt is not null)
        {
            receipt.PaymentMethod = LanguageCenterValueMapper.ToPaymentMethodDisplay(receipt.PaymentMethod);
        }

        return receipt;
    }

    public StudentEntity SaveStudent(StudentEntity student)
    {
        try
        {
            ValidateStudent(student);
            var normalizedStatus = LanguageCenterValueMapper.NormalizeStudentStatus(student.Status);
            using var context = CreateContext();
            var entity = context.Students.FirstOrDefault(x => x.Id == student.Id);
            if (entity is null)
            {
                entity = new StudentEntity
                {
                    Id = string.IsNullOrWhiteSpace(student.Id) ? GetNextCode(context.Students.Select(x => x.Id).ToList(), "HV") : student.Id,
                    FullName = student.FullName.Trim(),
                    BirthDate = student.BirthDate.Date,
                    Phone = student.Phone.Trim(),
                    Email = student.Email?.Trim(),
                    Address = student.Address?.Trim(),
                    AvatarPath = student.AvatarPath,
                    Status = normalizedStatus,
                    IsDeleted = false
                };
                context.Students.Add(entity);
            }
            else
            {
                entity.FullName = student.FullName.Trim();
                entity.BirthDate = student.BirthDate.Date;
                entity.Phone = student.Phone.Trim();
                entity.Email = student.Email?.Trim();
                entity.Address = student.Address?.Trim();
                entity.AvatarPath = student.AvatarPath;
                entity.Status = normalizedStatus;
            }

            context.SaveChanges();
            entity.Status = LanguageCenterValueMapper.ToStudentStatusDisplay(entity.Status);
            return entity;
        }
        catch (Exception exception)
        {
            ErrorLogger.Log(exception, "SaveStudent");
            throw;
        }
    }

    public TeacherEntity SaveTeacher(TeacherEntity teacher)
    {
        try
        {
            ValidateTeacher(teacher);
            var normalizedStatus = LanguageCenterValueMapper.NormalizeTeacherStatus(teacher.Status);
            using var context = CreateContext();
            var entity = context.Teachers.FirstOrDefault(x => x.Id == teacher.Id);
            if (entity is null)
            {
                entity = new TeacherEntity
                {
                    Id = string.IsNullOrWhiteSpace(teacher.Id) ? GetNextCode(context.Teachers.Select(x => x.Id).ToList(), "GV") : teacher.Id,
                    FullName = teacher.FullName.Trim(),
                    Phone = teacher.Phone.Trim(),
                    Email = teacher.Email.Trim(),
                    Specialization = teacher.Specialization?.Trim(),
                    Gender = teacher.Gender?.Trim(),
                    Address = teacher.Address?.Trim(),
                    AvatarPath = teacher.AvatarPath,
                    AccountId = teacher.AccountId,
                    Status = normalizedStatus,
                    IsDeleted = false
                };
                context.Teachers.Add(entity);
            }
            else
            {
                entity.FullName = teacher.FullName.Trim();
                entity.Phone = teacher.Phone.Trim();
                entity.Email = teacher.Email.Trim();
                entity.Specialization = teacher.Specialization?.Trim();
                entity.Gender = teacher.Gender?.Trim();
                entity.Address = teacher.Address?.Trim();
                entity.AvatarPath = teacher.AvatarPath;
                entity.AccountId = teacher.AccountId;
                entity.Status = normalizedStatus;
            }

            context.SaveChanges();
            entity.Status = LanguageCenterValueMapper.ToTeacherStatusDisplay(entity.Status);
            return entity;
        }
        catch (Exception exception)
        {
            ErrorLogger.Log(exception, "SaveTeacher");
            throw;
        }
    }

    public CourseEntity SaveCourse(CourseEntity course)
    {
        try
        {
            ValidateCourse(course);
            var normalizedStatus = LanguageCenterValueMapper.NormalizeCourseStatus(course.Status);
            using var context = CreateContext();
            var entity = context.Courses.FirstOrDefault(x => x.Id == course.Id);
            if (entity is null)
            {
                entity = new CourseEntity
                {
                    Id = string.IsNullOrWhiteSpace(course.Id) ? GetNextCode(context.Courses.Select(x => x.Id).ToList(), "KH") : course.Id,
                    Name = course.Name.Trim(),
                    Description = course.Description?.Trim(),
                    TuitionFee = course.TuitionFee,
                    Status = normalizedStatus,
                    IsDeleted = false
                };
                context.Courses.Add(entity);
            }
            else
            {
                entity.Name = course.Name.Trim();
                entity.Description = course.Description?.Trim();
                entity.TuitionFee = course.TuitionFee;
                entity.Status = normalizedStatus;
            }

            context.SaveChanges();
            entity.Status = LanguageCenterValueMapper.ToCourseStatusDisplay(entity.Status);
            return entity;
        }
        catch (Exception exception)
        {
            ErrorLogger.Log(exception, "SaveCourse");
            throw;
        }
    }

    public ClassEntity SaveClass(ClassEntity classEntity)
    {
        try
        {
            ValidateClass(classEntity);
            var normalizedStatus = LanguageCenterValueMapper.NormalizeClassStatus(classEntity.Status);
            using var context = CreateContext();
            var courseId = ResolveCourseId(context, classEntity.CourseId);
            var teacherId = ResolveTeacherId(context, classEntity.TeacherId);
            var entity = context.Classes.FirstOrDefault(x => x.Id == classEntity.Id);
            if (entity is null)
            {
                entity = new ClassEntity
                {
                    Id = string.IsNullOrWhiteSpace(classEntity.Id) ? GetNextCode(context.Classes.Select(x => x.Id).ToList(), "LP") : classEntity.Id,
                    Name = classEntity.Name.Trim(),
                    CourseId = courseId,
                    TeacherId = teacherId,
                    StartDate = classEntity.StartDate.Date,
                    EndDate = classEntity.EndDate.Date,
                    Schedule = classEntity.Schedule?.Trim(),
                    Room = classEntity.Room?.Trim(),
                    MaxStudents = classEntity.MaxStudents,
                    Status = normalizedStatus,
                    IsDeleted = false
                };
                context.Classes.Add(entity);
            }
            else
            {
                entity.Name = classEntity.Name.Trim();
                entity.CourseId = courseId;
                entity.TeacherId = teacherId;
                entity.StartDate = classEntity.StartDate.Date;
                entity.EndDate = classEntity.EndDate.Date;
                entity.Schedule = classEntity.Schedule?.Trim();
                entity.Room = classEntity.Room?.Trim();
                entity.MaxStudents = classEntity.MaxStudents;
                entity.Status = normalizedStatus;
            }

            context.SaveChanges();
            entity.Status = LanguageCenterValueMapper.ToClassStatusDisplay(entity.Status);
            return entity;
        }
        catch (Exception exception)
        {
            ErrorLogger.Log(exception, "SaveClass");
            throw;
        }
    }

    public void SoftDeleteStudent(string studentId)
    {
        SoftDeleteEntity(studentId, context => context.Students, "SoftDeleteStudent");
    }

    public void SoftDeleteTeacher(string teacherId)
    {
        SoftDeleteEntity(teacherId, context => context.Teachers, "SoftDeleteTeacher");
    }

    public void SoftDeleteCourse(string courseId)
    {
        SoftDeleteEntity(courseId, context => context.Courses, "SoftDeleteCourse");
    }

    public void SoftDeleteClass(string classId)
    {
        SoftDeleteEntity(classId, context => context.Classes, "SoftDeleteClass");
    }

    public EnrollmentEntity CreateEnrollment(string studentId, string classId, DateTime enrollDate, string status, string? note)
    {
        try
        {
            using var context = CreateContext();
            var student = context.Students.FirstOrDefault(x => x.Id == studentId && !x.IsDeleted)
                          ?? throw new InvalidOperationException("Hoc vien khong ton tai.");
            var classItem = context.Classes
                .Include(x => x.Enrollments)
                .FirstOrDefault(x => x.Id == classId && !x.IsDeleted)
                ?? throw new InvalidOperationException("Lop hoc khong ton tai.");

            if (StudentAlreadyEnrolled(studentId, classId))
            {
                throw new InvalidOperationException("Hoc vien da duoc ghi danh trong lop nay.");
            }

            if (!ClassHasAvailableSlot(classItem))
            {
                throw new InvalidOperationException("Lop hoc da het cho.");
            }

            var normalizedStatus = LanguageCenterValueMapper.NormalizeEnrollmentStatus(status);

            var enrollment = new EnrollmentEntity
            {
                Id = GetNextCode(context.Enrollments.Select(x => x.Id).ToList(), "GD"),
                StudentId = studentId,
                ClassId = classId,
                EnrollDate = enrollDate.Date,
                Status = normalizedStatus,
                Note = note?.Trim(),
                IsDeleted = false
            };

            student.Status = normalizedStatus;
            context.Enrollments.Add(enrollment);
            context.SaveChanges();
            enrollment.Status = LanguageCenterValueMapper.ToEnrollmentStatusDisplay(enrollment.Status);
            return enrollment;
        }
        catch (Exception exception)
        {
            ErrorLogger.Log(exception, "CreateEnrollment");
            throw;
        }
    }

    public bool StudentAlreadyEnrolled(string studentId, string classId)
    {
        using var context = CreateContext();
        return context.Enrollments
            .AsNoTracking()
            .Where(x =>
                !x.IsDeleted &&
                x.StudentId == studentId &&
                x.ClassId == classId)
            .AsEnumerable()
            .Any(x => IsEnrollmentCountedAsActive(x.Status));
    }

    public bool ClassHasAvailableSlot(string classId)
    {
        using var context = CreateContext();
        var classItem = context.Classes
            .AsNoTracking()
            .Include(x => x.Enrollments)
            .FirstOrDefault(x => x.Id == classId && !x.IsDeleted);
        return classItem is not null && ClassHasAvailableSlot(classItem);
    }

    public EnrollmentReceiptContext? GetEnrollmentReceiptContext(string enrollmentId)
    {
        using var context = CreateContext();
        var enrollment = context.Enrollments
            .AsNoTracking()
            .Include(x => x.Student)
            .Include(x => x.Class!).ThenInclude(x => x.Course)
            .Include(x => x.Receipts)
            .FirstOrDefault(x => x.Id == enrollmentId && !x.IsDeleted);

        if (enrollment is null || enrollment.Student is null || enrollment.Class?.Course is null)
        {
            return null;
        }

        var tuitionFee = enrollment.Class.Course.TuitionFee;
        var totalPaid = enrollment.Receipts.Where(x => !x.IsDeleted).Sum(x => x.AmountPaid);
        return new EnrollmentReceiptContext
        {
            EnrollmentId = enrollment.Id,
            StudentCode = enrollment.Student.Id,
            StudentName = enrollment.Student.FullName,
            ClassCode = enrollment.Class.Id,
            ClassName = enrollment.Class.Name,
            CourseName = enrollment.Class.Course.Name,
            TuitionFee = tuitionFee,
            TotalPaid = totalPaid,
            OutstandingBalance = Math.Max(0, tuitionFee - totalPaid)
        };
    }

    public EnrollmentReceiptContext? GetLatestEnrollmentReceiptContextByStudentId(string studentId)
    {
        using var context = CreateContext();
        var enrollment = context.Enrollments
            .AsNoTracking()
            .Include(x => x.Student)
            .Include(x => x.Class!).ThenInclude(x => x.Course)
            .Include(x => x.Receipts)
            .Where(x => !x.IsDeleted && x.StudentId == studentId)
            .OrderByDescending(x => x.EnrollDate)
            .FirstOrDefault();

        if (enrollment is null || enrollment.Student is null || enrollment.Class?.Course is null)
        {
            return null;
        }

        var tuitionFee = enrollment.Class.Course.TuitionFee;
        var totalPaid = enrollment.Receipts.Where(x => !x.IsDeleted).Sum(x => x.AmountPaid);
        return new EnrollmentReceiptContext
        {
            EnrollmentId = enrollment.Id,
            StudentCode = enrollment.Student.Id,
            StudentName = enrollment.Student.FullName,
            ClassCode = enrollment.Class.Id,
            ClassName = enrollment.Class.Name,
            CourseName = enrollment.Class.Course.Name,
            TuitionFee = tuitionFee,
            TotalPaid = totalPaid,
            OutstandingBalance = Math.Max(0, tuitionFee - totalPaid)
        };
    }

    public ReceiptEntity SaveReceipt(
        string? receiptId,
        string enrollmentId,
        decimal amountPaid,
        DateTime payDate,
        string paymentMethod,
        string? note,
        string? createdByStaffId)
    {
        try
        {
            if (amountPaid < 0)
            {
                throw new InvalidOperationException("So tien thu phai lon hon hoac bang 0.");
            }

            var normalizedPaymentMethod = LanguageCenterValueMapper.NormalizePaymentMethod(paymentMethod);

            using var context = CreateContext();
            var enrollment = context.Enrollments
                .Include(x => x.Class!).ThenInclude(x => x.Course)
                .Include(x => x.Student)
                .FirstOrDefault(x => x.Id == enrollmentId && !x.IsDeleted)
                ?? throw new InvalidOperationException("Ghi danh khong ton tai.");

            var entity = string.IsNullOrWhiteSpace(receiptId)
                ? null
                : context.Receipts.FirstOrDefault(x => x.Id == receiptId);

            if (entity is null)
            {
                entity = new ReceiptEntity
                {
                    Id = GetNextCode(context.Receipts.Select(x => x.Id).ToList(), "PT"),
                    EnrollmentId = enrollmentId,
                    AmountPaid = amountPaid,
                    PayDate = payDate.Date,
                    PaymentMethod = normalizedPaymentMethod,
                    Note = note?.Trim(),
                    CreatedByStaffId = createdByStaffId,
                    IsDeleted = false
                };
                context.Receipts.Add(entity);
            }
            else
            {
                entity.AmountPaid = amountPaid;
                entity.PayDate = payDate.Date;
                entity.PaymentMethod = normalizedPaymentMethod;
                entity.Note = note?.Trim();
                entity.CreatedByStaffId = createdByStaffId;
            }

            context.SaveChanges();
            entity.PaymentMethod = LanguageCenterValueMapper.ToPaymentMethodDisplay(entity.PaymentMethod);
            return entity;
        }
        catch (Exception exception)
        {
            ErrorLogger.Log(exception, "SaveReceipt");
            throw;
        }
    }

    public ReceiptPrintInfo GetReceiptPrintInfo(string receiptId)
    {
        using var context = CreateContext();
        var receipt = context.Receipts
            .AsNoTracking()
            .Include(x => x.CreatedByStaff)
            .Include(x => x.Enrollment!).ThenInclude(x => x.Student)
            .Include(x => x.Enrollment!).ThenInclude(x => x.Class!).ThenInclude(x => x.Course)
            .FirstOrDefault(x => x.Id == receiptId && !x.IsDeleted)
            ?? throw new InvalidOperationException("Khong tim thay bien lai.");

        var relatedReceipts = context.Receipts
            .AsNoTracking()
            .Where(x => !x.IsDeleted && x.EnrollmentId == receipt.EnrollmentId)
            .ToList();

        var tuitionFee = receipt.Enrollment?.Class?.Course?.TuitionFee ?? 0M;
        var totalPaid = relatedReceipts.Sum(x => x.AmountPaid);

        return new ReceiptPrintInfo
        {
            ReceiptId = receipt.Id,
            StudentName = receipt.Enrollment?.Student?.FullName ?? string.Empty,
            StudentCode = receipt.Enrollment?.Student?.Id ?? string.Empty,
            ClassName = receipt.Enrollment?.Class?.Name ?? string.Empty,
            CourseName = receipt.Enrollment?.Class?.Course?.Name ?? string.Empty,
            TuitionFee = tuitionFee,
            AmountPaid = receipt.AmountPaid,
            TotalPaid = totalPaid,
            OutstandingBalance = Math.Max(0, tuitionFee - totalPaid),
            PayDate = receipt.PayDate,
            PaymentMethod = LanguageCenterValueMapper.ToPaymentMethodDisplay(receipt.PaymentMethod),
            Note = receipt.Note,
            StaffName = receipt.CreatedByStaff?.DisplayName
        };
    }

    public void SaveAttendance(string classId, DateTime attendanceDate, IEnumerable<AttendanceSaveItem> items)
    {
        try
        {
            using var context = CreateContext();
            var activeEnrollmentIds = context.Enrollments
                .Where(x => !x.IsDeleted && x.ClassId == classId)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var item in items.Where(item => activeEnrollmentIds.Contains(item.EnrollmentId)))
            {
                var entity = context.Attendances
                    .FirstOrDefault(x => x.EnrollmentId == item.EnrollmentId && x.AttendanceDate.Date == attendanceDate.Date);

                if (entity is null)
                {
                    entity = new AttendanceEntity
                    {
                        Id = GetNextCode(context.Attendances.Select(x => x.Id).ToList(), "DD"),
                        EnrollmentId = item.EnrollmentId,
                        AttendanceDate = attendanceDate.Date,
                        Status = item.Status,
                        Note = item.Note?.Trim()
                    };
                    context.Attendances.Add(entity);
                }
                else
                {
                    entity.Status = item.Status;
                    entity.Note = item.Note?.Trim();
                }
            }

            context.SaveChanges();
        }
        catch (Exception exception)
        {
            ErrorLogger.Log(exception, "SaveAttendance");
            throw;
        }
    }

    public void SaveScores(string classId, IEnumerable<ScoreSaveItem> items)
    {
        try
        {
            using var context = CreateContext();
            var activeEnrollmentIds = context.Enrollments
                .Where(x => !x.IsDeleted && x.ClassId == classId)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var item in items.Where(item => activeEnrollmentIds.Contains(item.EnrollmentId)))
            {
                ValidateScore(item.MidtermScore, "Diem giua ky");
                ValidateScore(item.FinalScore, "Diem cuoi ky");

                var entity = context.Scores.FirstOrDefault(x => x.EnrollmentId == item.EnrollmentId);
                if (entity is null)
                {
                    entity = new ScoreEntity
                    {
                        Id = GetNextCode(context.Scores.Select(x => x.Id).ToList(), "DS"),
                        EnrollmentId = item.EnrollmentId,
                        MidtermScore = item.MidtermScore,
                        FinalScore = item.FinalScore,
                        Note = item.Note?.Trim()
                    };
                    context.Scores.Add(entity);
                }
                else
                {
                    entity.MidtermScore = item.MidtermScore;
                    entity.FinalScore = item.FinalScore;
                    entity.Note = item.Note?.Trim();
                }
            }

            context.SaveChanges();
        }
        catch (Exception exception)
        {
            ErrorLogger.Log(exception, "SaveScores");
            throw;
        }
    }

    public string SaveStudentAvatar(string studentId, string sourceImagePath)
    {
        try
        {
            using var context = CreateContext();
            var student = context.Students.FirstOrDefault(x => x.Id == studentId && !x.IsDeleted)
                          ?? throw new InvalidOperationException("Hoc vien khong ton tai.");
            var relativePath = AppPaths.SaveImage(sourceImagePath, "Students", studentId);
            student.AvatarPath = relativePath;
            context.SaveChanges();
            return relativePath;
        }
        catch (Exception exception)
        {
            ErrorLogger.Log(exception, "SaveStudentAvatar");
            throw;
        }
    }

    public string SaveTeacherAvatar(string teacherId, string sourceImagePath)
    {
        try
        {
            using var context = CreateContext();
            var teacher = context.Teachers.FirstOrDefault(x => x.Id == teacherId && !x.IsDeleted)
                          ?? throw new InvalidOperationException("Giao vien khong ton tai.");
            var relativePath = AppPaths.SaveImage(sourceImagePath, "Teachers", teacherId);
            teacher.AvatarPath = relativePath;
            context.SaveChanges();
            return relativePath;
        }
        catch (Exception exception)
        {
            ErrorLogger.Log(exception, "SaveTeacherAvatar");
            throw;
        }
    }

    public string? ResolveAbsoluteImagePath(string? relativePath)
    {
        return AppPaths.ResolveAbsolutePath(relativePath);
    }

    public void ExportDatabaseScript(string outputPath)
    {
        try
        {
            using var context = CreateContext();
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);
            File.WriteAllText(outputPath, context.Database.GenerateCreateScript());
        }
        catch (Exception exception)
        {
            ErrorLogger.Log(exception, "ExportDatabaseScript");
            throw;
        }
    }

    private LanguageCenterDbContext CreateContext()
    {
        return new LanguageCenterDbContext(_options);
    }

    private void SeedData(LanguageCenterDbContext context)
    {
        if (context.Accounts.Any())
        {
            return;
        }

        var accounts = new[]
        {
            new AccountEntity
            {
                Id = "ACC001",
                Username = "admin",
                PasswordHash = PasswordHasher.Hash("123456"),
                DisplayName = "Admin Tong Quan",
                Email = "admin@ttnn.local",
                Phone = "0909000001",
                Role = AccountRole.Admin,
                Status = AccountStatus.Active,
                IsDeleted = false
            },
            new AccountEntity
            {
                Id = "ACC002",
                Username = "staff",
                PasswordHash = PasswordHasher.Hash("123456"),
                DisplayName = "Nhan Vien Van Hanh",
                Email = "staff@ttnn.local",
                Phone = "0909000002",
                Role = AccountRole.Staff,
                Status = AccountStatus.Active,
                IsDeleted = false
            },
            new AccountEntity
            {
                Id = "ACC003",
                Username = "teacher",
                PasswordHash = PasswordHasher.Hash("123456"),
                DisplayName = "Tran Minh An",
                Email = "teacher@ttnn.local",
                Phone = "0909000003",
                Role = AccountRole.Teacher,
                Status = AccountStatus.Active,
                IsDeleted = false
            }
        };

        var teachers = new[]
        {
            new TeacherEntity
            {
                Id = "GV001",
                FullName = "Tran Minh An",
                Phone = "0909000003",
                Email = "teacher@ttnn.local",
                Specialization = "IELTS",
                Gender = "Male",
                Address = "Da Nang",
                AccountId = "ACC003",
                Status = "Active",
                IsDeleted = false
            },
            new TeacherEntity
            {
                Id = "GV002",
                FullName = "Pham Thao Vy",
                Phone = "0909000004",
                Email = "vy@ttnn.local",
                Specialization = "TOEIC",
                Gender = "Female",
                Address = "Da Nang",
                Status = "Active",
                IsDeleted = false
            },
            new TeacherEntity
            {
                Id = "GV003",
                FullName = "Ngo Gia Hung",
                Phone = "0909000005",
                Email = "hung@ttnn.local",
                Specialization = "Tin hoc",
                Gender = "Male",
                Address = "Da Nang",
                Status = "Inactive",
                IsDeleted = false
            }
        };

        var courses = new[]
        {
            new CourseEntity
            {
                Id = "KH001",
                Name = "English Foundation",
                Description = "A1 co ban",
                TuitionFee = 2400000M,
                Status = "Active",
                IsDeleted = false
            },
            new CourseEntity
            {
                Id = "KH002",
                Name = "IELTS Intensive",
                Description = "Luyen thi IELTS 5.5+",
                TuitionFee = 6500000M,
                Status = "Active",
                IsDeleted = false
            },
            new CourseEntity
            {
                Id = "KH003",
                Name = "TOEIC But Pha",
                Description = "TOEIC 500+",
                TuitionFee = 3200000M,
                Status = "Active",
                IsDeleted = false
            }
        };

        var classes = new[]
        {
            new ClassEntity
            {
                Id = "LP001",
                Name = "ENG-A1-01",
                CourseId = "KH001",
                TeacherId = "GV001",
                StartDate = new DateTime(2026, 1, 5),
                EndDate = new DateTime(2026, 4, 30),
                Schedule = "2-4-6 18:00-19:30",
                Room = "P201",
                MaxStudents = 20,
                Status = "Open",
                IsDeleted = false
            },
            new ClassEntity
            {
                Id = "LP002",
                Name = "IELTS-24A",
                CourseId = "KH002",
                TeacherId = "GV001",
                StartDate = new DateTime(2026, 2, 10),
                EndDate = new DateTime(2026, 6, 30),
                Schedule = "3-5-7 18:00-19:30",
                Room = "P301",
                MaxStudents = 18,
                Status = "Open",
                IsDeleted = false
            },
            new ClassEntity
            {
                Id = "LP003",
                Name = "TOEIC-09B",
                CourseId = "KH003",
                TeacherId = "GV002",
                StartDate = new DateTime(2026, 3, 15),
                EndDate = new DateTime(2026, 7, 15),
                Schedule = "T7-CN 08:00-10:00",
                Room = "P105",
                MaxStudents = 20,
                Status = "Open",
                IsDeleted = false
            }
        };

        var students = new[]
        {
            new StudentEntity { Id = "HV001", FullName = "Nguyen Hai Dang", BirthDate = new DateTime(2010, 3, 12), Phone = "0909123456", Email = "dang@example.com", Address = "Da Nang", Status = "Active", IsDeleted = false },
            new StudentEntity { Id = "HV002", FullName = "Le Khanh Vy", BirthDate = new DateTime(2011, 7, 3), Phone = "0911222333", Email = "vy@example.com", Address = "Da Nang", Status = "Active", IsDeleted = false },
            new StudentEntity { Id = "HV003", FullName = "Tran Ngoc Han", BirthDate = new DateTime(2009, 11, 24), Phone = "0988777666", Email = "han@example.com", Address = "Da Nang", Status = "Paused", IsDeleted = false },
            new StudentEntity { Id = "HV004", FullName = "Phan Duc Minh", BirthDate = new DateTime(2012, 9, 15), Phone = "0977666555", Email = "minh@example.com", Address = "Da Nang", Status = "Active", IsDeleted = false },
            new StudentEntity { Id = "HV005", FullName = "Vu Gia Bao", BirthDate = new DateTime(2011, 1, 22), Phone = "0977222111", Email = "bao@example.com", Address = "Da Nang", Status = "Active", IsDeleted = false },
            new StudentEntity { Id = "HV006", FullName = "Hoang Gia Bich", BirthDate = new DateTime(2010, 5, 18), Phone = "0917111222", Email = "bich@example.com", Address = "Da Nang", Status = "Active", IsDeleted = false }
        };

        var enrollments = new[]
        {
            new EnrollmentEntity { Id = "GD001", StudentId = "HV001", ClassId = "LP001", EnrollDate = new DateTime(2026, 1, 6), Status = "Active", Note = "Dot 1", IsDeleted = false },
            new EnrollmentEntity { Id = "GD002", StudentId = "HV002", ClassId = "LP001", EnrollDate = new DateTime(2026, 1, 12), Status = "Active", Note = "Dong du", IsDeleted = false },
            new EnrollmentEntity { Id = "GD003", StudentId = "HV003", ClassId = "LP003", EnrollDate = new DateTime(2026, 3, 18), Status = "Paused", Note = "Bao luu 2 tuan", IsDeleted = false },
            new EnrollmentEntity { Id = "GD004", StudentId = "HV004", ClassId = "LP002", EnrollDate = new DateTime(2026, 2, 16), Status = "Active", Note = "", IsDeleted = false },
            new EnrollmentEntity { Id = "GD005", StudentId = "HV005", ClassId = "LP002", EnrollDate = new DateTime(2026, 2, 20), Status = "Active", Note = "", IsDeleted = false },
            new EnrollmentEntity { Id = "GD006", StudentId = "HV006", ClassId = "LP003", EnrollDate = new DateTime(2026, 4, 1), Status = "Active", Note = "", IsDeleted = false }
        };

        var receipts = new[]
        {
            new ReceiptEntity { Id = "PT001", EnrollmentId = "GD001", AmountPaid = 1500000M, PayDate = new DateTime(2026, 1, 6), PaymentMethod = "Cash", Note = "Dot 1", CreatedByStaffId = "ACC002", IsDeleted = false },
            new ReceiptEntity { Id = "PT002", EnrollmentId = "GD002", AmountPaid = 2400000M, PayDate = new DateTime(2026, 1, 12), PaymentMethod = "BankTransfer", Note = "Dong du", CreatedByStaffId = "ACC002", IsDeleted = false },
            new ReceiptEntity { Id = "PT003", EnrollmentId = "GD003", AmountPaid = 800000M, PayDate = new DateTime(2026, 3, 18), PaymentMethod = "Cash", Note = "Dot 1", CreatedByStaffId = "ACC002", IsDeleted = false },
            new ReceiptEntity { Id = "PT004", EnrollmentId = "GD004", AmountPaid = 5000000M, PayDate = new DateTime(2026, 2, 16), PaymentMethod = "BankTransfer", Note = "Dot 1", CreatedByStaffId = "ACC002", IsDeleted = false },
            new ReceiptEntity { Id = "PT005", EnrollmentId = "GD005", AmountPaid = 6500000M, PayDate = new DateTime(2026, 2, 20), PaymentMethod = "Cash", Note = "Dong du", CreatedByStaffId = "ACC002", IsDeleted = false },
            new ReceiptEntity { Id = "PT006", EnrollmentId = "GD006", AmountPaid = 2000000M, PayDate = new DateTime(2026, 4, 1), PaymentMethod = "BankTransfer", Note = "Dot 1", CreatedByStaffId = "ACC002", IsDeleted = false }
        };

        var attendances = new[]
        {
            new AttendanceEntity { Id = "DD001", EnrollmentId = "GD001", AttendanceDate = new DateTime(2026, 4, 20), Status = "Present", Note = "" },
            new AttendanceEntity { Id = "DD002", EnrollmentId = "GD002", AttendanceDate = new DateTime(2026, 4, 20), Status = "Late", Note = "Tre 10 phut" },
            new AttendanceEntity { Id = "DD003", EnrollmentId = "GD004", AttendanceDate = new DateTime(2026, 4, 21), Status = "Present", Note = "" }
        };

        var scores = new[]
        {
            new ScoreEntity { Id = "DS001", EnrollmentId = "GD001", MidtermScore = 8.5M, FinalScore = 9.0M, Note = "" },
            new ScoreEntity { Id = "DS002", EnrollmentId = "GD002", MidtermScore = 7.0M, FinalScore = 8.0M, Note = "" },
            new ScoreEntity { Id = "DS003", EnrollmentId = "GD004", MidtermScore = 8.0M, FinalScore = 8.5M, Note = "" }
        };

        context.Accounts.AddRange(accounts);
        context.Teachers.AddRange(teachers);
        context.Courses.AddRange(courses);
        context.Classes.AddRange(classes);
        context.Students.AddRange(students);
        context.Enrollments.AddRange(enrollments);
        context.Receipts.AddRange(receipts);
        context.Attendances.AddRange(attendances);
        context.Scores.AddRange(scores);
        context.SaveChanges();
    }

    private static bool ShouldSeedSampleData(LanguageCenterDbContext context)
    {
        return !context.Accounts.Any()
            && !context.Teachers.Any()
            && !context.Courses.Any()
            && !context.Classes.Any()
            && !context.Students.Any()
            && !context.Enrollments.Any()
            && !context.Receipts.Any()
            && !context.Attendances.Any()
            && !context.Scores.Any();
    }

    private DataTable BuildRevenueReportDetail(DateTime? fromDate, DateTime? toDate)
    {
        using var context = CreateContext();
        var start = fromDate?.Date ?? DateTime.MinValue;
        var end = toDate?.Date ?? DateTime.MaxValue;
        var table = CreateTable("Ngay phat sinh", "So bien nhan", "Hoc vien", "Lop", "Khoan thu", "So tien");

        var receipts = context.Receipts
            .AsNoTracking()
            .Include(x => x.Enrollment!).ThenInclude(x => x.Student)
            .Include(x => x.Enrollment!).ThenInclude(x => x.Class)
            .Where(x => !x.IsDeleted && x.PayDate.Date >= start && x.PayDate.Date <= end)
            .OrderBy(x => x.PayDate)
            .ToList();

        foreach (var receipt in receipts)
        {
            table.Rows.Add(
                receipt.PayDate.ToString("dd/MM/yyyy", _culture),
                receipt.Id,
                receipt.Enrollment?.Student?.FullName ?? string.Empty,
                receipt.Enrollment?.Class?.Name ?? string.Empty,
                receipt.Note ?? "Thu hoc phi",
                FormatMoney(receipt.AmountPaid));
        }

        return table;
    }

    private DataTable BuildEnrollmentReportDetail(DateTime? fromDate, DateTime? toDate)
    {
        using var context = CreateContext();
        var start = fromDate?.Date ?? DateTime.MinValue;
        var end = toDate?.Date ?? DateTime.MaxValue;
        var table = CreateTable("Ngay ghi danh", "Ma ghi danh", "Hoc vien", "Khoa hoc", "Lop", "Trang thai");

        var enrollments = context.Enrollments
            .AsNoTracking()
            .Include(x => x.Student)
            .Include(x => x.Class!).ThenInclude(x => x.Course)
            .Where(x => !x.IsDeleted && x.EnrollDate.Date >= start && x.EnrollDate.Date <= end)
            .OrderBy(x => x.EnrollDate)
            .ToList();

        foreach (var enrollment in enrollments)
        {
            table.Rows.Add(
                enrollment.EnrollDate.ToString("dd/MM/yyyy", _culture),
                enrollment.Id,
                enrollment.Student?.FullName ?? string.Empty,
                enrollment.Class?.Course?.Name ?? string.Empty,
                enrollment.Class?.Name ?? string.Empty,
                LanguageCenterValueMapper.ToEnrollmentStatusDisplay(enrollment.Status));
        }

        return table;
    }

    private DataTable BuildDebtReportDetail(DateTime? fromDate, DateTime? toDate)
    {
        var table = CreateTable("Ngay doi soat", "Hoc vien", "Lop", "Phai thu", "Da thu", "Con no", "Trang thai");
        using var context = CreateContext();
        var rows = BuildDebtRows(context);
        var start = fromDate?.Date ?? DateTime.MinValue;
        var end = toDate?.Date ?? DateTime.MaxValue;

        foreach (var row in rows.Where(x => x.ReferenceDate.Date >= start && x.ReferenceDate.Date <= end))
        {
            table.Rows.Add(
                row.ReferenceDate.ToString("dd/MM/yyyy", _culture),
                row.StudentName,
                row.ClassName,
                FormatMoney(row.RequiredAmount),
                FormatMoney(row.PaidAmount),
                FormatMoney(row.Outstanding),
                row.Status);
        }

        return table;
    }

    private List<DebtRow> BuildDebtRows(LanguageCenterDbContext context)
    {
        var enrollments = context.Enrollments
            .AsNoTracking()
            .Include(x => x.Student)
            .Include(x => x.Class!).ThenInclude(x => x.Course)
            .Include(x => x.Receipts)
            .Where(x => !x.IsDeleted)
            .ToList();

        return enrollments.Select(enrollment =>
        {
            var tuitionFee = enrollment.Class?.Course?.TuitionFee ?? 0M;
            var paidAmount = enrollment.Receipts.Where(x => !x.IsDeleted).Sum(x => x.AmountPaid);
            var outstanding = Math.Max(0, tuitionFee - paidAmount);
            var referenceDate = enrollment.Receipts
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.PayDate)
                .Select(x => x.PayDate)
                .FirstOrDefault();
            if (referenceDate == default)
            {
                referenceDate = enrollment.EnrollDate;
            }

            var status = outstanding <= 0
                ? "Da hoan thanh"
                : outstanding > tuitionFee / 2 ? "Qua han" : "Sap den han";

            return new DebtRow
            {
                StudentId = enrollment.Student?.Id ?? string.Empty,
                StudentName = enrollment.Student?.FullName ?? string.Empty,
                ClassName = enrollment.Class?.Name ?? string.Empty,
                CourseName = enrollment.Class?.Course?.Name ?? string.Empty,
                RequiredAmount = tuitionFee,
                PaidAmount = paidAmount,
                Outstanding = outstanding,
                Status = status,
                ReferenceDate = referenceDate
            };
        }).ToList();
    }

    private static string GetNextCode(IEnumerable<string> existingIds, string prefix)
    {
        var nextNumber = existingIds
            .Where(id => id.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            .Select(id => new string(id.Skip(prefix.Length).Where(char.IsDigit).ToArray()))
            .Where(value => int.TryParse(value, out _))
            .Select(int.Parse)
            .DefaultIfEmpty(0)
            .Max() + 1;

        return $"{prefix}{nextNumber:000}";
    }

    private string FormatMoney(decimal value)
    {
        return value.ToString("N0", _culture);
    }

    private static DataTable CreateTable(params string[] columns)
    {
        var table = new DataTable();
        foreach (var column in columns)
        {
            table.Columns.Add(column);
        }

        return table;
    }

    private static string ExtractCourseLevel(string courseName, string? description)
    {
        if (!string.IsNullOrWhiteSpace(description))
        {
            var parts = description.Split('|', 2, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 0)
            {
                return parts[0];
            }

            return description;
        }

        if (courseName.Contains("IELTS", StringComparison.OrdinalIgnoreCase))
        {
            return "IELTS 5.5+";
        }

        if (courseName.Contains("TOEIC", StringComparison.OrdinalIgnoreCase))
        {
            return "TOEIC 500+";
        }

        return "A1";
    }

    private static int GetActiveEnrollmentCount(ClassEntity classItem)
    {
        return classItem.Enrollments.Count(x => !x.IsDeleted && IsEnrollmentCountedAsActive(x.Status));
    }

    private static bool ClassHasAvailableSlot(ClassEntity classItem)
    {
        var normalizedStatus = LanguageCenterValueMapper.NormalizeClassStatus(classItem.Status);
        return normalizedStatus is "Open" or "InProgress" && GetActiveEnrollmentCount(classItem) < classItem.MaxStudents;
    }

    private static string GetEffectiveClassStatus(ClassEntity classItem)
    {
        var normalizedStatus = LanguageCenterValueMapper.NormalizeClassStatus(classItem.Status);

        if (normalizedStatus is "Closed" or "Completed" or "Cancelled" || classItem.EndDate.Date < DateTime.Today)
        {
            return "Da dong";
        }

        return GetActiveEnrollmentCount(classItem) >= classItem.MaxStudents
            ? "Day"
            : LanguageCenterValueMapper.ToClassStatusDisplay(normalizedStatus);
    }

    private static bool IsEnrollmentCountedAsActive(string? status)
    {
        var normalizedStatus = LanguageCenterValueMapper.NormalizeEnrollmentStatus(status);
        return normalizedStatus is "Active" or "Paused";
    }

    private static void ValidateStudent(StudentEntity student)
    {
        if (string.IsNullOrWhiteSpace(student.FullName))
        {
            throw new InvalidOperationException("Ten hoc vien khong duoc de trong.");
        }

        if (string.IsNullOrWhiteSpace(student.Phone))
        {
            throw new InvalidOperationException("So dien thoai khong duoc de trong.");
        }
    }

    private static void ValidateTeacher(TeacherEntity teacher)
    {
        if (string.IsNullOrWhiteSpace(teacher.FullName))
        {
            throw new InvalidOperationException("Ten giao vien khong duoc de trong.");
        }

        if (string.IsNullOrWhiteSpace(teacher.Phone))
        {
            throw new InvalidOperationException("So dien thoai khong duoc de trong.");
        }

        if (string.IsNullOrWhiteSpace(teacher.Email))
        {
            throw new InvalidOperationException("Email khong duoc de trong.");
        }
    }

    private static void ValidateCourse(CourseEntity course)
    {
        if (string.IsNullOrWhiteSpace(course.Name))
        {
            throw new InvalidOperationException("Ten khoa hoc khong duoc de trong.");
        }

        if (course.TuitionFee < 0)
        {
            throw new InvalidOperationException("Hoc phi phai lon hon hoac bang 0.");
        }
    }

    private static void ValidateClass(ClassEntity classEntity)
    {
        if (string.IsNullOrWhiteSpace(classEntity.Name))
        {
            throw new InvalidOperationException("Ten lop khong duoc de trong.");
        }

        if (classEntity.StartDate.Date > classEntity.EndDate.Date)
        {
            throw new InvalidOperationException("Ngay bat dau phai nho hon hoac bang ngay ket thuc.");
        }

        if (classEntity.MaxStudents <= 0)
        {
            throw new InvalidOperationException("Si so toi da phai lon hon 0.");
        }
    }

    private static void ValidateScore(decimal? score, string label)
    {
        if (score.HasValue && (score.Value < 0 || score.Value > 10))
        {
            throw new InvalidOperationException($"{label} phai nam trong khoang 0 den 10.");
        }
    }

    private static string ResolveCourseId(LanguageCenterDbContext context, string rawValue)
    {
        var normalized = rawValue.Trim();
        var course = context.Courses.FirstOrDefault(x => !x.IsDeleted && (x.Id == normalized || x.Name == normalized))
                     ?? throw new InvalidOperationException("Khong tim thay khoa hoc phu hop.");
        return course.Id;
    }

    private static string ResolveTeacherId(LanguageCenterDbContext context, string rawValue)
    {
        var normalized = rawValue.Trim();
        var teacher = context.Teachers.FirstOrDefault(x => !x.IsDeleted && (x.Id == normalized || x.FullName == normalized))
                      ?? throw new InvalidOperationException("Khong tim thay giao vien phu hop.");
        return teacher.Id;
    }

    private static string? ResolveTeacherIdByAccount(LanguageCenterDbContext context, string? teacherAccountId)
    {
        if (string.IsNullOrWhiteSpace(teacherAccountId))
        {
            return null;
        }

        return context.Teachers
            .Where(x => !x.IsDeleted && x.AccountId == teacherAccountId)
            .Select(x => x.Id)
            .FirstOrDefault();
    }

    private void SoftDeleteEntity<TEntity>(
        string id,
        Func<LanguageCenterDbContext, DbSet<TEntity>> setSelector,
        string contextName)
        where TEntity : class
    {
        try
        {
            using var context = CreateContext();
            var set = setSelector(context);
            var entity = set.FirstOrDefault(CreateIdPredicate<TEntity>(id))
                         ?? throw new InvalidOperationException("Khong tim thay du lieu can xoa.");

            var property = typeof(TEntity).GetProperty("IsDeleted")
                           ?? throw new InvalidOperationException("Entity khong ho tro soft-delete.");
            property.SetValue(entity, true);
            context.SaveChanges();
        }
        catch (Exception exception)
        {
            ErrorLogger.Log(exception, contextName);
            throw;
        }
    }

    private static System.Linq.Expressions.Expression<Func<TEntity, bool>> CreateIdPredicate<TEntity>(string id)
    {
        var parameter = System.Linq.Expressions.Expression.Parameter(typeof(TEntity), "entity");
        var property = System.Linq.Expressions.Expression.Property(parameter, "Id");
        var constant = System.Linq.Expressions.Expression.Constant(id);
        var equal = System.Linq.Expressions.Expression.Equal(property, constant);
        return System.Linq.Expressions.Expression.Lambda<Func<TEntity, bool>>(equal, parameter);
    }

    private sealed class DebtRow
    {
        public required string StudentId { get; init; }
        public required string StudentName { get; init; }
        public required string ClassName { get; init; }
        public required string CourseName { get; init; }
        public decimal RequiredAmount { get; init; }
        public decimal PaidAmount { get; init; }
        public decimal Outstanding { get; init; }
        public required string Status { get; init; }
        public DateTime ReferenceDate { get; init; }
    }
}
