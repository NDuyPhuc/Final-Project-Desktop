namespace TrungTamNgoaiNgu.Domain.Entities;

public sealed class ClassEntity
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string CourseId { get; set; }
    public required string TeacherId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Schedule { get; set; }
    public string? Room { get; set; }
    public int MaxStudents { get; set; }
    public string Status { get; set; } = "Open";
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public CourseEntity? Course { get; set; }
    public TeacherEntity? Teacher { get; set; }
    public ICollection<EnrollmentEntity> Enrollments { get; set; } = [];
}
