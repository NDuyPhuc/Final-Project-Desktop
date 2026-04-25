namespace TrungTamNgoaiNgu.Application.Configuration;

public sealed class LanguageCenterDatabaseOptions
{
    public required string ConnectionString { get; init; }
    public int CommandTimeoutSeconds { get; init; } = 30;
}
