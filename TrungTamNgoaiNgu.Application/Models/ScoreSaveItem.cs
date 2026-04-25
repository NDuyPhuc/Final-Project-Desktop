namespace TrungTamNgoaiNgu.Application.Models;

public sealed class ScoreSaveItem
{
    public required string EnrollmentId { get; init; }
    public decimal? MidtermScore { get; init; }
    public decimal? FinalScore { get; init; }
    public string? Note { get; init; }
}
