using LabWork.Employees;
using LabWork.Exceptions;

namespace LabWork;

internal class Program
{
    private const string SetFilesFolder = "setFiles";

    static async Task Main(string[] args)
    {
        Directory.CreateDirectory(SetFilesFolder);

        var intSet = new Cset<int>(1, 2, 3, 4, 5);
        string intSetFilePath = GetFilePath(nameof(intSet));
        Task saveIntSet = SaveToFileAsync(intSet, intSetFilePath);

        var charSet = new Cset<char>('a', 'b', 'c', 'd', 'e');
        string charSetFilePath = GetFilePath(nameof(charSet));
        Task saveCharSet = SaveToFileAsync(charSet, charSetFilePath);

        var empSet = new Cset<Employee>(
            new Employee("Иван Петров"),
            new Employee("Владимир Сергеев"),
            new Employee("Антон Никитин")
        );
        string empSetFilePath = GetFilePath(nameof(empSet));
        Task saveEmpSet = SaveToFileAsync(empSet, empSetFilePath);


        await saveIntSet;
        var intSet2 = CreateFromFileAsync<int>(intSetFilePath);

        await saveCharSet;
        var charSet2 = CreateFromFileAsync<char>(charSetFilePath);

        await saveEmpSet;
        var empSet2 = CreateFromFileAsync<Employee>(empSetFilePath);


        if ((await intSet2) is { } createdIntSet)
            createdIntSet.PrintAll();

        if ((await charSet2) is { } createdCharSet)
            createdCharSet.PrintAll();

        if ((await empSet2) is { } createdEmpSet)
            createdEmpSet.PrintAll();
    }

    private static string GetFilePath(string setName)
    {
        return Path.Combine(SetFilesFolder, setName + ".json");
    }

    static async Task SaveToFileAsync<T>(Cset<T> set, string filename)
    {
        try
        {
            using FileStream fileStream = new FileStream(filename, FileMode.Create);
            await set.SaveToFileAsync(fileStream);
        }
        catch (Exception ex)
        {
            await HandleCsetFileException($"Ошибка при сохранении множества {typeof(T)} в файл {filename}", ex);
        }
    }

    static async Task<Cset<T>?> CreateFromFileAsync<T>(string filename)
    {
        try
        {
            using FileStream fileStream = new FileStream(filename, FileMode.Open);
            return await Cset<T>.CreateFromFile(fileStream);
        }
        catch (Exception ex)
        {
            await HandleCsetFileException($"Ошибка при загрузке множества {typeof(T)} из файла {filename}", ex);
            return null;
        }        
    }

    static async Task HandleCsetFileException(string mainMessage, Exception ex)
    {
        string exceptionMessage = ex switch
        {
            DirectoryNotFoundException => "Не найдена директория, указанная в пути",
            FileNotFoundException => "Не найден файл",
            PathTooLongException => "Путь к файлу слишком длинный",
            CsetSaveException or CsetLoadException => ex.InnerException?.Message != null
                ? $"{ex.Message} | {ex.InnerException.Message}"
                : ex.Message,
            _ => ex.Message
        };

        await Console.Out.WriteLineAsync($"{mainMessage}: {exceptionMessage}");
    }

    static async Task LoadFromFileAsync<T>(Cset<T> set, string filename)
    {
        try
        {
            using FileStream fileStream = new FileStream(filename, FileMode.Open);
            await set.LoadFromFileAsync(fileStream);
        }
        catch (Exception ex)
        {
            await HandleCsetFileException($"Ошибка при загрузке множества {typeof(T)} из файла {filename}", ex);
        }
    }
}
