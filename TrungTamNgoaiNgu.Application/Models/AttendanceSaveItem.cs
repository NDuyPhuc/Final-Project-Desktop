namespace TrungTamNgoaiNgu.Application.Models;

public sealed class AttendanceSaveItem
{
    public required string EnrollmentId { get; init; }
    public required string Status { get; init; }
    public string? Note { get; init; }
}
