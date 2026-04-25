using TrungTamNgoaiNgu.Domain.Enums;

namespace TrungTamNgoaiNgu.Domain.Entities;

public sealed class AccountEntity
{
    public required string Id { get; set; }
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public required string DisplayName { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public AccountRole Role { get; set; }
    public AccountStatus Status { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public TeacherEntity? TeacherProfile { get; set; }
    public ICollection<ReceiptEntity> CreatedReceipts { get; set; } = [];
}
