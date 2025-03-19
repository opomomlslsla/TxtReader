namespace TxtReader.Services.Interfaces
{
    public interface IInputFileProcessor
    {
        void ProcessInputFile(string path, string fileName);
        void Run();
    }
}