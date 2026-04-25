namespace TrungTamNgoaiNgu.Application.Models;

public sealed class ReceiptPrintInfo
{
    public required string ReceiptId { get; init; }
    public required string StudentName { get; init; }
    public required string StudentCode { get; init; }
    public required string ClassName { get; init; }
    public required string CourseName { get; init; }
    public decimal TuitionFee { get; init; }
    public decimal AmountPaid { get; init; }
    public decimal TotalPaid { get; init; }
    public decimal OutstandingBalance { get; init; }
    public DateTime PayDate { get; init; }
    public required string PaymentMethod { get; init; }
    public string? Note { get; init; }
    public string? StaffName { get; init; }
}
