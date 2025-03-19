using Microsoft.Extensions.DependencyInjection;
using TxtReader.Services.Interfaces;
using TxtReader.Services;

class Program
{
    static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IFileSearcher, FileSearcher>()
            .AddSingleton<IFileReader, FileReader>()
            .AddSingleton<IInputFileProcessor,InputFileProcessor>()
            .BuildServiceProvider();

        var processor = serviceProvider.GetRequiredService<IInputFileProcessor>();
        processor.Run();
    }
}
