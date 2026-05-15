using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using TrungTamNgoaiNgu.Application.Contracts;
using TrungTamNgoaiNgu.Application.Localization;
using TrungTamNgoaiNgu.Application.Models;
using TrungTamNgoaiNgu.Application.Security;
using TrungTamNgoaiNgu.Domain.Entities;
using TrungTamNgoaiNgu.Domain.Enums;

namespace TrungTamNgoaiNgu.Application.Services;

public sealed class OfflineLanguageCenterDataService : ILanguageCenterDataService
{
    private static readonly Regex EnrollmentDiscountRegex = new(
        @"(?:Giảm trừ|Giam tru|Discount tu van)\s*:\s*([0-9][0-9\.,]*)",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private readonly List<AccountEntity> _accounts;
    private readonly List<StudentEntity> _students;
    private readonly List<TeacherEntity> _teachers;
    private readonly List<CourseEntity> _courses;
    private readonly List<ClassEntity> _classes;
    private readonly List<EnrollmentEntity> _enrollments;
    private readonly List<ReceiptEntity> _receipts;

    public OfflineLanguageCenterDataService()
    {
        var now = DateTime.Now;

        _accounts =
        [
            new AccountEntity
            {
                Id = "TK001",
                Username = "admin",
                PasswordHash = PasswordHasher.Hash("123456"),
                DisplayName = "Admin Demo",
                Email = "admin@example.com",
                Phone = "0900000001",
                Role = AccountRole.Admin,
                Status = AccountStatus.Active,
                CreatedAt = now
            },
            new AccountEntity
            {
                Id = "TK002",
                Username = "staff",
                PasswordHash = PasswordHasher.Hash("123456"),
                DisplayName = "Staff Demo",
                Email = "staff@example.com",
                Phone = "0900000002",
                Role = AccountRole.Staff,
                Status = AccountStatus.Active,
                CreatedAt = now
            },
            new AccountEntity
            {
                Id = "TK003",
                Username = "teacher",
                PasswordHash = PasswordHasher.Hash("123456"),
                DisplayName = "Teacher Demo",
                Email = "teacher@example.com",
                Phone = "0900000003",
                Role = AccountRole.Teacher,
                Status = AccountStatus.Active,
                CreatedAt = now
            }
        ];

        _students =
        [
            new StudentEntity
            {
                Id = "HV001",
                FullName = "Nguyen Minh Anh",
                BirthDate = new DateTime(2010, 5, 12),
                Phone = "0911000001",
                Email = "minhanh@example.com",
                Address = "Ho Chi Minh City",
                CreatedAt = now
            },
            new StudentEntity
            {
                Id = "HV002",
                FullName = "Tran Gia Bao",
                BirthDate = new DateTime(2011, 8, 21),
                Phone = "0911000002",
                Email = "giabao@example.com",
                Address = "Ho Chi Minh City",
                CreatedAt = now
            }
        ];

        _teachers =
        [
            new TeacherEntity
            {
                Id = "GV001",
                FullName = "Teacher Demo",
                Phone = "0900000003",
                Email = "teacher@example.com",
                Specialization = "English Communication",
                AccountId = "TK003",
                CreatedAt = now
            }
        ];

        _courses =
        [
            new CourseEntity
            {
                Id = "KH001",
                Name = "English Foundation",
                Description = "Offline demo course",
                TuitionFee = 2500000,
                CreatedAt = now
            }
        ];

        _classes =
        [
            new ClassEntity
            {
                Id = "LP001",
                Name = "EF-01",
                CourseId = "KH001",
                TeacherId = "GV001",
                StartDate = DateTime.Today.AddDays(-7),
                EndDate = DateTime.Today.AddMonths(2),
                Schedule = "T2-T4-T6 18:00",
                Room = "A101",
                MaxStudents = 20,
                CreatedAt = now
            }
        ];

        _enrollments =
        [
            new EnrollmentEntity
            {
                Id = "GD001",
                StudentId = "HV001",
                ClassId = "LP001",
                EnrollDate = DateTime.Today.AddDays(-5),
                Status = "Active",
                CreatedAt = now
            },
            new EnrollmentEntity
            {
                Id = "GD002",
                StudentId = "HV002",
                ClassId = "LP001",
                EnrollDate = DateTime.Today.AddDays(-3),
                Status = "Active",
                CreatedAt = now
            }
        ];

        _receipts =
        [
            new ReceiptEntity
            {
                Id = "PT001",
                EnrollmentId = "GD001",
                AmountPaid = 1500000,
                PayDate = DateTime.Today.AddDays(-2),
                PaymentMethod = "Cash",
                Note = "Offline demo receipt",
                CreatedByStaffId = "TK002",
                CreatedAt = now
            }
        ];
    }

    public void EnsureDatabaseReady()
    {
    }

    public AccountEntity? Authenticate(string username, string password)
    {
        return _accounts.FirstOrDefault(account =>
            !account.IsDeleted &&
            account.Status == AccountStatus.Active &&
            string.Equals(account.Username, username, StringComparison.OrdinalIgnoreCase) &&
            PasswordHasher.Verify(password, account.PasswordHash));
    }

    public string GetNextAccountId() => GetNextCode(_accounts.Select(x => x.Id), "TK");
    public string GetNextStudentId() => GetNextCode(_students.Select(x => x.Id), "HV");
    public string GetNextTeacherId() => GetNextCode(_teachers.Select(x => x.Id), "GV");
    public string GetNextCourseId() => GetNextCode(_courses.Select(x => x.Id), "KH");
    public string GetNextClassId() => GetNextCode(_classes.Select(x => x.Id), "LP");
    public string GetNextEnrollmentId() => GetNextCode(_enrollments.Select(x => x.Id), "GD");
    public string GetNextReceiptId() => GetNextCode(_receipts.Select(x => x.Id), "PT");

    public IReadOnlyList<AccountEntity> GetAccounts() => _accounts.Where(x => !x.IsDeleted).ToList();

    public AccountEntity SaveAccount(AccountEntity account)
    {
        if (string.IsNullOrWhiteSpace(account.Id))
        {
            account.Id = GetNextAccountId();
        }

        var existing = _accounts.FirstOrDefault(x => x.Id == account.Id);

        if (existing is null)
        {
            if (string.IsNullOrWhiteSpace(account.PasswordHash))
            {
                account.PasswordHash = PasswordHasher.Hash("123456");
            }

            account.CreatedAt = account.CreatedAt == default ? DateTime.Now : account.CreatedAt;
            _accounts.Add(account);
            return account;
        }

        existing.Username = account.Username;
        if (!string.IsNullOrWhiteSpace(account.PasswordHash))
        {
            existing.PasswordHash = account.PasswordHash;
        }

        existing.DisplayName = account.DisplayName;
        existing.Email = account.Email;
        existing.Phone = account.Phone;
        existing.Role = account.Role;
        existing.Status = account.Status;
        existing.UpdatedAt = DateTime.Now;
        return existing;
    }

    public void ToggleAccountStatus(string accountId)
    {
        var account = _accounts.FirstOrDefault(x => x.Id == accountId);
        if (account is not null)
        {
            account.Status = account.Status == AccountStatus.Active ? AccountStatus.Inactive : AccountStatus.Active;
            account.UpdatedAt = DateTime.Now;
        }
    }

    public void ResetAccountPassword(string accountId, string newPassword)
    {
        var account = _accounts.FirstOrDefault(x => x.Id == accountId);
        if (account is not null)
        {
            account.PasswordHash = PasswordHasher.Hash(newPassword);
            account.UpdatedAt = DateTime.Now;
        }
    }

    public DataTable GetAccessMatrix()
    {
        var table = CreateTable("Lĩnh vực chức năng", "Admin", "Staff", "Teacher", "Phạm vi");
        table.Rows.Add("Quản lý tài khoản", "Có", "Không", "Không", "Hệ thống");
        table.Rows.Add("Thu học phí", "Xem", "Có", "Không", "Tài chính");
        table.Rows.Add("Điểm danh", "Xem", "Xem", "Có", "Giảng dạy");
        return table;
    }

    public DataTable GetAdminWarnings()
    {
        var table = CreateTable("Mức độ", "Nội dung", "Hạn xử lý");
        table.Rows.Add("Trung bình", "Đang chạy ở chế độ offline demo", "Kiểm tra SQL Server");
        return table;
    }

    public DataTable GetMonitorActivity()
    {
        var table = CreateTable("Phân hệ", "Chỉ số", "Giá trị", "Ghi chú");
        table.Rows.Add("Hệ thống", "Chế độ", "Offline", "Không cần SQL Server");
        table.Rows.Add("Học viên", "Số hồ sơ", _students.Count.ToString(), "Dữ liệu demo");
        table.Rows.Add("Tài chính", "Số biên lai", _receipts.Count.ToString(), "Dữ liệu demo");
        return table;
    }

    public DataTable GetMonitorDetailedLog()
    {
        var table = CreateTable("THOI GIAN", "DOI TUONG", "PHAN HE", "HANH DONG", "CHI TIET");
        table.Rows.Add(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), "OfflineRuntime", "System", "Fallback", "Ung dung dang su dung du lieu demo.");
        return table;
    }

