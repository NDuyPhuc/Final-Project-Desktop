using System.Text;

namespace TrungTamNgoaiNgu.Application.Infrastructure;

public static class ErrorLogger
{
    private static readonly object SyncLock = new();

    public static void Log(Exception exception, string context)
    {
        try
        {
            var builder = new StringBuilder()
                .AppendLine(new string('=', 80))
                .AppendLine($"Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}")
                .AppendLine($"Context: {context}")
                .AppendLine($"Message: {exception.Message}")
                .AppendLine("StackTrace:")
                .AppendLine(exception.ToString())
                .AppendLine();

            lock (SyncLock)
            {
                File.AppendAllText(AppPaths.LogFilePath, builder.ToString());
            }
        }
        catch
        {
        }
    }
}
