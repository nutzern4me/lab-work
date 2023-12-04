namespace LabWork.Employees;

/// <summary>
/// Администрация
/// </summary>
internal class Manager : Employee
{
    /// <summary>
    /// Должность
    /// </summary>
    public string Position { get; set; } = null!;

    public override string EmployeeType => "Администратор";

    public Manager(string name, string position) : base(name)
    {
        Position = position;
    }
}
