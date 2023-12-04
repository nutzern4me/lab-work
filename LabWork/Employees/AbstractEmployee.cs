namespace LabWork.Employees;

internal abstract class AbstractEmployee
{
    private static AbstractEmployee? _head;
    private AbstractEmployee? _next;

    public static void PrintLinkedList()
    {
        if (_head == null) 
        {
            Console.WriteLine("Список пуст");
            return;
        }

        Console.Write("\nСписок сотрудников: ");

        AbstractEmployee? current = _head;

        while (current != null) 
        {
            Console.Write(current.ToString() + "; ");
            current = current._next;
        }
    }

    public static void AddToLinkedList(AbstractEmployee employee)
    {
        AbstractEmployee? last = GetLastItem();

        if (last == null)
            _head = employee;
        else
            last._next = employee;
    }

    private static AbstractEmployee? GetLastItem()
    {
        if (_head == null)
            return _head;

        AbstractEmployee current = _head;

        while (current._next != null)
        {
            current = current._next;
        }

        return current;
    }
}
