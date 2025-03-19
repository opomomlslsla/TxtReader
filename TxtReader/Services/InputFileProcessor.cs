namespace TxtReader.Services;

using System;
using Microsoft.Extensions.DependencyInjection;
using TxtReader.Services.Interfaces;

public class InputFileProcessor : IInputFileProcessor
{
    private readonly IFileSearcher _fileSearcher;
    private readonly IFileReader _fileReader;

    public InputFileProcessor(IFileSearcher fileSearcher, IFileReader fileReader)
    {
        _fileSearcher = fileSearcher;
        _fileReader = fileReader;
    }

    public void ProcessInputFile(string path, string fileName)
    {
        string filePath = _fileSearcher.FindInputFile(path, fileName);
        if (filePath == null)
        {
            Console.WriteLine($"Ошибка: Файл {fileName} не найден в указанной директории.");
            return;
        }

        string firstNonEmptyLine = _fileReader.ReadFirstNonEmptyLine(filePath);
        if (!string.IsNullOrEmpty(firstNonEmptyLine))
        {
            Console.WriteLine("Первая непустая строка:");
            Console.WriteLine(firstNonEmptyLine);
        }
        else
        {
            Console.WriteLine("Файл пуст.");
        }
    }

    public void Run()
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
            ProcessInputFile(filePath, fileName);
        }
    }
}


