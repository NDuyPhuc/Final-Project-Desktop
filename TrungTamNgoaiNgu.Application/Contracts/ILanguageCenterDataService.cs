using System.Data;
using TrungTamNgoaiNgu.Application.Models;
using TrungTamNgoaiNgu.Domain.Entities;

namespace TrungTamNgoaiNgu.Application.Contracts;

public interface ILanguageCenterDataService
{
    void EnsureDatabaseReady();
    AccountEntity? Authenticate(string username, string password);
    string GetNextAccountId();
    string GetNextStudentId();
    string GetNextTeacherId();
    string GetNextCourseId();
    string GetNextClassId();
    string GetNextEnrollmentId();
    string GetNextReceiptId();

    IReadOnlyList<AccountEntity> GetAccounts();
    AccountEntity SaveAccount(AccountEntity account);
    void ToggleAccountStatus(string accountId);
    void ResetAccountPassword(string accountId, string newPassword);

    DataTable GetAccessMatrix();
    DataTable GetAdminWarnings();
    DataTable GetMonitorActivity();
    DataTable GetMonitorDetailedLog();
    DataTable GetAccountList();
    DataTable GetRecentReceipts();
    DataTable GetStudentList(string? keyword = null, string? status = null);
    DataTable GetTeacherList(string? keyword = null, string? status = null);
    DataTable GetCourseList(string? keyword = null, string? status = null);
    DataTable GetClassList(string? keyword = null, string? status = null, string? courseId = null);
    DataTable GetClassStudents(string? classId = null);
    DataTable GetSessions(string? classId = null);
    DataTable GetEnrollmentStudents(string? keyword = null);
    DataTable GetEnrollmentClasses(string? courseId = null, bool onlyAvailable = true);
    DataTable GetReceiptHistory(string? enrollmentId = null, string? studentId = null);
    DataTable GetDebtList(string? courseName = null, string? className = null, DateTime? fromDate = null, DateTime? toDate = null);
    DataTable GetTeachingClasses(string? teacherAccountId = null);
    DataTable GetAttendanceList(string? classId = null, DateTime? attendanceDate = null);
    DataTable GetScoreList(string? classId = null);
    DataTable GetReportDetail(string reportType = "Doanh thu tong hop", DateTime? fromDate = null, DateTime? toDate = null);

    DashboardStats GetAdminDashboardStats();
    DashboardStats GetStaffDashboardStats();
    TeacherDashboardStats GetTeacherDashboardStats(string? teacherAccountId = null);
    IReadOnlyList<ReportPoint> GetMonthlyRevenue(DateTime? fromDate = null, DateTime? toDate = null);
    IReadOnlyList<ReportPoint> GetMonthlyEnrollmentCounts(DateTime? fromDate = null, DateTime? toDate = null);

    StudentEntity? GetStudentById(string studentId);
    TeacherEntity? GetTeacherById(string teacherId);
    CourseEntity? GetCourseById(string courseId);
    ClassEntity? GetClassById(string classId);
    EnrollmentEntity? GetEnrollmentById(string enrollmentId);
    ReceiptEntity? GetReceiptById(string receiptId);

    StudentEntity SaveStudent(StudentEntity student);
    TeacherEntity SaveTeacher(TeacherEntity teacher);
    CourseEntity SaveCourse(CourseEntity course);
    ClassEntity SaveClass(ClassEntity classEntity);
    void SoftDeleteStudent(string studentId);
    void SoftDeleteTeacher(string teacherId);
    void SoftDeleteCourse(string courseId);
    void SoftDeleteClass(string classId);

    EnrollmentEntity CreateEnrollment(string studentId, string classId, DateTime enrollDate, string status, string? note);
    bool StudentAlreadyEnrolled(string studentId, string classId);
    bool ClassHasAvailableSlot(string classId);

    EnrollmentReceiptContext? GetEnrollmentReceiptContext(string enrollmentId);
    EnrollmentReceiptContext? GetLatestEnrollmentReceiptContextByStudentId(string studentId);
    ReceiptEntity SaveReceipt(
        string? receiptId,
        string enrollmentId,
        decimal amountPaid,
        DateTime payDate,
        string paymentMethod,
        string? note,
        string? createdByStaffId);
    ReceiptPrintInfo GetReceiptPrintInfo(string receiptId);

    void SaveAttendance(string classId, DateTime attendanceDate, IEnumerable<AttendanceSaveItem> items);
    void SaveScores(string classId, IEnumerable<ScoreSaveItem> items);

    string SaveStudentAvatar(string studentId, string sourceImagePath);
    string SaveTeacherAvatar(string teacherId, string sourceImagePath);
    string? ResolveAbsoluteImagePath(string? relativePath);

    void ExportDatabaseScript(string outputPath);
}
