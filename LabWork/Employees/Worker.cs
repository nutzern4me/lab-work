namespace LabWork.Employees;

/// <summary>
/// Рабочий
/// </summary>
internal class Worker : Employee
{
    /// <summary>
    /// Специальность
    /// </summary>
    public string Specialty { get; set; } = null!;

    /// <summary>
    /// Цех
    /// </summary>
    public string Workshop { get; set; } = null!;

    public override string EmployeeType => "Рабочий";

    public Worker(string name, string specialty, string workshop) : base(name)
    {
        Specialty = specialty;
        Workshop = workshop;
    }
}
