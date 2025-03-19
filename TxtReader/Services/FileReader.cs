using TxtReader.Services.Interfaces;

namespace TxtReader.Services;

public class FileReader : IFileReader
{
    public async Task<string?> ReadFirstNonEmptyLineAsync(string filePath)
    {
        using var reader = new StreamReader(filePath);
        string line;
        while ((line = await reader.ReadLineAsync()) != null)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                return line;
            }
        }
        return null;
    }
}

