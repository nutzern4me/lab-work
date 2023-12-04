namespace LabWork.Employees;

/// <summary>
/// Кадр (сотрудник)
/// </summary>
internal class Employee
{
    public string Name { get; set; } = null!;

    public virtual string EmployeeType => "Сотрудник";
    
    public Employee(string name)
    {
        Name = name;
    }

    public void DoWork()
    {
        Console.WriteLine($"{EmployeeType} по имени {Name} делает свою работу");
    }
}
