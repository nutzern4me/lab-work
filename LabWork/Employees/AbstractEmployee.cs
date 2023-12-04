namespace LabWork.Employees;

internal abstract class AbstractEmployee
{
    private static AbstractEmployee? _head;
    private static AbstractEmployee? _tail;
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
        if (_tail == null)
        {
            _head = employee;
            _tail = _head;
        }
        else
        {
            _tail._next = employee;
            _tail = employee;
        }            
    }
}
