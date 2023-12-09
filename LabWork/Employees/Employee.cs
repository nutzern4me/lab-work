namespace LabWork.Employees;

/// <summary>
/// Кадр (сотрудник)
/// </summary>
internal abstract class Employee
{
    private static Employee? _head;
    private static Employee? _tail;
    private Employee? _next;

    public string Name { get; set; } = null!;
    public virtual string EmployeeType => "Сотрудник";

    public Employee()
    {
        AddToLinkedList(this);
    }

    public Employee(string name) : this()
    {
        Name = name;
    }

    public virtual void DoWork()
    {
        Console.WriteLine($"{ToString()} делает свою работу");
    }

    public override string ToString()
    {
        return $"{EmployeeType} {Name}";
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

    private static void AddToLinkedList(Employee employee)
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

    public static IEnumerable<Employee> GetEmployees()
    {
        var current = _head;

        while (current != null)
        {
            yield return current;
            current = current._next;
        }
    }

    public static int GetEmployeesCount()
    {
        return GetEmployees().Count();
    }
}
