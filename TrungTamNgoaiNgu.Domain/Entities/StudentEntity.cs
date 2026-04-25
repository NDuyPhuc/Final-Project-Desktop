namespace TrungTamNgoaiNgu.Domain.Entities;

public sealed class StudentEntity
{
    public required string Id { get; set; }
    public required string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public required string Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? AvatarPath { get; set; }
    public string Status { get; set; } = "Active";
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public ICollection<EnrollmentEntity> Enrollments { get; set; } = [];
}
