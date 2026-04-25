using TrungTamNgoaiNgu.Domain.Enums;

namespace TrungTamNgoaiNgu.Application.Localization;

public static class LanguageCenterValueMapper
{
    public static string NormalizeCourseStatus(string? value) => value?.Trim() switch
    {
        null or "" => "Active",
        "Con mo" or "Còn mở" or "Active" => "Active",
        "Tam dung" or "Tạm dừng" or "Inactive" => "Inactive",
        _ => value.Trim()
    };

    public static string ToCourseStatusDisplay(string? value) => NormalizeCourseStatus(value) switch
    {
        "Active" => "Còn mở",
        "Inactive" => "Tạm dừng",
        var normalized => normalized
    };

    public static string NormalizeStudentStatus(string? value) => value?.Trim() switch
    {
        null or "" => "Active",
        "Dang hoc" or "Đang học" or "Active" => "Active",
        "Bao luu" or "Bảo lưu" or "Paused" => "Paused",
        "Tam dung" or "Tạm dừng" or "Inactive" => "Inactive",
        "Hoan thanh" or "Hoàn thành" or "Completed" => "Completed",
        "Da nghi" or "Đã nghỉ" or "Dropped" => "Dropped",
        _ => value.Trim()
    };

    public static string ToStudentStatusDisplay(string? value) => NormalizeStudentStatus(value) switch
    {
        "Active" => "Đang học",
        "Paused" => "Bảo lưu",
        "Inactive" => "Tạm dừng",
        "Completed" => "Hoàn thành",
        "Dropped" => "Đã nghỉ",
        var normalized => normalized
    };

    public static string NormalizeTeacherStatus(string? value) => value?.Trim() switch
    {
        null or "" => "Active",
        "Dang day" or "Đang dạy" or "Active" => "Active",
        "Tam nghi" or "Tạm nghỉ" or "Inactive" => "Inactive",
        _ => value.Trim()
    };

    public static string ToTeacherStatusDisplay(string? value) => NormalizeTeacherStatus(value) switch
    {
        "Active" => "Đang dạy",
        "Inactive" => "Tạm nghỉ",
        var normalized => normalized
    };

    public static string NormalizeClassStatus(string? value) => value?.Trim() switch
    {
        null or "" => "Open",
        "Dang mo" or "Đang mở" or "Open" => "Open",
        "Dang hoc" or "Đang học" or "InProgress" => "InProgress",
        "Da dong" or "Đã đóng" or "Closed" => "Closed",
        "Hoan thanh" or "Hoàn thành" or "Completed" => "Completed",
        "Da huy" or "Đã hủy" or "Cancelled" => "Cancelled",
        "Day" or "Đầy" => "Open",
        _ => value.Trim()
    };

    public static string ToClassStatusDisplay(string? value) => NormalizeClassStatus(value) switch
    {
        "Open" => "Đang mở",
        "InProgress" => "Đang học",
        "Closed" => "Đã đóng",
        "Completed" => "Hoàn thành",
        "Cancelled" => "Đã hủy",
        var normalized => normalized
    };

    public static string NormalizeEnrollmentStatus(string? value) => value?.Trim() switch
    {
        null or "" => "Active",
        "Dang hoc" or "Đang học" or "Active" => "Active",
        "Bao luu" or "Bảo lưu" or "Paused" => "Paused",
        "Hoan thanh" or "Hoàn thành" or "Completed" => "Completed",
        "Da nghi" or "Đã nghỉ" or "Dropped" => "Dropped",
        "Da huy" or "Đã hủy" or "Cancelled" => "Cancelled",
        _ => value.Trim()
    };

    public static string ToEnrollmentStatusDisplay(string? value) => NormalizeEnrollmentStatus(value) switch
    {
        "Active" => "Đang học",
        "Paused" => "Bảo lưu",
        "Completed" => "Hoàn thành",
        "Dropped" => "Đã nghỉ",
        "Cancelled" => "Đã hủy",
        var normalized => normalized
    };

    public static string NormalizePaymentMethod(string? value) => value?.Trim() switch
    {
        null or "" => "Cash",
        "Tien mat" or "Tiền mặt" or "Cash" => "Cash",
        "Chuyen khoan" or "Chuyển khoản" or "BankTransfer" => "BankTransfer",
        "The" or "Thẻ" or "Card" => "Card",
        "Vi dien tu" or "Ví điện tử" or "EWallet" => "EWallet",
        "Khac" or "Khác" or "Other" => "Other",
        _ => value.Trim()
    };

    public static string ToPaymentMethodDisplay(string? value) => NormalizePaymentMethod(value) switch
    {
        "Cash" => "Tiền mặt",
        "BankTransfer" => "Chuyển khoản",
        "Card" => "Thẻ",
        "EWallet" => "Ví điện tử",
        "Other" => "Khác",
        var normalized => normalized
    };

    public static AccountStatus NormalizeAccountStatus(string? value) => value?.Trim() switch
    {
        null or "" => AccountStatus.Active,
        "Hoat dong" or "Hoạt động" or "Active" => AccountStatus.Active,
        "Tam dung" or "Tạm dừng" or "Inactive" => AccountStatus.Inactive,
        "Khoa" or "Khóa" or "Locked" => AccountStatus.Locked,
        _ => Enum.TryParse<AccountStatus>(value, true, out var status) ? status : AccountStatus.Active
    };

    public static string ToAccountStatusDisplay(AccountStatus status) => status switch
    {
        AccountStatus.Active => "Hoạt động",
        AccountStatus.Inactive => "Tạm dừng",
        AccountStatus.Locked => "Khóa",
        _ => status.ToString()
    };
}
