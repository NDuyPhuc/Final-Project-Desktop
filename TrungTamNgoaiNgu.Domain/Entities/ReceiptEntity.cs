namespace TrungTamNgoaiNgu.Domain.Entities;

public sealed class ReceiptEntity
{
    public required string Id { get; set; }
    public required string EnrollmentId { get; set; }
    public decimal AmountPaid { get; set; }
    public DateTime PayDate { get; set; }
    public required string PaymentMethod { get; set; }
    public string? Note { get; set; }
    public string? CreatedByStaffId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public EnrollmentEntity? Enrollment { get; set; }
    public AccountEntity? CreatedByStaff { get; set; }
}
