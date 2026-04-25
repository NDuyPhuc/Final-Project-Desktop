namespace TrungTamNgoaiNgu.Domain.Entities;

public sealed class ScoreEntity
{
    public required string Id { get; set; }
    public required string EnrollmentId { get; set; }
    public decimal? MidtermScore { get; set; }
    public decimal? FinalScore { get; set; }
    public string? Note { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public EnrollmentEntity? Enrollment { get; set; }
}
