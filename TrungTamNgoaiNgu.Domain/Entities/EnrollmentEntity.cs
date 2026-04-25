namespace TrungTamNgoaiNgu.Domain.Entities;

public sealed class EnrollmentEntity
{
    public required string Id { get; set; }
    public required string StudentId { get; set; }
    public required string ClassId { get; set; }
    public DateTime EnrollDate { get; set; }
    public required string Status { get; set; }
    public string? Note { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public StudentEntity? Student { get; set; }
    public ClassEntity? Class { get; set; }
    public ICollection<ReceiptEntity> Receipts { get; set; } = [];
    public ICollection<AttendanceEntity> Attendances { get; set; } = [];
    public ScoreEntity? Score { get; set; }
}