    public DataTable GetAccountList()
    {
        var table = CreateTable("Ma", "Ten dang nhap", "Ho ten", "Vai tro", "Trang thai");
        foreach (var account in _accounts.Where(x => !x.IsDeleted))
        {
            table.Rows.Add(account.Id, account.Username, account.DisplayName, account.Role.ToString(), account.Status.ToString());
        }

        return table;
    }

    public DataTable GetRecentReceipts()
    {
        var table = CreateTable("Ma bien lai", "Hoc vien", "Lop", "So tien", "Ngay thu");
        foreach (var receipt in _receipts.OrderByDescending(x => x.PayDate))
        {
            var enrollment = _enrollments.First(x => x.Id == receipt.EnrollmentId);
            var student = _students.First(x => x.Id == enrollment.StudentId);
            var classEntity = _classes.First(x => x.Id == enrollment.ClassId);
            table.Rows.Add(receipt.Id, student.FullName, classEntity.Name, receipt.AmountPaid.ToString("N0"), receipt.PayDate.ToString("dd/MM/yyyy"));
        }

        return table;
    }

    public DataTable GetStudentList(string? keyword = null, string? status = null)
    {
        var table = CreateTable("Ma hoc vien", "Ho ten", "Dien thoai", "Email", "Trang thai");
        foreach (var student in FilterStudents(keyword, status))
        {
            table.Rows.Add(student.Id, student.FullName, student.Phone, student.Email ?? string.Empty, student.Status);
        }

        return table;
    }

