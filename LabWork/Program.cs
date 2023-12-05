namespace LabWork;

internal class Program
{
    static void Main(string[] args)
    {
        var set1 = new Cset<int>(1, 2, 3, 4, 4, 4, 5, 5, 5);
        set1.PrintAll(nameof(set1));
        Console.WriteLine();

        var set2 = new Cset<int>(3, 3, 3, 4, 5, 6, 7);
        set2.PrintAll(nameof(set2));
        Console.WriteLine();

        var set3 = new Cset<int>(7, 6, 5, 4, 3);
        set3.PrintAll(nameof(set3));
        Console.WriteLine();

        Console.WriteLine("Добавление элемента 8 в множество " + nameof(set1));
        set1 += 8;
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
        Console.WriteLine($"Проверка множеств {nameof(set2)} и {nameof(set3)} на равенство: {set2 == set3}");
        
        Console.WriteLine($"Мощность множества {nameof(set1)}: {(int)set1}");
        Console.WriteLine($"Мощность множества {nameof(set2)}: {(int)set2}");
        Console.WriteLine($"Мощность множества {nameof(set3)}: {(int)set3}");
    }
}
