using TrungTamNgoaiNgu.Domain.Enums;

namespace TrungTamNgoaiNgu.Application.Localization;

public static class LanguageCenterValueMapper
{
    public static string NormalizeCourseStatus(string? value) => value?.Trim() switch
    {
        null or "" => "Active",
        "Còn mở" or "Con mo" or "Active" => "Active",
        "Tạm dừng" or "Tam dung" or "Inactive" => "Inactive",
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
        "Đang học" or "Dang hoc" or "Active" => "Active",
        "Bảo lưu" or "Bao luu" or "Paused" => "Paused",
        "Tạm dừng" or "Tam dung" or "Inactive" => "Inactive",
        "Hoàn thành" or "Hoan thanh" or "Completed" => "Completed",
        "Đã nghỉ" or "Da nghi" or "Dropped" => "Dropped",
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
        "Đang dạy" or "Dang day" or "Active" => "Active",
        "Tạm nghỉ" or "Tam nghi" or "Inactive" => "Inactive",
        _ => value.Trim()
    };

    public static string ToTeacherStatusDisplay(string? value) => NormalizeTeacherStatus(value) switch
    {
        "Active" => "Đang dạy",
        "Inactive" => "Tạm nghỉ",
        var normalized => normalized
    };

    public static string? NormalizeTeacherGender(string? value)
    {
        var trimmed = value?.Trim();
        if (string.IsNullOrWhiteSpace(trimmed))
        {
            return null;
        }

        if (trimmed.Equals("Male", StringComparison.OrdinalIgnoreCase)
            || trimmed.Equals("Nam", StringComparison.OrdinalIgnoreCase))
        {
            return "Nam";
        }

        if (trimmed.Equals("Female", StringComparison.OrdinalIgnoreCase)
            || trimmed.Equals("Nữ", StringComparison.OrdinalIgnoreCase)
            || trimmed.Equals("Nu", StringComparison.OrdinalIgnoreCase))
        {
            return "Nữ";
        }

        if (trimmed.Equals("Other", StringComparison.OrdinalIgnoreCase)
            || trimmed.Equals("Khác", StringComparison.OrdinalIgnoreCase)
            || trimmed.Equals("Khac", StringComparison.OrdinalIgnoreCase))
        {
            return "Khác";
        }

        return trimmed;
    }

    public static string ToTeacherGenderDisplay(string? value) => NormalizeTeacherGender(value) switch
    {
        "Nam" => "Nam",
        "Nữ" => "Nữ",
        "Khác" => "Khác",
        _ => string.Empty
    };

    public static string NormalizeClassStatus(string? value) => value?.Trim() switch
    {
        null or "" => "Open",
        "Đang mở" or "Dang mo" or "Open" => "Open",
        "Đang học" or "Dang hoc" or "InProgress" => "InProgress",
        "Đã đóng" or "Da dong" or "Closed" => "Closed",
        "Hoàn thành" or "Hoan thanh" or "Completed" => "Completed",
        "Đã hủy" or "Da huy" or "Cancelled" => "Cancelled",
        "Đầy" or "Day" => "Open",
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
        "Đang học" or "Dang hoc" or "Active" => "Active",
        "Bảo lưu" or "Bao luu" or "Paused" => "Paused",
        "Hoàn thành" or "Hoan thanh" or "Completed" => "Completed",
        "Đã nghỉ" or "Da nghi" or "Dropped" => "Dropped",
        "Đã hủy" or "Da huy" or "Cancelled" => "Cancelled",
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
        "Tiền mặt" or "Tien mat" or "Cash" => "Cash",
        "Chuyển khoản" or "Chuyen khoan" or "BankTransfer" => "BankTransfer",
        "Thẻ" or "The" or "Card" => "Card",
        "Ví điện tử" or "Vi dien tu" or "EWallet" => "EWallet",
        "Khác" or "Khac" or "Other" => "Other",
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
        "Hoạt động" or "Hoat dong" or "Active" => AccountStatus.Active,
        "Tạm dừng" or "Tam dung" or "Inactive" => AccountStatus.Inactive,
        "Khóa" or "Khoa" or "Locked" => AccountStatus.Locked,
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
