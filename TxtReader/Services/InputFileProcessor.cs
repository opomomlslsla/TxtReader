using TxtReader.Services.Interfaces;

namespace TxtReader.Services;

public class InputFileProcessor : IInputFileProcessor
{
    private readonly IFileSearcher _fileSearcher;
    private readonly IFileReader _fileReader;

    public InputFileProcessor(IFileSearcher fileSearcher, IFileReader fileReader)
    {
        _fileSearcher = fileSearcher;
        _fileReader = fileReader;
    }

    public async Task ProcessInputFileAsync(string path, string fileName)
    {
        string filePath = _fileSearcher.FindInputFilePath(path, fileName);
        if (filePath == null)
        {
            Console.WriteLine($"Ошибка: Файл {fileName} не найден в указанной директории.");
            return;
        }

        string firstNonEmptyLine = await _fileReader.ReadFirstNonEmptyLineAsync(filePath);
        if (string.IsNullOrEmpty(firstNonEmptyLine))
        {
            Console.WriteLine("Файл пуст.");
        }
        Console.WriteLine("Первая непустая строка:");
        Console.WriteLine(firstNonEmptyLine);
    }

    public async Task Run()
    {
        while (true)
        {
            Console.WriteLine("Введите путь к файлу (или 'exit' для выхода):");
            var filePath = Console.ReadLine();
            Console.WriteLine("Введите название файла которое нужно найти(с расширением):");
            var fileName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(filePath))
            {
                Console.WriteLine("Ошибка: Не указан путь");
                continue;
            }

            if (string.IsNullOrWhiteSpace(fileName))
            {
                Console.WriteLine("Ошибка: Не указано название файла");
                continue;
            }

            if (filePath.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Завершение работы.");
                break;
            }
            await ProcessInputFileAsync(filePath, fileName);
        }
    }
}


