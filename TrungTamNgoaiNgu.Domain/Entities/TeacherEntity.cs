namespace TrungTamNgoaiNgu.Domain.Entities;

public sealed class TeacherEntity
{
    public required string Id { get; set; }
    public required string FullName { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }
    public string? Specialization { get; set; }
    public string? Gender { get; set; }
    public string? Address { get; set; }
    public string? AvatarPath { get; set; }
    public string? AccountId { get; set; }
    public string Status { get; set; } = "Active";
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public AccountEntity? Account { get; set; }
    public ICollection<ClassEntity> Classes { get; set; } = [];
}
