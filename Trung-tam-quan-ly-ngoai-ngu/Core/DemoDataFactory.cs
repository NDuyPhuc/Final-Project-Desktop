using System.Data;

namespace Trung_tam_quan_ly_ngoai_ngu;

internal static class DemoDataFactory
{
    public static DataTable GetAccessMatrix() => CreateTable(
        ["Lĩnh vực chức năng", "Quản trị viên", "Nhân viên", "Giáo viên", "Thừa kế"],
        ["Quản lý người dùng", "●", "○", "○", "TOÀN CỤC"],
        ["Tài chính & Hóa đơn", "●", "●", "○", "FINANCE_DEPT"],
        ["Xử lý ghi danh", "●", "●", "○", "OPS_DEFAULT"],
        ["Nhật ký chuyên cần", "●", "●", "●", "PUBLIC_LOG"],
        ["Chấm điểm & Đánh giá", "●", "○", "●", "TEACHER_HUB"],
        ["Lập kế hoạch bài giảng", "●", "○", "●", "CURRICULUM"],
        ["Công cụ Marketing", "●", "●", "○", "KHÔNG"]);

    public static DataTable GetAdminWarnings() => CreateTable(
        ["Mức độ", "Nội dung", "Hạn xử lý"],
        ["Cao", "3 lớp sắp đầy sĩ số trong tuần này", "Hôm nay"],
        ["Trung bình", "5 học viên còn nợ học phí hơn 7 ngày", "Ngày mai"],
        ["Thấp", "2 tài khoản cần đổi mật khẩu mặc định", "Tuần này"]);

    public static DataTable GetMonitorActivity() => CreateTable(
        ["Phân hệ", "Chỉ số", "Giá trị", "Ghi chú"],
        ["Học viên", "Tăng mới", "24", "Tăng so với tuần trước"],
        ["Ghi danh", "Đang học", "126", "Bao gồm 8 ca bảo lưu"],
        ["Tài chính", "Biên nhận hôm nay", "18", "Do Staff lập"],
        ["Đào tạo", "Buổi học diễn ra", "9", "Có 1 lớp nghỉ"]);

    public static DataTable GetMonitorSource() => CreateTable(
        ["Nguồn dữ liệu", "Bản ghi", "Trạng thái"],
        ["Student", "245", "Ổn định"],
        ["Enrollment", "126", "Ổn định"],
        ["Receipt", "47", "Ổn định"],
        ["Attendance", "212", "Theo dõi"],
        ["Score", "88", "Theo dõi"]);

    public static DataTable GetAccountList() => CreateTable(
        ["Username", "Display Name", "Vai trò", "Trạng thái"],
        ["admin", "Quản trị hệ thống", "Admin", "Active"],
        ["staff.linh", "Nguyễn Linh", "Staff", "Active"],
        ["teacher.an", "Trần Minh An", "Teacher", "Active"],
        ["staff.hoa", "Lê Thanh Hoa", "Staff", "Inactive"]);

    public static DataTable GetRecentReceipts() => CreateTable(
        ["Số biên nhận", "Học viên", "Lớp", "Số tiền", "Ngày nộp"],
        ["PT001", "Nguyễn Hải Đăng", "ENG-A1-01", "1.500.000", "20/04/2026"],
        ["PT002", "Lê Khánh Vy", "ENG-KID-02", "1.200.000", "20/04/2026"],
        ["PT003", "Trần Ngọc Hân", "TIN-CB-03", "850.000", "19/04/2026"]);

    public static DataTable GetStudentList() => CreateTable(
        ["Mã học viên", "Họ tên", "Ngày sinh", "Điện thoại", "Trạng thái"],
        ["HV001", "Nguyễn Hải Đăng", "12/03/2010", "0909123456", "Đang học"],
        ["HV002", "Lê Khánh Vy", "03/07/2011", "0911222333", "Đang học"],
        ["HV003", "Trần Ngọc Hân", "24/11/2009", "0988777666", "Bảo lưu"],
        ["HV004", "Phan Đức Minh", "15/09/2012", "0977666555", "Ngừng học"]);

    public static DataTable GetTeacherList() => CreateTable(
        ["Mã giáo viên", "Họ tên", "Điện thoại", "Email", "Chuyên môn"],
        ["GV001", "Trần Minh An", "0909555888", "an.teacher@email.com", "IELTS"],
        ["GV002", "Phạm Thảo Vy", "0912444555", "vy.teacher@email.com", "Thiếu nhi"],
        ["GV003", "Ngô Gia Hưng", "0988333444", "hung.teacher@email.com", "Tin học"]);

    public static DataTable GetCourseList() => CreateTable(
        ["Mã khóa", "Tên khóa", "Level", "Học phí", "Trạng thái"],
        ["KH001", "English Foundation", "A1", "2.400.000", "Còn mở"],
        ["KH002", "English Kids Starter", "Kids", "2.100.000", "Còn mở"],
        ["KH003", "Tin học cơ bản", "Cơ bản", "1.800.000", "Tạm dừng"]);

