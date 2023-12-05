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
        Console.WriteLine($"{this.ToString} делает свою работу");
    }

    public override string ToString()
    {
        return $"{EmployeeType} {Name}";
    }

    public override bool Equals(object? obj)
    {
        if (this == obj) 
            return true;
        else if (obj is Employee employee && employee.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase))
            return true;
        
        return false;
    }
}
