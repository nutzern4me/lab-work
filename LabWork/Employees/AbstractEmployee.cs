using System.Collections;

namespace LabWork.Employees;

internal abstract class AbstractEmployee
{
    private static AbstractEmployee? _head;
    private static AbstractEmployee? _tail;
    private AbstractEmployee? _next;

    public AbstractEmployee()
    {
        AddToLinkedList(this);
    }

    public static void PrintLinkedList()
    {
        if (_head == null) 
        {
            Console.WriteLine("Список пуст");
            return;
        }

        Console.Write("\nСписок сотрудников: ");

        foreach (var item in GetEmployees())
        {
            Console.Write(item.ToString() + "; ");
        }
    }

    private static void AddToLinkedList(AbstractEmployee employee)
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

    public static IEnumerable<AbstractEmployee> GetEmployees()
    {
        var current = _head;

        while (current != null)
        {
            yield return current;
            current = current._next;
        }
    }
}
