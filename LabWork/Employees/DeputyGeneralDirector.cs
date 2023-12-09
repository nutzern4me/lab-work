namespace LabWork.Employees;

/// <summary>
/// Заместитель генерального директора
/// </summary>
internal sealed class DeputyGeneralDirector : Manager
{
    const string EmployeeTypeName = "Заместитель генерального директора";

    public override string EmployeeType => EmployeeTypeName;

    public DeputyGeneralDirector(string name) : base(name, EmployeeTypeName)
    {
    }

    public T HireNewEmployee<T>(string name) where T : Employee
    {
        if (typeof(T) == typeof(Worker))
        {
            return (new Worker(name) as T)!;
        }
        else if (typeof(T) == typeof(Engineer))
        {
            return (new Engineer(name) as T)!;
        }
        else if (typeof(T) == typeof(Manager))
        {
            return (new Manager(name) as T)!;
        }

        throw new Exception($"{typeof(T)} не является типом сотрудника, которого {EmployeeType.ToLower()} может принять на работу");
    }

    public bool TryHireNewEmployee<T>(out T employee, string name) where T : Employee
    {
        try
        {
            employee = HireNewEmployee<T>(name);
            return true;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Ошибка при попытке принять на работу сотрудника {name}: {ex.Message}");
            employee = default!;
            return false;
        }
    }
}