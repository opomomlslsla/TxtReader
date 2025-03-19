namespace TxtReader.Services.Interfaces
{
    public interface IFileReader
    {
        string ReadFirstNonEmptyLine(string filePath);
    }
}