    public DataTable GetTeacherList(string? keyword = null, string? status = null)
    {
        var table = CreateTable("Ma giao vien", "Ho ten", "Dien thoai", "Email", "Trang thai");
        foreach (var teacher in _teachers.Where(x => !x.IsDeleted && MatchKeyword($"{x.Id} {x.FullName} {x.Email}", keyword) && MatchStatus(x.Status, status)))
        {
            table.Rows.Add(teacher.Id, teacher.FullName, teacher.Phone, teacher.Email, teacher.Status);
        }

        return table;
    }

    public DataTable GetCourseList(string? keyword = null, string? status = null)
    {
        var table = CreateTable("Ma khoa hoc", "Ten khoa hoc", "Hoc phi", "Trang thai");
        foreach (var course in _courses.Where(x => !x.IsDeleted && MatchKeyword($"{x.Id} {x.Name}", keyword) && MatchStatus(x.Status, status)))
        {
            table.Rows.Add(course.Id, course.Name, course.TuitionFee.ToString("N0"), course.Status);
        }

        return table;
    }

    public DataTable GetClassList(string? keyword = null, string? status = null, string? courseId = null)
    {
        var table = CreateTable("Ma lop", "Ten lop", "Khoa hoc", "Giao vien", "Lich hoc", "Trang thai");
        foreach (var classEntity in _classes.Where(x =>
                     !x.IsDeleted &&
                     MatchKeyword($"{x.Id} {x.Name}", keyword) &&
                     MatchStatus(x.Status, status) &&
                     (string.IsNullOrWhiteSpace(courseId) || x.CourseId == courseId)))
        {
            table.Rows.Add(
                classEntity.Id,
                classEntity.Name,
                _courses.FirstOrDefault(x => x.Id == classEntity.CourseId)?.Name ?? string.Empty,
                _teachers.FirstOrDefault(x => x.Id == classEntity.TeacherId)?.FullName ?? string.Empty,
                classEntity.Schedule ?? string.Empty,
                classEntity.Status);
        }

        return table;
    }

    public DataTable GetClassStudents(string? classId = null)
    {
        var table = CreateTable("Ma ghi danh", "Ma hoc vien", "Hoc vien", "Lop", "Trang thai");
        foreach (var enrollment in _enrollments.Where(x => string.IsNullOrWhiteSpace(classId) || x.ClassId == classId))
        {
            var student = _students.First(x => x.Id == enrollment.StudentId);
            var classEntity = _classes.First(x => x.Id == enrollment.ClassId);
            table.Rows.Add(enrollment.Id, student.Id, student.FullName, classEntity.Name, enrollment.Status);
        }

        return table;
    }

    public DataTable GetSessions(string? classId = null)
    {
        var table = CreateTable("Buoi", "Ngay hoc", "Khung gio", "Phong", "Trang thai");
        var classes = _classes
            .Where(x => !x.IsDeleted && (string.IsNullOrWhiteSpace(classId) || x.Id == classId))
            .OrderBy(x => x.Name)
            .ToList();

        foreach (var classEntity in classes)
        {
            var scheduleDays = ParseScheduleDays(classEntity.Schedule, classEntity.StartDate.DayOfWeek);
            var sessionDates = new List<DateTime>();
            for (var current = classEntity.StartDate.Date; current <= classEntity.EndDate.Date; current = current.AddDays(1))
            {
                if (scheduleDays.Contains(current.DayOfWeek))
                {
                    sessionDates.Add(current);
                }
            }

            if (sessionDates.Count == 0)
            {
                sessionDates.Add(classEntity.StartDate.Date);
            }

            for (var index = 0; index < sessionDates.Count; index++)
            {
                var sessionDate = sessionDates[index];
                var status = sessionDate.Date < DateTime.Today
                    ? "Đã học"
                    : sessionDate.Date == DateTime.Today ? "Hôm nay" : "Sắp diễn ra";

                table.Rows.Add(
                    $"Buổi {index + 1:00}",
                    sessionDate.ToString("dd/MM/yyyy"),
                    classEntity.Schedule ?? "18:00 - 19:30",
                    classEntity.Room ?? "P101",
                    status);
            }
        }

        return table;
    }

    public DataTable GetEnrollmentStudents(string? keyword = null)
    {
        return GetStudentList(keyword, "Active");
    }

    public DataTable GetEnrollmentClasses(string? courseId = null, bool onlyAvailable = true)
    {
        var table = CreateTable("Ma lop", "Ten lop", "Khoa hoc", "Giao vien", "Lich hoc", "Con cho", "Hoc phi");
        foreach (var classEntity in _classes.Where(x => string.IsNullOrWhiteSpace(courseId) || x.CourseId == courseId))
        {
            var usedSlots = _enrollments.Count(x => x.ClassId == classEntity.Id && !x.IsDeleted && string.Equals(x.Status, "Active", StringComparison.OrdinalIgnoreCase));
            var available = Math.Max(0, classEntity.MaxStudents - usedSlots);
            if (onlyAvailable && available <= 0)
            {
                continue;
            }

            table.Rows.Add(
                classEntity.Id,
                classEntity.Name,
                _courses.FirstOrDefault(x => x.Id == classEntity.CourseId)?.Name ?? string.Empty,
                _teachers.FirstOrDefault(x => x.Id == classEntity.TeacherId)?.FullName ?? string.Empty,
                classEntity.Schedule ?? string.Empty,
                available.ToString(),
                (_courses.FirstOrDefault(x => x.Id == classEntity.CourseId)?.TuitionFee ?? 0M).ToString("N0"));
        }

        return table;
    }

