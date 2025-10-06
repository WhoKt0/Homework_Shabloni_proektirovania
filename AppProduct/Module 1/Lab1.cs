using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProduct.Module_1
{

    public interface IEmployee
    {
        int Id { get; }
        string Name { get; }
        string Position { get; }
        decimal CalculateSalary();
    }

    public class Worker : IEmployee
    {
        public int Id { get; }
        public string Name { get; }
        public string Position => "Рабочий";
        public decimal HourlyRate { get; }
        public int HoursWorked { get; }

        public Worker(int id, string name, decimal hourlyRate, int hoursWorked)
        {
            Id = id;
            Name = name;
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        public decimal CalculateSalary() => HourlyRate * HoursWorked;
    }

    public class Manager : IEmployee
    {
        public int Id { get; }
        public string Name { get; }
        public string Position => "Менеджер";
        public decimal BaseSalary { get; }
        public decimal Bonus { get; }

        public Manager(int id, string name, decimal baseSalary, decimal bonus)
        {
            Id = id;
            Name = name;
            BaseSalary = baseSalary;
            Bonus = bonus;
        }

        public decimal CalculateSalary() => BaseSalary + Bonus;
    }

    public interface IEmployeeRepository
    {
        void Add(IEmployee employee);
        bool Remove(int id);
        IEmployee? Find(int id);
        IReadOnlyCollection<IEmployee> GetAll();
    }

    public class InMemoryEmployeeRepository : IEmployeeRepository
    {
        private readonly List<IEmployee> employees = new List<IEmployee>();

        public void Add(IEmployee employee)
        {
            if (employees.Any(e => e.Id == employee.Id)) return;
            employees.Add(employee);
        }

        public bool Remove(int id)
        {
            var e = Find(id);
            if (e == null) return false;
            employees.Remove(e);
            return true;
        }

        public IEmployee? Find(int id) => employees.FirstOrDefault(e => e.Id == id);

        public IReadOnlyCollection<IEmployee> GetAll() => employees.AsReadOnly();
    }

    public class EmployeeSystem
    {
        private readonly IEmployeeRepository repository;
        private readonly CultureInfo ru = CultureInfo.GetCultureInfo("ru-RU");

        public EmployeeSystem(IEmployeeRepository repo)
        {
            repository = repo;
        }

        public void RegisterEmployee(IEmployee employee)
        {
            repository.Add(employee);
            Console.WriteLine($"Добавлен сотрудник: {employee.Name}, должность: {employee.Position}");
        }

        public bool RemoveEmployee(int id)
        {
            var removed = repository.Remove(id);
            Console.WriteLine(removed ? $"Сотрудник id={id} удалён." : $"Сотрудник id={id} не найден.");
            return removed;
        }

        public void ShowSalaries()
        {
            Console.WriteLine("\nЗарплаты:");
            foreach (var emp in repository.GetAll())
            {
                var salary = emp.CalculateSalary();
                Console.WriteLine($"{emp.Name} ({emp.Position}) → {salary.ToString("C0", ru)}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            IEmployeeRepository repo = new InMemoryEmployeeRepository();
            var system = new EmployeeSystem(repo);

            IEmployee w1 = new Worker(1, "worker1", 500m, 160);
            IEmployee w2 = new Worker(2, "worker2", 600m, 170);
            IEmployee m1 = new Manager(3, "manager1", 50000m, 10000m);

            system.RegisterEmployee(w1);
            system.RegisterEmployee(w2);
            system.RegisterEmployee(m1);

            system.ShowSalaries();
            system.RemoveEmployee(2);
            system.ShowSalaries();
        }
    }
}
