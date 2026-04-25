namespace TrungTamNgoaiNgu.Domain.Entities;

public sealed class CourseEntity
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal TuitionFee { get; set; }
    public string Status { get; set; } = "Active";
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public ICollection<ClassEntity> Classes { get; set; } = [];
}