    public DataTable GetReceiptHistory(string? enrollmentId = null, string? studentId = null)
    {
        var table = CreateTable("Ma bien lai", "Ma ghi danh", "Hoc vien", "So tien", "Ngay thu");
        foreach (var receipt in _receipts.Where(x =>
                     string.IsNullOrWhiteSpace(enrollmentId) || x.EnrollmentId == enrollmentId))
        {
            var enrollment = _enrollments.First(x => x.Id == receipt.EnrollmentId);
            if (!string.IsNullOrWhiteSpace(studentId) && enrollment.StudentId != studentId)
            {
                continue;
            }

            var student = _students.First(x => x.Id == enrollment.StudentId);
            table.Rows.Add(receipt.Id, enrollment.Id, student.FullName, receipt.AmountPaid.ToString("N0"), receipt.PayDate.ToString("dd/MM/yyyy"));
        }

        return table;
    }

    public DataTable GetDebtList(string? courseName = null, string? className = null, DateTime? fromDate = null, DateTime? toDate = null)
    {
        var table = CreateTable("EnrollmentId", "Ma hoc vien", "Hoc vien", "Lop", "Khoa hoc", "Phai thu", "Da thu", "Con no", "Trang thai");
        var start = fromDate?.Date ?? DateTime.MinValue;
        var end = toDate?.Date ?? DateTime.MaxValue;

        foreach (var enrollment in _enrollments)
        {
            var student = _students.First(x => x.Id == enrollment.StudentId);
            var classEntity = _classes.First(x => x.Id == enrollment.ClassId);
            var course = _courses.First(x => x.Id == classEntity.CourseId);
            var totalPaid = _receipts.Where(x => x.EnrollmentId == enrollment.Id).Sum(x => x.AmountPaid);
            var tuitionFee = GetEffectiveTuitionFee(enrollment);
            var outstanding = Math.Max(0, tuitionFee - totalPaid);
            var referenceDate = _receipts
                .Where(x => x.EnrollmentId == enrollment.Id && !x.IsDeleted)
                .OrderByDescending(x => x.PayDate)
                .Select(x => x.PayDate)
                .FirstOrDefault();
            if (referenceDate == default)
            {
                referenceDate = enrollment.EnrollDate;
            }

            if (outstanding <= 0)
            {
                continue;
            }

            if (referenceDate.Date < start || referenceDate.Date > end)
            {
                continue;
            }

            if (!string.IsNullOrWhiteSpace(courseName) && !course.Name.Contains(courseName, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            if (!string.IsNullOrWhiteSpace(className) && !classEntity.Name.Contains(className, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            var status = outstanding > tuitionFee / 2 ? "Quá hạn" : "Sắp đến hạn";
            table.Rows.Add(
                enrollment.Id,
                student.Id,
                student.FullName,
                classEntity.Name,
                course.Name,
                tuitionFee.ToString("N0"),
                totalPaid.ToString("N0"),
                outstanding.ToString("N0"),
                status);
        }

        return table;
    }

    public DataTable GetTeachingClasses(string? teacherAccountId = null)
    {
        var teacherId = _teachers.FirstOrDefault(x => x.AccountId == teacherAccountId)?.Id;
        var table = CreateTable("Ma lop", "Ten lop", "Khoa hoc", "Lich hoc", "Si so", "Trang thai", "Thao tac");
        foreach (var classEntity in _classes.Where(x => string.IsNullOrWhiteSpace(teacherId) || x.TeacherId == teacherId))
        {
            var classSize = $"{_enrollments.Count(x => x.ClassId == classEntity.Id && IsEnrollmentCountedAsActive(x.Status))}/{classEntity.MaxStudents}";
            table.Rows.Add(
                classEntity.Id,
                classEntity.Name,
                _courses.FirstOrDefault(x => x.Id == classEntity.CourseId)?.Name ?? string.Empty,
                classEntity.Schedule ?? string.Empty,
                classSize,
                classEntity.Status,
                string.Empty);
        }

        return table;
    }

    public DataTable GetAttendanceList(string? classId = null, DateTime? attendanceDate = null)
    {
        var table = CreateTable("Ma ghi danh", "Hoc vien", "Ngay", "Trang thai", "Ghi chu");
        foreach (var enrollment in _enrollments.Where(x => string.IsNullOrWhiteSpace(classId) || x.ClassId == classId))
        {
            var student = _students.First(x => x.Id == enrollment.StudentId);
            table.Rows.Add(enrollment.Id, student.FullName, (attendanceDate ?? DateTime.Today).ToString("dd/MM/yyyy"), "Present", string.Empty);
        }

        return table;
    }

    public DataTable GetScoreList(string? classId = null)
    {
        var table = CreateTable("Ma ghi danh", "Hoc vien", "Giua ky", "Cuoi ky", "Ghi chu");
        foreach (var enrollment in _enrollments.Where(x => string.IsNullOrWhiteSpace(classId) || x.ClassId == classId))
        {
            var student = _students.First(x => x.Id == enrollment.StudentId);
            table.Rows.Add(enrollment.Id, student.FullName, "8.0", "8.5", "Demo");
        }

        return table;
    }

    public DataTable GetReportDetail(string reportType = "Doanh thu tong hop", DateTime? fromDate = null, DateTime? toDate = null)
    {
        var table = CreateTable("Bao cao", "Gia tri", "Ghi chu");
        table.Rows.Add(reportType, _receipts.Sum(x => x.AmountPaid).ToString("N0"), "Offline demo");
        return table;
    }

    public DashboardStats GetAdminDashboardStats()
    {
        return new DashboardStats
        {
            TotalStaff = _accounts.Count(x => x.Role == AccountRole.Staff && !x.IsDeleted),
            TotalTeachers = _teachers.Count(x => !x.IsDeleted),
            TotalActiveClasses = _classes.Count(x => !x.IsDeleted && string.Equals(x.Status, "Open", StringComparison.OrdinalIgnoreCase)),
            TotalStudents = _students.Count(x => !x.IsDeleted),
            TotalReceipts = _receipts.Count(x => !x.IsDeleted),
            TotalRevenue = _receipts.Where(x => !x.IsDeleted).Sum(x => x.AmountPaid),
            TotalDebt = GetOutstandingTotal(),
            NewStudentsThisMonth = _students.Count(x => x.CreatedAt.Month == DateTime.Now.Month && x.CreatedAt.Year == DateTime.Now.Year)
        };
    }

    public DashboardStats GetStaffDashboardStats()
    {
        var adminStats = GetAdminDashboardStats();
        return new DashboardStats
        {
            TotalActiveClasses = adminStats.TotalActiveClasses,
            TotalReceipts = adminStats.TotalReceipts,
            NewStudentsThisMonth = adminStats.NewStudentsThisMonth,
            TotalDebt = adminStats.TotalDebt
        };
    }

    public TeacherDashboardStats GetTeacherDashboardStats(string? teacherAccountId = null)
    {
        var teacherId = _teachers.FirstOrDefault(x => x.AccountId == teacherAccountId)?.Id;
        var classes = _classes.Where(x => string.IsNullOrWhiteSpace(teacherId) || x.TeacherId == teacherId).ToList();

        return new TeacherDashboardStats
        {
            TeachingClassCount = classes.Count,
            TeachingStudentCount = _enrollments.Count(x => classes.Any(c => c.Id == x.ClassId)),
            TodaySessionCount = classes.Count,
            PendingScoreCount = _enrollments.Count(x => classes.Any(c => c.Id == x.ClassId))
        };
    }

    public IReadOnlyList<ReportPoint> GetMonthlyRevenue(DateTime? fromDate = null, DateTime? toDate = null)
    {
        return
        [
            new ReportPoint { Label = "T1", Value = 1200000 },
            new ReportPoint { Label = "T2", Value = 1800000 },
            new ReportPoint { Label = "T3", Value = 1500000 }
        ];
    }

    public IReadOnlyList<ReportPoint> GetMonthlyEnrollmentCounts(DateTime? fromDate = null, DateTime? toDate = null)
    {
        return
        [
            new ReportPoint { Label = "T1", Value = 8 },
            new ReportPoint { Label = "T2", Value = 10 },
            new ReportPoint { Label = "T3", Value = 12 }
        ];
    }

    public StudentEntity? GetStudentById(string studentId) => _students.FirstOrDefault(x => x.Id == studentId);
    public TeacherEntity? GetTeacherById(string teacherId) => _teachers.FirstOrDefault(x => x.Id == teacherId);
    public CourseEntity? GetCourseById(string courseId) => _courses.FirstOrDefault(x => x.Id == courseId);
    public ClassEntity? GetClassById(string classId) => _classes.FirstOrDefault(x => x.Id == classId);
    public EnrollmentEntity? GetEnrollmentById(string enrollmentId) => _enrollments.FirstOrDefault(x => x.Id == enrollmentId);
    public ReceiptEntity? GetReceiptById(string receiptId) => _receipts.FirstOrDefault(x => x.Id == receiptId);

    public StudentEntity SaveStudent(StudentEntity student)
    {
        var existing = _students.FirstOrDefault(x => x.Id == student.Id);
        if (existing is null)
        {
            student.Id = string.IsNullOrWhiteSpace(student.Id) ? GetNextStudentId() : student.Id;
            student.CreatedAt = student.CreatedAt == default ? DateTime.Now : student.CreatedAt;
            _students.Add(student);
            return student;
        }

        existing.FullName = student.FullName;
        existing.BirthDate = student.BirthDate;
        existing.Phone = student.Phone;
        existing.Email = student.Email;
        existing.Address = student.Address;
        existing.AvatarPath = student.AvatarPath;
        existing.Status = student.Status;
        existing.UpdatedAt = DateTime.Now;
        return existing;
    }

    public TeacherEntity SaveTeacher(TeacherEntity teacher)
    {
        teacher.Gender = LanguageCenterValueMapper.NormalizeTeacherGender(teacher.Gender);
        var existing = _teachers.FirstOrDefault(x => x.Id == teacher.Id);
        if (existing is null)
        {
            teacher.Id = string.IsNullOrWhiteSpace(teacher.Id) ? GetNextTeacherId() : teacher.Id;
            teacher.CreatedAt = teacher.CreatedAt == default ? DateTime.Now : teacher.CreatedAt;
            _teachers.Add(teacher);
            return teacher;
        }

        existing.FullName = teacher.FullName;
        existing.Phone = teacher.Phone;
        existing.Email = teacher.Email;
        existing.Specialization = teacher.Specialization;
        existing.Gender = teacher.Gender;
        existing.Address = teacher.Address;
        existing.AvatarPath = teacher.AvatarPath;
        existing.Status = teacher.Status;
        existing.AccountId = teacher.AccountId;
        existing.UpdatedAt = DateTime.Now;
        return existing;
    }

    public CourseEntity SaveCourse(CourseEntity course)
    {
        var existing = _courses.FirstOrDefault(x => x.Id == course.Id);
        if (existing is null)
        {
            course.Id = string.IsNullOrWhiteSpace(course.Id) ? GetNextCourseId() : course.Id;
            course.CreatedAt = course.CreatedAt == default ? DateTime.Now : course.CreatedAt;
            _courses.Add(course);
            return course;
        }

        existing.Name = course.Name;
        existing.Description = course.Description;
        existing.TuitionFee = course.TuitionFee;
        existing.Status = course.Status;
        existing.UpdatedAt = DateTime.Now;
        return existing;
    }

    public ClassEntity SaveClass(ClassEntity classEntity)
    {
        var existing = _classes.FirstOrDefault(x => x.Id == classEntity.Id);
        if (existing is null)
        {
            classEntity.Id = string.IsNullOrWhiteSpace(classEntity.Id) ? GetNextClassId() : classEntity.Id;
            classEntity.CreatedAt = classEntity.CreatedAt == default ? DateTime.Now : classEntity.CreatedAt;
            _classes.Add(classEntity);
            return classEntity;
        }

        existing.Name = classEntity.Name;
        existing.CourseId = classEntity.CourseId;
        existing.TeacherId = classEntity.TeacherId;
        existing.StartDate = classEntity.StartDate;
        existing.EndDate = classEntity.EndDate;
        existing.Schedule = classEntity.Schedule;
        existing.Room = classEntity.Room;
        existing.MaxStudents = classEntity.MaxStudents;
        existing.Status = classEntity.Status;
        existing.UpdatedAt = DateTime.Now;
        return existing;
    }

    public void SoftDeleteStudent(string studentId)
    {
        var student = _students.FirstOrDefault(x => x.Id == studentId);
        if (student is not null)
        {
            student.IsDeleted = true;
        }
    }

    public void SoftDeleteTeacher(string teacherId)
    {
        var teacher = _teachers.FirstOrDefault(x => x.Id == teacherId);
        if (teacher is not null)
        {
            teacher.IsDeleted = true;
        }
    }

    public void SoftDeleteCourse(string courseId)
    {
        var course = _courses.FirstOrDefault(x => x.Id == courseId);
        if (course is not null)
        {
            course.IsDeleted = true;
        }
    }

    public void SoftDeleteClass(string classId)
    {
        var classEntity = _classes.FirstOrDefault(x => x.Id == classId);
        if (classEntity is not null)
        {
            classEntity.IsDeleted = true;
        }
    }

    public EnrollmentEntity CreateEnrollment(string studentId, string classId, DateTime enrollDate, string status, string? note)
    {
        if (_students.All(x => x.Id != studentId || x.IsDeleted))
        {
            throw new InvalidOperationException("Học viên không tồn tại.");
        }

        if (_classes.All(x => x.Id != classId || x.IsDeleted))
        {
            throw new InvalidOperationException("Lớp học không tồn tại.");
        }

        if (StudentAlreadyEnrolled(studentId, classId))
        {
            throw new InvalidOperationException("Học viên đã tồn tại trong lớp này.");
        }

        if (!ClassHasAvailableSlot(classId))
        {
            throw new InvalidOperationException("Lớp học đã hết chỗ.");
        }

        var enrollment = new EnrollmentEntity
        {
            Id = GetNextEnrollmentId(),
            StudentId = studentId,
            ClassId = classId,
            EnrollDate = enrollDate,
            Status = LanguageCenterValueMapper.NormalizeEnrollmentStatus(status),
            Note = note?.Trim(),
            CreatedAt = DateTime.Now
        };
        _enrollments.Add(enrollment);
        enrollment.Status = LanguageCenterValueMapper.ToEnrollmentStatusDisplay(enrollment.Status);
        return enrollment;
    }

    public bool StudentAlreadyEnrolled(string studentId, string classId)
    {
        return _enrollments.Any(x => x.StudentId == studentId && x.ClassId == classId && !x.IsDeleted);
    }

    public bool ClassHasAvailableSlot(string classId)
    {
        var classEntity = _classes.FirstOrDefault(x => x.Id == classId);
        if (classEntity is null)
        {
            return false;
        }

        return _enrollments.Count(x => x.ClassId == classId && !x.IsDeleted && IsEnrollmentCountedAsActive(x.Status)) < classEntity.MaxStudents;
    }

    public EnrollmentReceiptContext? GetEnrollmentReceiptContext(string enrollmentId)
    {
        var enrollment = GetEnrollmentById(enrollmentId);
        if (enrollment is null)
        {
            return null;
        }

        return BuildEnrollmentReceiptContext(enrollment);
    }

    public EnrollmentReceiptContext? GetLatestEnrollmentReceiptContextByStudentId(string studentId)
    {
        var enrollment = _enrollments.LastOrDefault(x => x.StudentId == studentId && !x.IsDeleted);
        return enrollment is null ? null : BuildEnrollmentReceiptContext(enrollment);
    }

    public ReceiptEntity SaveReceipt(string? receiptId, string enrollmentId, decimal amountPaid, DateTime payDate, string paymentMethod, string? note, string? createdByStaffId)
    {
        if (amountPaid <= 0)
        {
            throw new InvalidOperationException("Số tiền thu phải lớn hơn 0.");
        }

        var enrollment = _enrollments.FirstOrDefault(x => x.Id == enrollmentId && !x.IsDeleted)
            ?? throw new InvalidOperationException("Ghi danh không tồn tại.");
        var tuitionFee = GetEffectiveTuitionFee(enrollment);
        var paidExcludingCurrent = _receipts
            .Where(x => !x.IsDeleted && x.EnrollmentId == enrollmentId && (string.IsNullOrWhiteSpace(receiptId) || x.Id != receiptId))
            .Sum(x => x.AmountPaid);
        if (paidExcludingCurrent + amountPaid > tuitionFee)
        {
            throw new InvalidOperationException("Số tiền thu vượt quá học phí còn lại của ghi danh.");
        }

        var receipt = string.IsNullOrWhiteSpace(receiptId)
            ? null
            : _receipts.FirstOrDefault(x => x.Id == receiptId);

        if (receipt is null)
        {
            receipt = new ReceiptEntity
            {
                Id = string.IsNullOrWhiteSpace(receiptId) ? GetNextReceiptId() : receiptId,
                EnrollmentId = enrollmentId,
                AmountPaid = amountPaid,
                PayDate = payDate.Date,
                PaymentMethod = LanguageCenterValueMapper.NormalizePaymentMethod(paymentMethod),
                Note = note?.Trim(),
                CreatedByStaffId = createdByStaffId,
                CreatedAt = DateTime.Now
            };
            _receipts.Add(receipt);
            return receipt;
        }

        receipt.AmountPaid = amountPaid;
        receipt.PayDate = payDate.Date;
        receipt.PaymentMethod = LanguageCenterValueMapper.NormalizePaymentMethod(paymentMethod);
        receipt.Note = note?.Trim();
        receipt.CreatedByStaffId = createdByStaffId;
        receipt.UpdatedAt = DateTime.Now;
        return receipt;
    }

    public ReceiptPrintInfo GetReceiptPrintInfo(string receiptId)
    {
        var receipt = _receipts.First(x => x.Id == receiptId);
        var enrollment = _enrollments.First(x => x.Id == receipt.EnrollmentId);
        var context = BuildEnrollmentReceiptContext(enrollment);
        var totalPaid = _receipts.Where(x => x.EnrollmentId == enrollment.Id && !x.IsDeleted).Sum(x => x.AmountPaid);

        return new ReceiptPrintInfo
        {
            ReceiptId = receipt.Id,
            StudentName = context.StudentName,
            StudentCode = context.StudentCode,
            ClassName = context.ClassName,
            CourseName = context.CourseName,
            TuitionFee = context.TuitionFee,
            AmountPaid = receipt.AmountPaid,
            TotalPaid = totalPaid,
            OutstandingBalance = Math.Max(0, context.TuitionFee - totalPaid),
            PayDate = receipt.PayDate,
            PaymentMethod = LanguageCenterValueMapper.ToPaymentMethodDisplay(receipt.PaymentMethod),
            Note = receipt.Note,
            StaffName = _accounts.FirstOrDefault(x => x.Id == receipt.CreatedByStaffId)?.DisplayName
        };
    }

    public void SaveAttendance(string classId, DateTime attendanceDate, IEnumerable<AttendanceSaveItem> items)
    {
    }

    public void SaveScores(string classId, IEnumerable<ScoreSaveItem> items)
    {
    }

    public string SaveStudentAvatar(string studentId, string sourceImagePath) => sourceImagePath;
    public string SaveTeacherAvatar(string teacherId, string sourceImagePath) => sourceImagePath;
    public string? ResolveAbsoluteImagePath(string? relativePath) => relativePath;

    public void ExportDatabaseScript(string outputPath)
    {
        File.WriteAllText(outputPath, "-- Offline mode: SQL script export unavailable in this session.");
    }

    private EnrollmentReceiptContext BuildEnrollmentReceiptContext(EnrollmentEntity enrollment)
    {
        var student = _students.First(x => x.Id == enrollment.StudentId);
        var classEntity = _classes.First(x => x.Id == enrollment.ClassId);
        var course = _courses.First(x => x.Id == classEntity.CourseId);
        var tuitionFee = GetEffectiveTuitionFee(enrollment);
        var totalPaid = _receipts.Where(x => x.EnrollmentId == enrollment.Id && !x.IsDeleted).Sum(x => x.AmountPaid);

        return new EnrollmentReceiptContext
        {
            EnrollmentId = enrollment.Id,
            StudentCode = student.Id,
            StudentName = student.FullName,
            ClassCode = classEntity.Id,
            ClassName = classEntity.Name,
            CourseName = course.Name,
            TuitionFee = tuitionFee,
            TotalPaid = totalPaid,
            OutstandingBalance = Math.Max(0, tuitionFee - totalPaid)
        };
    }

    private static bool IsEnrollmentCountedAsActive(string? status)
    {
        var normalizedStatus = LanguageCenterValueMapper.NormalizeEnrollmentStatus(status);
        return normalizedStatus is "Active" or "Paused";
    }

    private static HashSet<DayOfWeek> ParseScheduleDays(string? schedule, DayOfWeek fallbackDay)
    {
        var normalized = (schedule ?? string.Empty).ToLowerInvariant();
        var mappings = new Dictionary<string, DayOfWeek>
        {
            ["2"] = DayOfWeek.Monday,
            ["3"] = DayOfWeek.Tuesday,
            ["4"] = DayOfWeek.Wednesday,
            ["5"] = DayOfWeek.Thursday,
            ["6"] = DayOfWeek.Friday,
            ["7"] = DayOfWeek.Saturday,
            ["cn"] = DayOfWeek.Sunday,
            ["mon"] = DayOfWeek.Monday,
            ["wed"] = DayOfWeek.Wednesday,
            ["fri"] = DayOfWeek.Friday,
            ["thu 2"] = DayOfWeek.Monday,
            ["thu 3"] = DayOfWeek.Tuesday,
            ["thu 4"] = DayOfWeek.Wednesday,
            ["thu 5"] = DayOfWeek.Thursday,
            ["thu 6"] = DayOfWeek.Friday,
            ["thu 7"] = DayOfWeek.Saturday,
            ["thứ 2"] = DayOfWeek.Monday,
            ["thứ 3"] = DayOfWeek.Tuesday,
            ["thứ 4"] = DayOfWeek.Wednesday,
            ["thứ 5"] = DayOfWeek.Thursday,
            ["thứ 6"] = DayOfWeek.Friday,
            ["thứ 7"] = DayOfWeek.Saturday,
            ["t2"] = DayOfWeek.Monday,
            ["t3"] = DayOfWeek.Tuesday,
            ["t4"] = DayOfWeek.Wednesday,
            ["t5"] = DayOfWeek.Thursday,
            ["t6"] = DayOfWeek.Friday,
            ["t7"] = DayOfWeek.Saturday
        };

        var results = mappings
            .Where(x => normalized.Contains(x.Key))
            .Select(x => x.Value)
            .ToHashSet();

        if (results.Count == 0)
        {
            results.Add(fallbackDay);
        }

        return results;
    }

    private decimal GetEffectiveTuitionFee(EnrollmentEntity enrollment)
    {
        var classEntity = _classes.FirstOrDefault(x => x.Id == enrollment.ClassId);
        var course = classEntity is null ? null : _courses.FirstOrDefault(x => x.Id == classEntity.CourseId);
        var tuitionFee = course?.TuitionFee ?? 0M;
        var discount = GetEnrollmentDiscount(enrollment.Note);
        return Math.Max(0, tuitionFee - discount);
    }

    private static decimal GetEnrollmentDiscount(string? note)
    {
        if (string.IsNullOrWhiteSpace(note))
        {
            return 0M;
        }

        var match = EnrollmentDiscountRegex.Match(note);
        if (!match.Success)
        {
            return 0M;
        }

        var rawValue = match.Groups[1].Value
            .Replace(" ", string.Empty)
            .Replace(".", string.Empty)
            .Replace(",", string.Empty);

        return decimal.TryParse(rawValue, NumberStyles.Number, CultureInfo.InvariantCulture, out var discount)
            ? Math.Max(0, discount)
            : 0M;
    }

    private decimal GetOutstandingTotal()
    {
        return _enrollments.Sum(enrollment => BuildEnrollmentReceiptContext(enrollment).OutstandingBalance);
    }

    private IEnumerable<StudentEntity> FilterStudents(string? keyword, string? status)
    {
        return _students.Where(x => !x.IsDeleted && MatchKeyword($"{x.Id} {x.FullName} {x.Phone} {x.Email}", keyword) && MatchStatus(x.Status, status));
    }

    private static bool MatchKeyword(string value, string? keyword)
    {
        return string.IsNullOrWhiteSpace(keyword) || value.Contains(keyword, StringComparison.OrdinalIgnoreCase);
    }

    private static bool MatchStatus(string value, string? status)
    {
        return string.IsNullOrWhiteSpace(status) || string.Equals(value, status, StringComparison.OrdinalIgnoreCase);
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

    private static string GetNextCode(IEnumerable<string> existingIds, string prefix)
    {
        var max = existingIds
            .Where(id => id.StartsWith(prefix, StringComparison.OrdinalIgnoreCase) && id.Length > prefix.Length)
            .Select(id => int.TryParse(id[prefix.Length..], out var value) ? value : 0)
            .DefaultIfEmpty()
            .Max();

        return $"{prefix}{max + 1:000}";
    }
}
