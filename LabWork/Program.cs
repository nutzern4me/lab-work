using LabWork.Employees;

namespace LabWork;

internal class Program
{
    static void Main(string[] args)
    {
        var doubleSet1 = new Cset<double>(1, 2, 3, 4, 4, 4, 5, 5, 5);
        var doubleSet2 = new Cset<double>(3, 3, 3, 4, 5, 6, 7);
        TestSets(doubleSet1, doubleSet2, 8);

        var charSet1 = new Cset<char>('a', 'b', 'c', 'd', 'e');
        var charSet2 = new Cset<char>('d', 'e', 'f', 'g', 'h');
        TestSets(charSet1, charSet2, 'z');

        var employeeSet1 = new Cset<Employee>(
            new Employee("Иван Петров"),
            new Employee("Владимир Сергеев"),
            new Employee("Антон Никитин")
        );
        var employeeSet2 = new Cset<Employee>(
            new Employee("Дмитрий Лазарев"),
            new Employee("Владимир Сергеев"),
            new Employee("Николай Алексеев")
        );
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

        DeleteSetEvenElements(ref set);
        
        set.PrintAll("после удаления");
    }

    /// <summary>
    /// Удаление каждого второго элемента в множестве
    /// </summary>
    private static void DeleteSetEvenElements<T>(ref Cset<T> set)
    {
        var resultSet = new Cset<T>();

        int i = 1;
        foreach (var item in set)
        {
            if (i % 2 != 0)
                resultSet.Add(item);
            
            i++;
        }

        set = resultSet;
    }
}
