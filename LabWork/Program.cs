using LabWork.Employees;

namespace LabWork;

internal class Program
{
    static void Main(string[] args)
    {
        var employee1 = new Employee(name: "Пётр Иванов");

        var worker1 = new Worker(name: "Иван Алексеев", specialty: "Специальность1", workshop: "Цех1");

        var engineer1 = new Engineer(name: "Алексей Васильев", qualification: "Квалификация1", department: "Подразделение1");

        var manager1 = new Manager(name: "Василий Петров", position: "Директор");

        AbstractEmployee.PrintLinkedList();
        Console.WriteLine();

        _ = new Worker(name: "Денис Иванов", specialty: "Специальность1", workshop: "Цех1");

        Console.Write("Имена рабочих цеха Цех1: ");
        foreach (string name in Worker.GetNames("Цех1"))
        {
            Console.Write(name + "; ");
        }
        Console.WriteLine();

        _ = new Engineer(name: "Новый инженер", qualification: "Квалификация1", department: "Подразделение1");

        Console.WriteLine("Количество инженеров в подразделении Подразделение1: " + Engineer.GetCount("Подразделение1"));
    }
}
