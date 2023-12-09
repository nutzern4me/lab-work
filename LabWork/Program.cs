namespace LabWork;

internal class Program
{
    static void Main(string[] args)
    {
        TestLongList();

        TestMyClassList();
    }

    static void TestMyClassList()
    {
        List<MyLinkedList<char>> list = [
            new('a', 'b', 'c'),
            new('d', 'e', 'f'),
            new('g', 'h', 'i'),
            new('j', 'k', 'l'),
            new('m', 'n', 'o'),
            new('p', 'q', 'r'),
            new('s', 't', 'u'),
        ];
        PrintList(list);

        list.RemoveAt(1);
        list[2].Add('z');
        PrintList(list);

        int n = list.Count / 2;
        list.RemoveRange(n, n);
        PrintList(list);

        list.Sort((a, b) => b.CompareTo(a));
        PrintList(list);


        //находим в списке элемент (двусвязный список), который соответствует заданному условию (количество элементов равно 3)
        Predicate<MyLinkedList<char>> predicate = x => x.Count() == 3;
        MyLinkedList<char>? foundLinkedList = list.Find(predicate);
        
        if (foundLinkedList != null)
            foundLinkedList.PrintAll();
        else
            Console.WriteLine("Элемент не найден");

        //находим все элементы, соответствующие этому условию 
        var allFoundLists = list.FindAll(predicate);
        //выводим количество найденных и их содержимое 
        Console.WriteLine(allFoundLists.Count());
        PrintList(allFoundLists);
    }

    static void PrintList<T>(List<MyLinkedList<T>> list)
    {
        Console.WriteLine("\n========== List<MyLinkedList<T>> ==========");

        foreach (var item in list)
        {
            item.PrintAll();
        }

        Console.WriteLine("===========================================");
    }

    static void TestLongList()
    {
        List<long> list = [1L, 1L, 4L, 3L, 4L, 5L, 6L, 7L, 8L, 9L, 10L, 11L];
        PrintList(list);

        list.Remove(11);
        list.RemoveAt(1);
        list[1] /= 2;
        PrintList(list);

        int n = list.Count / 2;
        list.RemoveRange(n, n);
        PrintList(list);

        list.Sort((a, b) => b.CompareTo(a));
        PrintList(list);
    }

    static void PrintList<T>(List<T> list)
    {
        Console.Write("\nList: ");
        
        foreach (var item in list.SkipLast(1)) 
        {
            Console.Write(item + ", ");
        }

        Console.WriteLine(list.LastOrDefault());
    }


    //static List<long> CreateAndFillList()
    //{
    //    return new List<long> { 1L, 2L, 3L, 4L, 5L, 6L, 7L, 8L, 9L, 10L };
    //}


}
