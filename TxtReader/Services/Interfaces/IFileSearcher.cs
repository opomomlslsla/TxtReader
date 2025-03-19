namespace TxtReader.Services.Interfaces;

public interface IFileSearcher
{
    string FindInputFilePath(string directoryPath, string fileName);
}