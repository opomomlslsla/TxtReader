namespace TxtReader.Services;

using System.IO;
using TxtReader.Services.Interfaces;

public class FileSearcher : IFileSearcher
{
    public string FindInputFile(string directoryPath, string fileName)
    {
        if (File.Exists(directoryPath) && Path.GetFileName(directoryPath).Equals(fileName, StringComparison.OrdinalIgnoreCase))
            return directoryPath;
        if (!Directory.Exists(directoryPath))
        {
            return null;
        }
        var files = Directory.EnumerateFiles(directoryPath, fileName, SearchOption.AllDirectories);
        return files.FirstOrDefault(); // Возвращает первый найденный файл или null
    }
}