    public static DataTable GetClassList() => CreateTable(
        ["Mã lớp", "Tên lớp", "Khóa học", "Giáo viên", "Lịch học", "Sĩ số", "Trạng thái"],
        ["LP001", "ENG-A1-01", "English Foundation", "Trần Minh An", "2-4-6", "18/20", "Đang mở"],
        ["LP002", "ENG-KID-02", "English Kids Starter", "Phạm Thảo Vy", "3-5-7", "20/20", "Đầy"],
        ["LP003", "TIN-CB-03", "Tin học cơ bản", "Ngô Gia Hưng", "T7-CN", "12/20", "Đang mở"]);

    public static DataTable GetClassStudents() => CreateTable(
        ["Mã học viên", "Họ tên", "Ngày ghi danh", "Trạng thái"],
        ["HV001", "Nguyễn Hải Đăng", "12/04/2026", "Đang học"],
        ["HV002", "Lê Khánh Vy", "13/04/2026", "Đang học"],
        ["HV003", "Trần Ngọc Hân", "14/04/2026", "Bảo lưu"]);

    public static DataTable GetSessions() => CreateTable(
        ["Buổi", "Ngày học", "Khung giờ", "Phòng", "Trạng thái"],
        ["Buổi 01", "21/04/2026", "18:00 - 19:30", "P201", "Sắp diễn ra"],
        ["Buổi 02", "23/04/2026", "18:00 - 19:30", "P201", "Đã tạo"],
        ["Buổi 03", "25/04/2026", "18:00 - 19:30", "P201", "Đã tạo"]);

    public static DataTable GetEnrollmentStudents() => CreateTable(
        ["Mã học viên", "Họ tên", "Điện thoại", "Trạng thái"],
        ["HV001", "Nguyễn Hải Đăng", "0909123456", "Mới"],
        ["HV002", "Lê Khánh Vy", "0911222333", "Đang học"],
        ["HV005", "Vũ Gia Bảo", "0977222111", "Tư vấn"]);

    public static DataTable GetEnrollmentClasses() => CreateTable(
        ["Mã lớp", "Tên lớp", "Lịch học", "Giáo viên", "Còn chỗ", "Học phí"],
        ["LP001", "ENG-A1-01", "2-4-6", "Trần Minh An", "2", "2.400.000"],
        ["LP003", "TIN-CB-03", "T7-CN", "Ngô Gia Hưng", "8", "1.800.000"]);

    public static DataTable GetReceiptHistory() => CreateTable(
        ["Số biên nhận", "Ngày nộp", "Phương thức", "Số tiền", "Ghi chú"],
        ["PT001", "10/04/2026", "Tiền mặt", "1.000.000", "Đợt 1"],
        ["PT004", "18/04/2026", "Chuyển khoản", "500.000", "Bổ sung"]);

    public static DataTable GetDebtList() => CreateTable(
        ["Học viên", "Lớp", "Khóa học", "Phải thu", "Đã thu", "Còn nợ", "Trạng thái"],
        ["Nguyễn Hải Đăng", "ENG-A1-01", "English Foundation", "2.400.000", "1.500.000", "900.000", "Còn nợ"],
        ["Trần Ngọc Hân", "TIN-CB-03", "Tin học cơ bản", "1.800.000", "800.000", "1.000.000", "Còn nợ"]);

    public static DataTable GetTeachingClasses() => CreateTable(
        ["Mã lớp", "Tên lớp", "Lịch học", "Số HV", "Buổi gần nhất", "Trạng thái"],
        ["LP001", "ENG-A1-01", "2-4-6", "18", "21/04/2026", "Đang dạy"],
        ["LP004", "ENG-IELTS-02", "3-5-7", "12", "22/04/2026", "Đang dạy"]);

    public static DataTable GetAttendanceList()
    {
        var table = new DataTable();
        table.Columns.Add("Mã học viên");
        table.Columns.Add("Họ tên");
        table.Columns.Add("Có mặt", typeof(bool));
        table.Columns.Add("Ghi chú");
        table.Rows.Add("HV001", "Nguyễn Hải Đăng", true, "");
        table.Rows.Add("HV002", "Lê Khánh Vy", true, "");
        table.Rows.Add("HV003", "Trần Ngọc Hân", false, "Xin nghỉ");
        return table;
    }

    public static DataTable GetScoreList() => CreateTable(
        ["Mã học viên", "Họ tên", "Điểm giữa kỳ", "Điểm cuối kỳ", "Ghi chú"],
        ["HV001", "Nguyễn Hải Đăng", "8.5", "9.0", ""],
        ["HV002", "Lê Khánh Vy", "7.5", "8.0", ""],
        ["HV003", "Trần Ngọc Hân", "6.5", "7.0", "Cần ôn thêm"]);

    public static DataTable GetReportDetail() => CreateTable(
        ["Tháng", "Doanh thu", "Ghi danh mới", "Học viên còn nợ"],
        ["01/2026", "42.000.000", "32", "11"],
        ["02/2026", "48.500.000", "39", "9"],
        ["03/2026", "51.300.000", "41", "7"],
        ["04/2026", "36.900.000", "28", "5"]);

    private static DataTable CreateTable(string[] columns, params object[][] rows)
    {
        var table = new DataTable();
        foreach (var column in columns)
        {
            table.Columns.Add(column);
        }

        foreach (var row in rows)
        {
            table.Rows.Add(row);
        }

        return table;
    }
}
