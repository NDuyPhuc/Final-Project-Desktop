using TrungTamNgoaiNgu.Domain.Enums;

namespace TrungTamNgoaiNgu.Application.Localization;

public static class LanguageCenterValueMapper
{
    public static string NormalizeCourseStatus(string? value) => value?.Trim() switch
    {
        null or "" => "Active",
        "Con mo" or "Active" => "Active",
        "Tam dung" or "Inactive" => "Inactive",
        _ => value.Trim()
    };

    public static string ToCourseStatusDisplay(string? value) => NormalizeCourseStatus(value) switch
    {
        "Active" => "Con mo",
        "Inactive" => "Tam dung",
        var normalized => normalized
    };

    public static string NormalizeStudentStatus(string? value) => value?.Trim() switch
    {
        null or "" => "Active",
        "Dang hoc" or "Active" => "Active",
        "Bao luu" or "Paused" => "Paused",
        "Tam dung" or "Inactive" => "Inactive",
        "Hoan thanh" or "Completed" => "Completed",
        "Da nghi" or "Dropped" => "Dropped",
        _ => value.Trim()
    };

    public static string ToStudentStatusDisplay(string? value) => NormalizeStudentStatus(value) switch
    {
        "Active" => "Dang hoc",
        "Paused" => "Bao luu",
        "Inactive" => "Tam dung",
        "Completed" => "Hoan thanh",
        "Dropped" => "Da nghi",
        var normalized => normalized
    };

    public static string NormalizeTeacherStatus(string? value) => value?.Trim() switch
    {
        null or "" => "Active",
        "Dang day" or "Active" => "Active",
        "Tam nghi" or "Inactive" => "Inactive",
        _ => value.Trim()
    };

    public static string ToTeacherStatusDisplay(string? value) => NormalizeTeacherStatus(value) switch
    {
        "Active" => "Dang day",
        "Inactive" => "Tam nghi",
        var normalized => normalized
    };

    public static string NormalizeClassStatus(string? value) => value?.Trim() switch
    {
        null or "" => "Open",
        "Dang mo" or "Open" => "Open",
        "Dang hoc" or "InProgress" => "InProgress",
        "Da dong" or "Closed" => "Closed",
        "Hoan thanh" or "Completed" => "Completed",
        "Da huy" or "Cancelled" => "Cancelled",
        "Day" => "Open",
        _ => value.Trim()
    };

    public static string ToClassStatusDisplay(string? value) => NormalizeClassStatus(value) switch
    {
        "Open" => "Dang mo",
        "InProgress" => "Dang hoc",
        "Closed" => "Da dong",
        "Completed" => "Hoan thanh",
        "Cancelled" => "Da huy",
        var normalized => normalized
    };

    public static string NormalizeEnrollmentStatus(string? value) => value?.Trim() switch
    {
        null or "" => "Active",
        "Dang hoc" or "Active" => "Active",
        "Bao luu" or "Paused" => "Paused",
        "Hoan thanh" or "Completed" => "Completed",
        "Da nghi" or "Dropped" => "Dropped",
        "Da huy" or "Cancelled" => "Cancelled",
        _ => value.Trim()
    };

    public static string ToEnrollmentStatusDisplay(string? value) => NormalizeEnrollmentStatus(value) switch
    {
        "Active" => "Dang hoc",
        "Paused" => "Bao luu",
        "Completed" => "Hoan thanh",
        "Dropped" => "Da nghi",
        "Cancelled" => "Da huy",
        var normalized => normalized
    };

    public static string NormalizePaymentMethod(string? value) => value?.Trim() switch
    {
        null or "" => "Cash",
        "Tien mat" or "Cash" => "Cash",
        "Chuyen khoan" or "BankTransfer" => "BankTransfer",
        "The" or "Card" => "Card",
        "Vi dien tu" or "EWallet" => "EWallet",
        "Khac" or "Other" => "Other",
        _ => value.Trim()
    };

    public static string ToPaymentMethodDisplay(string? value) => NormalizePaymentMethod(value) switch
    {
        "Cash" => "Tien mat",
        "BankTransfer" => "Chuyen khoan",
        "Card" => "The",
        "EWallet" => "Vi dien tu",
        "Other" => "Khac",
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
