namespace TrungTamNgoaiNgu.Application.Infrastructure;

public static class AppPaths
{
    public static string BaseDirectory => AppContext.BaseDirectory;
    public static string LogFilePath => Path.Combine(BaseDirectory, "log.txt");
    public static string ImagesDirectory => Path.Combine(BaseDirectory, "Images");

    public static string EnsureImagesSubFolder(string subFolder)
    {
        var path = Path.Combine(ImagesDirectory, subFolder);
        Directory.CreateDirectory(path);
        return path;
    }

    public static string? ResolveAbsolutePath(string? relativePath)
    {
        if (string.IsNullOrWhiteSpace(relativePath))
        {
            return null;
        }

        return Path.IsPathRooted(relativePath)
            ? relativePath
            : Path.Combine(BaseDirectory, relativePath);
    }

    public static string SaveImage(string sourcePath, string subFolder, string entityId)
    {
        var extension = Path.GetExtension(sourcePath);
        var fileName = $"{entityId}_{DateTime.Now:yyyyMMddHHmmss}{extension}";
        var folderPath = EnsureImagesSubFolder(subFolder);
        var destinationPath = Path.Combine(folderPath, fileName);
        File.Copy(sourcePath, destinationPath, true);

        return Path.Combine("Images", subFolder, fileName);
    }

    public static string GetWorkspaceRoot()
    {
        var current = new DirectoryInfo(BaseDirectory);
        while (current is not null)
        {
            if (current.GetFiles("*.sln").Length > 0)
            {
                return current.FullName;
            }

            current = current.Parent;
        }

        return BaseDirectory;
    }
}
