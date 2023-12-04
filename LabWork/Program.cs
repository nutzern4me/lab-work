using LabWork.Employees;

namespace LabWork;

internal class Program
{
    static void Main(string[] args)
    {
        var employee1 = new Employee(name: "Пётр Иванов");
        AbstractEmployee.AddToLinkedList(employee1);

        var worker1 = new Worker(name: "Иван Алексеев", specialty: "Специальность1", workshop: "Цех1");
        AbstractEmployee.AddToLinkedList(worker1);

        var engineer1 = new Engineer(name: "Алексей Васильев", qualification: "Квалификация1", department: "Подразделение1");
        AbstractEmployee.AddToLinkedList(engineer1);

        var manager1 = new Manager(name: "Василий Петров", position: "Директор");
        AbstractEmployee.AddToLinkedList(manager1);

        AbstractEmployee.PrintLinkedList();
        Console.WriteLine();
    }
}
