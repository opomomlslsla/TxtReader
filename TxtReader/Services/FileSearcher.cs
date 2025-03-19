using TxtReader.Services.Interfaces;

namespace TxtReader.Services;

public class FileSearcher : IFileSearcher
{
    public string? FindInputFilePath(string path, string fileName)
    {
        if (File.Exists(path) && Path.GetFileName(path).Equals(fileName, StringComparison.OrdinalIgnoreCase))
            return path;
        if (!Directory.Exists(path))
            return null;
        var files = Directory.EnumerateFiles(path, fileName, SearchOption.AllDirectories);
        return files.FirstOrDefault();
    }
}

