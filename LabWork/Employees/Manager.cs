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

    public Manager(string name, string position) : base(name)
    {
        Position = position;
    }

    public override string GetEmployeeType()
    {
        return "Администратор";
    }
}
