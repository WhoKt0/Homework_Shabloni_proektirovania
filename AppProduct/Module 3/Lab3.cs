using System;
using System.Collections.Generic;

namespace AppProduct.Module_3.Lab3.cs
{

    public class Item
    {
        public string Description { get; }
        public decimal Price { get; }
        public Item(string description, decimal price) { Description = description; Price = price; }
    }

    public class Invoice
    {
        public int Id { get; set; }
        public List<Item> Items { get; } = new List<Item>();
        public decimal TaxRate { get; set; }
        public Invoice(int id, decimal taxRate = 0.0m) { Id = id; TaxRate = taxRate; }
    }

    public class InvoiceCalculator
    {
        public decimal CalculateSubtotal(Invoice invoice)
        {
            decimal subtotal = 0m;
            foreach (var it in invoice.Items) subtotal += it.Price;
            return subtotal;
        }

        public decimal CalculateTotal(Invoice invoice)
        {
            var subtotal = CalculateSubtotal(invoice);
            return subtotal + (subtotal * invoice.TaxRate);
        }
    }

    public interface IInvoiceRepository
    {
        bool Save(Invoice invoice);
    }

    public class InMemoryInvoiceRepository : IInvoiceRepository
    {
        private readonly List<Invoice> _store = new List<Invoice>();
        public bool Save(Invoice invoice)
        {
            _store.Add(invoice);
            Console.WriteLine($"Invoice {invoice.Id} saved. Items: {_store.Count}");
            return true;
        }
    }
    public interface IDiscountPolicy
    {
        decimal Apply(decimal amount);
    }

    public class NoDiscountPolicy : IDiscountPolicy
    {
        public decimal Apply(decimal amount) => amount;
    }

    public class TenPercentDiscountPolicy : IDiscountPolicy
    {
        public decimal Apply(decimal amount) => amount * 0.9m;
    }

    public class TwentyPercentDiscountPolicy : IDiscountPolicy
    {
        public decimal Apply(decimal amount) => amount * 0.8m;
    }

    public class DiscountCalculator
    {
        private readonly IDiscountPolicy _policy;
        public DiscountCalculator(IDiscountPolicy policy) => _policy = policy;
        public decimal Calculate(decimal amount) => _policy.Apply(amount);
    }
    public interface IWork
    {
        void Work();
    }

    public interface IEat
    {
        void Eat();
    }

    public interface ISleep
    {
        void Sleep();
    }

    public class HumanWorker : IWork, IEat, ISleep
    {
        private readonly string _name;
        public HumanWorker(string name) { _name = name; }
        public void Work() => Console.WriteLine($"{_name} is working.");
        public void Eat() => Console.WriteLine($"{_name} is eating.");
        public void Sleep() => Console.WriteLine($"{_name} is sleeping.");
    }

    public class RobotWorker : IWork
    {
        private readonly string _id;
        public RobotWorker(string id) { _id = id; }
        public void Work() => Console.WriteLine($"Robot {_id} is working.");
    }
    public interface INotificationService
    {
        void Send(string message);
    }

    public class EmailService : INotificationService
    {
        private readonly string _from;
        public EmailService(string from) => _from = from;
        public void Send(string message) => Console.WriteLine($"Email from {_from}: {message}");
    }

    public class SmsService : INotificationService
    {
        private readonly string _provider;
        public SmsService(string provider) => _provider = provider;
        public void Send(string message) => Console.WriteLine($"SMS via {_provider}: {message}");
    }

    public class Notification
    {
        private readonly INotificationService _service;
        public Notification(INotificationService service) => _service = service;
        public void Send(string message) => _service.Send(message);
    }

    class Program
    {
        static void Main()
        {
            var invoice = new Invoice(id: 1, taxRate: 0.10m);
            invoice.Items.Add(new Item("Widget A", 100m));
            invoice.Items.Add(new Item("Widget B", 50m));

            var calculator = new InvoiceCalculator();
            var subtotal = calculator.CalculateSubtotal(invoice);
            var total = calculator.CalculateTotal(invoice);
            Console.WriteLine($"Invoice {invoice.Id} subtotal: {subtotal}, total(with tax): {total}");

            IInvoiceRepository repo = new InMemoryInvoiceRepository();
            repo.Save(invoice);

            IDiscountPolicy regular = new NoDiscountPolicy();
            IDiscountPolicy silver = new TenPercentDiscountPolicy();
            IDiscountPolicy gold = new TwentyPercentDiscountPolicy();

            var regularCalc = new DiscountCalculator(regular);
            var silverCalc = new DiscountCalculator(silver);
            var goldCalc = new DiscountCalculator(gold);

            decimal amount = 200m;
            Console.WriteLine($"Regular: {regularCalc.Calculate(amount)}");
            Console.WriteLine($"Silver: {silverCalc.Calculate(amount)}");
            Console.WriteLine($"Gold: {goldCalc.Calculate(amount)}");

            IWork human = new HumanWorker("Alice");
            ((IEat)human as IEat)?.Eat();
            ((ISleep)human as ISleep)?.Sleep();
            human.Work();

            IWork robot = new RobotWorker("RX-1");
            robot.Work();

            INotificationService email = new EmailService("no-reply@company.com");
            var notification = new Notification(email);
            notification.Send("Invoice created.");

            INotificationService sms = new SmsService("FastSMS");
            var notification2 = new Notification(sms);
            notification2.Send("Invoice sent via SMS.");
        }
    }
}
