using System;
using System.Globalization;

namespace SingleFileAll
{
    public interface IOutput
    {
        void Write(string message);
    }

    public class ConsoleOutput : IOutput
    {
        public void Write(string message) => Console.WriteLine(message);
    }

    public class OrderService
    {
        private readonly IOutput _output;
        public OrderService(IOutput output) => _output = output;
        public void CreateOrder(string productName, int quantity, double price) => ProcessOrder("created", productName, quantity, price);
        public void UpdateOrder(string productName, int quantity, double price) => ProcessOrder("updated", productName, quantity, price);
        private void ProcessOrder(string action, string productName, int quantity, double price)
        {
            double totalPrice = quantity * price;
            _output.Write($"Order for {productName} {action}. Total: {totalPrice.ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }

    public abstract class Vehicle
    {
        public string Brand { get; }
        public string Model { get; }
        protected Vehicle(string brand, string model) { Brand = brand; Model = model; }
        public virtual void Start() => Console.WriteLine($"{Brand} {Model} is starting");
        public virtual void Stop() => Console.WriteLine($"{Brand} {Model} is stopping");
        public override string ToString() => $"{Brand} {Model}";
    }

    public class Car : Vehicle
    {
        public Car(string brand, string model) : base(brand, model) { }
    }

    public class Truck : Vehicle
    {
        public Truck(string brand, string model) : base(brand, model) { }
    }

    public class Calculator
    {
        public void Perform(Action action) => action();
    }

    public class MyService
    {
        public void DoSomething() => Console.WriteLine("Делает секретные фуфелшмерцкие штуки...");
    }

    public class Client
    {
        private readonly MyService _service;
        public Client(MyService service) => _service = service;
        public void Execute() => _service.DoSomething();
    }

    public class Circle
    {
        private readonly double _radius;
        public Circle(double radius) => _radius = radius;
        public double CalculateArea() => Math.PI * _radius * _radius;
    }

    public class MathOperations
    {
        public int Add(int a, int b) => a + b;
    }

    class Program
    {
        static void Main1()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            IOutput output = new ConsoleOutput();
            var orderService = new OrderService(output);
            orderService.CreateOrder("Widget", 3, 9.99);
            orderService.UpdateOrder("Widget", 5, 9.99);

            Vehicle car = new Car("Toyota", "Corolla");
            Vehicle truck = new Truck("Volvo", "FH");
            car.Start();
            truck.Start();
            car.Stop();
            truck.Stop();

            var calculator = new Calculator();
            calculator.Perform(() => Console.WriteLine(2 + 3));

            var service = new MyService();
            var client = new Client(service);
            client.Execute();

            var circle = new Circle(2.5);
            Console.WriteLine(circle.CalculateArea().ToString("G17", CultureInfo.InvariantCulture));

            var ops = new MathOperations();
            Console.WriteLine(ops.Add(2, 3));
        }
    }
}
