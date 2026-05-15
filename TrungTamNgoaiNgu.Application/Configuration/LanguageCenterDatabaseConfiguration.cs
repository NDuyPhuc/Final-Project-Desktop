using System.Text.Json;

namespace TrungTamNgoaiNgu.Application.Configuration;

public static class LanguageCenterDatabaseConfiguration
{
    private const string SettingsFileName = "appsettings.json";
    private const string ConnectionStringEnvironmentVariable = "TTNN_SQL_CONNECTION_STRING";
    private const string PasswordEnvironmentVariable = "TTNN_SQL_PASSWORD";

    public static LanguageCenterDatabaseOptions Load()
    {
        var settings = LoadSettingsFile();

        var rawConnectionString = Environment.GetEnvironmentVariable(ConnectionStringEnvironmentVariable);
        if (string.IsNullOrWhiteSpace(rawConnectionString))
        {
            rawConnectionString = settings?.Database?.ConnectionString;
        }

        if (string.IsNullOrWhiteSpace(rawConnectionString))
        {
            throw new InvalidOperationException(
                $"Khong tim thay connection string. Hay cau hinh {SettingsFileName} hoac bien moi truong {ConnectionStringEnvironmentVariable}.");
        }

        var normalizedConnectionString = NormalizeConnectionString(rawConnectionString);
        var passwordOverride = Environment.GetEnvironmentVariable(PasswordEnvironmentVariable);
        if (!string.IsNullOrWhiteSpace(passwordOverride)
            && !normalizedConnectionString.Contains("Password=", StringComparison.OrdinalIgnoreCase))
        {
            normalizedConnectionString = normalizedConnectionString.TrimEnd(';') + $";Password={passwordOverride};";
        }

        return new LanguageCenterDatabaseOptions
        {
            ConnectionString = normalizedConnectionString,
            CommandTimeoutSeconds = settings?.Database?.CommandTimeoutSeconds ?? 30
        };
    }

    private static AppSettingsRoot? LoadSettingsFile()
    {
        var settingsPath = Path.Combine(AppContext.BaseDirectory, SettingsFileName);
        if (!File.Exists(settingsPath))
        {
            return null;
        }

        try
        {
            var json = File.ReadAllText(settingsPath);
            return JsonSerializer.Deserialize<AppSettingsRoot>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    ReadCommentHandling = JsonCommentHandling.Skip,
                    AllowTrailingCommas = true
                });
        }
        catch (JsonException)
        {
            return null;
        }
        catch (IOException)
        {
            return null;
        }
        catch (UnauthorizedAccessException)
        {
            return null;
        }
    }

    private static string NormalizeConnectionString(string rawConnectionString)
    {
        var segments = rawConnectionString
            .Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Where(segment =>
                !segment.StartsWith("Command Timeout", StringComparison.OrdinalIgnoreCase))
            .ToArray();

        var hasConnectTimeout = segments.Any(segment =>
            segment.StartsWith("Connect Timeout", StringComparison.OrdinalIgnoreCase)
            || segment.StartsWith("Connection Timeout", StringComparison.OrdinalIgnoreCase));

        var normalizedConnectionString = string.Join(';', segments) + ';';
        return hasConnectTimeout
            ? normalizedConnectionString
            : normalizedConnectionString + "Connect Timeout=5;";
    }

    private sealed class AppSettingsRoot
    {
        public DatabaseSettingsSection? Database { get; init; }
    }

    private sealed class DatabaseSettingsSection
    {
        public string? ConnectionString { get; init; }
        public int? CommandTimeoutSeconds { get; init; }
    }
}
