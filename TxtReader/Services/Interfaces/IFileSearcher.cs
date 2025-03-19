namespace TxtReader.Services.Interfaces
{
    public interface IFileSearcher
    {
        string FindInputFile(string directoryPath, string fileName);
    }
}