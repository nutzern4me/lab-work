using LabWork.Employees;
using LabWork.Exceptions;

namespace LabWork;

internal class Program
{
    static void Main(string[] args)
    {
        Cset<double> doubleSet1 = [1, 2, 3, 4, 4, 4, 5, 5, 5];
        Cset<double> doubleSet2 = [1, 2, 3, 3, 3, 4, 5, 8];
        TestSets(doubleSet1, doubleSet2, 8);

        Cset<char> charSet1 = ['a', 'b', 'c', 'd', 'e'];
        Cset<char> charSet2 = ['d', 'e', 'f', 'g', 'h'];
        TestSets(charSet1, charSet2, 'z');

        Cset<Employee> employeeSet1 = [new("Иван Петров"), new("Владимир Сергеев"), new("Антон Никитин")];
        Cset<Employee> employeeSet2 = [new("Дмитрий Лазарев"), new("Владимир Сергеев"), new("Николай Алексеев")];
        TestSets(employeeSet1, employeeSet2, new Employee("Денис Давыдов"));

        Console.WriteLine("\nУдаление каждого второго элемента в множестве " + nameof(doubleSet1));
        DeleteEvenElemsTest(doubleSet1);

        Console.WriteLine("\nУдаление каждого второго элемента в множестве " + nameof(charSet1));
        DeleteEvenElemsTest(charSet1);

        Console.WriteLine("\nУдаление каждого второго элемента в множестве " + nameof(employeeSet1));
        DeleteEvenElemsTest(employeeSet1);
    }

    private static void TestSets<T>(Cset<T> set1, Cset<T> set2, T itemToAdd)
    {
        set1.PrintAll(nameof(set1));
        set2.PrintAll(nameof(set2));
        Console.WriteLine();

        Console.WriteLine($"Добавление элемента {itemToAdd} в множество");
        set1 += itemToAdd;
        set1.PrintAll(nameof(set1));
        Console.WriteLine();

        Console.WriteLine($"Объединение множеств {nameof(set1)} и {nameof(set2)}");
        var unionSet = set1 + set2;
        unionSet.PrintAll(nameof(unionSet));
        Console.WriteLine();

        Console.WriteLine($"Пересечение множеств {nameof(set1)} и {nameof(set2)}");
        var intersectedSet = set1 * set2;
        intersectedSet.PrintAll(nameof(intersectedSet));
        Console.WriteLine();

        Console.WriteLine($"Проверка множеств {nameof(set1)} и {nameof(set2)} на равенство: {set1 == set2}");

        Console.WriteLine($"Мощность множества {nameof(set1)}: {(int)set1}");
        Console.WriteLine($"Мощность множества {nameof(set2)}: {(int)set2}");
        Console.WriteLine();
    }

    private static void DeleteEvenElemsTest<T>(Cset<T> set)
    {
        set.PrintAll("до удаления");

        Cset<T>.DeleteSetEvenElements(ref set);

        set.PrintAll("после удаления");
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
