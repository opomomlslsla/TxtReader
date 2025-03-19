namespace TxtReader.Services.Interfaces;

public interface IFileReader
{
    Task<string> ReadFirstNonEmptyLineAsync(string filePath);
}