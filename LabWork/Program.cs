namespace LabWork;

internal class Program
{
    static void Main(string[] args)
    {
        StartTest();
        Console.WriteLine();

        GC.Collect(); //Вызов сборки мусора для демонстрации работы реализованного деструктора
        GC.WaitForPendingFinalizers(); //Ожидание окончания работы деструкторов
    }

    static void StartTest()
    {
        Console.WriteLine("Создание пустого списка");
        var myList = new MyLinkedList<int>();
        TestList(myList);
        Console.WriteLine();

        Console.WriteLine("Создание списка со значениями");
        var myList2 = new MyLinkedList<int>(1, 2, 3, 4, 5);
        TestList(myList2);

        Console.WriteLine("\nСоздание списка путем копирования существующего");
        var myList3 = new MyLinkedList<int>(myList2);
        myList3.PrintAll();
    }

    static void TestList(MyLinkedList<int> myLinkedList)
    {
        myLinkedList.PrintAll();
        Console.WriteLine();

        myLinkedList.PrintAllFromEnd();
        Console.WriteLine();

        Console.WriteLine("Добавление 1, 2, 3");
        myLinkedList.Add(1);
        myLinkedList.Add(2);
        myLinkedList.Add(3);
        myLinkedList.PrintAll();
        Console.WriteLine();

        Console.WriteLine("Поиск элемента со значением 1");
        var foundItem = myLinkedList.Find(1);
        Console.WriteLine(foundItem?.Value);
        Console.WriteLine();

        Console.WriteLine("Удаление найденного элемента");
        myLinkedList.Remove(foundItem!);
        myLinkedList.PrintAll();
    }
}
