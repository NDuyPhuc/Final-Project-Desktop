namespace TrungTamNgoaiNgu.Application.Models;

public sealed class EnrollmentReceiptContext
{
    public required string EnrollmentId { get; init; }
    public required string StudentCode { get; init; }
    public required string StudentName { get; init; }
    public required string ClassCode { get; init; }
    public required string ClassName { get; init; }
    public required string CourseName { get; init; }
    public decimal TuitionFee { get; init; }
    public decimal TotalPaid { get; init; }
    public decimal OutstandingBalance { get; init; }
}
