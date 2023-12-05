using System.Collections;

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

    /// <summary>
    /// Получение имен рабочих заданного цеха
    /// </summary>
    public static IEnumerable<string> GetNames(string workshop)
    {
        foreach (var item in GetEmployees())
        {
            if (item is Worker worker && worker.Workshop.Equals(workshop, StringComparison.OrdinalIgnoreCase))
            {
                yield return worker.Name;
            }
        }
    }
}
