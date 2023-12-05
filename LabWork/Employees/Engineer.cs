namespace LabWork.Employees;

/// <summary>
/// Инженер
/// </summary>
internal class Engineer : Employee
{
    /// <summary>
    /// Квалификация
    /// </summary>
    public string Qualification { get; set; } = null!;

    /// <summary>
    /// Подразделение
    /// </summary>
    public string Department { get; set; } = null!;

    public override string EmployeeType => "Инженер";

    public Engineer(string name, string qualification, string department) : base(name)
    {
        Qualification = qualification;
        Department = department;
    }

    /// <summary>
    /// Получение количества инженеров в заданном подразделении
    /// </summary>
    public static int GetCount(string department)
    {
        return GetEmployees()
            .Where(x => x is Engineer engineer && engineer.Department.Equals(department, StringComparison.OrdinalIgnoreCase))
            .Count();
    }
}
