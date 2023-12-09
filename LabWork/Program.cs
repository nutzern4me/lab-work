using LabWork.Employees;

namespace LabWork;

internal class Program
{
    static void Main(string[] args)
    {
        List<Employee> list = new();

        DeputyGeneralDirector depGenDir = new("Алексей Алексеевич");

        try
        {
            Engineer engineer = depGenDir.HireNewEmployee<Engineer>("Михаил Зубенко");
            list.Add(engineer);

            DeputyGeneralDirector depGenDir2 = depGenDir.HireNewEmployee<DeputyGeneralDirector>("новый зам. ген. директора");
            list.Add(depGenDir2);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        if (depGenDir.TryHireNewEmployee(out Worker worker, "Денис Петров"))
        {
            list.Add(worker);
        }

        if (depGenDir.TryHireNewEmployee(out Employee emp, "абстрактный сотрудник"))
        {
            list.Add(emp);
        }

        var manager = new Manager(name: "Василий Петров", position: "Директор отдела продаж");
        list.Add(manager);


        Console.WriteLine("Сотрудники, добавленные в List:");
        foreach (var employee in list) 
        {
            Console.WriteLine(employee);
        }

        
        Employee.PrintLinkedList();
        Console.WriteLine();
        Console.WriteLine("Всего сотрудников: " + Employee.GetEmployeesCount());
    }
}
