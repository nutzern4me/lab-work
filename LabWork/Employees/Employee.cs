namespace LabWork.Employees;

/// <summary>
/// Кадр (сотрудник)
/// </summary>
internal class Employee
{
    public string Name { get; set; } = null!;

    public Employee(string name)
    {
        Name = name;
    }

    public void DoWork()
    {
        Console.WriteLine($"{GetEmployeeType()} по имени {Name} делает свою работу");
    }

    public virtual string GetEmployeeType()
    {
        return "Сотрудник";
    }
}
