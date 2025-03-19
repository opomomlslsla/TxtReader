namespace TxtReader.Services;

using System.IO;
using TxtReader.Services.Interfaces;

public class FileReader : IFileReader
{
    public string ReadFirstNonEmptyLine(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    return line;
                }
            }
        }
        return null; // Файл пуст или не существует
    }
}

