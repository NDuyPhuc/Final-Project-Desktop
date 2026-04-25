namespace TrungTamNgoaiNgu.Application.Models;

public sealed class DashboardStats
{
    public int TotalStaff { get; init; }
    public int TotalTeachers { get; init; }
    public int TotalActiveClasses { get; init; }
    public int TotalStudents { get; init; }
    public int TotalReceipts { get; init; }
    public decimal TotalRevenue { get; init; }
    public decimal TotalDebt { get; init; }
    public int NewStudentsThisMonth { get; init; }
}
