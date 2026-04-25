namespace TrungTamNgoaiNgu.Domain.Entities;

public sealed class AttendanceEntity
{
    public required string Id { get; set; }
    public required string EnrollmentId { get; set; }
    public DateTime AttendanceDate { get; set; }
    public required string Status { get; set; }
    public string? Note { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public EnrollmentEntity? Enrollment { get; set; }
}
