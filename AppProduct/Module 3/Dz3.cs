using System;
using System.Collections.Generic;
using System.Linq;

namespace AppProduct.Module_3.Dz3.cs
{
    public class Order
    {
        public string ProductName { get; }
        public int Quantity { get; private set; }
        public decimal Price { get; }
        public string CustomerEmail { get; }

        public Order(string productName, int quantity, decimal price, string customerEmail)
        {
            ProductName = productName;
            Quantity = Math.Max(0, quantity);
            Price = price;
            CustomerEmail = customerEmail;
        }

        public void IncreaseQuantity(int delta)
        {
            if (delta > 0) Quantity += delta;
        }
    }

    public interface IOrderCalculator
    {
        decimal CalculateTotal(Order order);
    }

    public class SimpleOrderCalculator : IOrderCalculator
    {
        private readonly IEnumerable<IDiscountRule> _discountRules;

        public SimpleOrderCalculator(IEnumerable<IDiscountRule> discountRules)
        {
            _discountRules = discountRules ?? Enumerable.Empty<IDiscountRule>();
        }

        public decimal CalculateTotal(Order order)
        {
            var subtotal = order.Quantity * order.Price;
            var discount = _discountRules.Sum(r => r.Calculate(subtotal));
            var total = subtotal - discount;
            return total < 0 ? 0m : total;
        }
    }

    public interface IDiscountRule
    {
        decimal Calculate(decimal subtotal);
    }

    public class PercentOffRule : IDiscountRule
    {
        private readonly decimal _percent;
        public PercentOffRule(decimal percent) { _percent = percent; }
        public decimal Calculate(decimal subtotal) => subtotal * _percent;
    }

    public class FixedAmountRule : IDiscountRule
    {
        private readonly decimal _amount;
        public FixedAmountRule(decimal amount) { _amount = amount; }
        public decimal Calculate(decimal subtotal) => subtotal >= _amount ? _amount : 0m;
    }

    public interface IPaymentMethod
    {
        bool Pay(decimal amount);
        string Name { get; }
    }

    public class CreditCardPayment : IPaymentMethod
    {
        private readonly string _card;
        public string Name => "CreditCard";
        public CreditCardPayment(string card) { _card = card; }
        public bool Pay(decimal amount)
        {
            Console.WriteLine($"Charging {_card} amount {amount:C}");
            return amount > 0;
        }
    }

    public class PayPalPaymentMethod : IPaymentMethod
    {
        private readonly string _account;
        public string Name => "PayPal";
        public PayPalPaymentMethod(string account) { _account = account; }
        public bool Pay(decimal amount)
        {
            Console.WriteLine($"PayPal {_account} charged {amount:C}");
            return amount > 0;
        }
    }

    public interface IPaymentProcessor
    {
        bool ProcessPayment(IPaymentMethod method, decimal amount);
    }

    public class PaymentProcessor : IPaymentProcessor
    {
        public bool ProcessPayment(IPaymentMethod method, decimal amount) => method.Pay(amount);
    }

    public interface INotificationSender
    {
        void Send(string to, string message);
    }

    public class EmailSender : INotificationSender
    {
        private readonly string _from;
        public EmailSender(string from) { _from = from; }
        public void Send(string to, string message) => Console.WriteLine($"Email from {_from} to {to}: {message}");
    }

    public class SmsSender : INotificationSender
    {
        private readonly string _provider;
        public SmsSender(string provider) { _provider = provider; }
        public void Send(string to, string message) => Console.WriteLine($"SMS via {_provider} to {to}: {message}");
    }

    public class NotificationService
    {
        private readonly IEnumerable<INotificationSender> _senders;
        public NotificationService(IEnumerable<INotificationSender> senders) { _senders = senders ?? Enumerable.Empty<INotificationSender>(); }
        public void NotifyCustomer(string to, string message)
        {
            foreach (var s in _senders) s.Send(to, message);
        }
    }

    public class OrderService
    {
        private readonly IOrderCalculator _calculator;
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly NotificationService _notifier;

        public OrderService(IOrderCalculator calculator, IPaymentProcessor paymentProcessor, NotificationService notifier)
        {
            _calculator = calculator;
            _paymentProcessor = paymentProcessor;
            _notifier = notifier;
        }

        public bool PlaceOrder(Order order, IPaymentMethod paymentMethod)
        {
            var total = _calculator.CalculateTotal(order);
            _notifier.NotifyCustomer(order.CustomerEmail, $"Your order total is {total:C}. Payment method: {paymentMethod.Name}");
            var ok = _paymentProcessor.ProcessPayment(paymentMethod, total);
            _notifier.NotifyCustomer(order.CustomerEmail, ok ? "Payment successful" : "Payment failed");
            return ok;
        }
    }

    public class Employee
    {
        public string Name { get; }
        public decimal BaseSalary { get; }
        public ISalaryStrategy SalaryStrategy { get; }

        public Employee(string name, decimal baseSalary, ISalaryStrategy salaryStrategy)
        {
            Name = name;
            BaseSalary = baseSalary;
            SalaryStrategy = salaryStrategy;
        }
    }

    public interface ISalaryStrategy
    {
        decimal Calculate(Employee employee);
    }

    public class PermanentSalaryStrategy : ISalaryStrategy
    {
        public decimal Calculate(Employee employee) => employee.BaseSalary * 1.2m;
    }

    public class ContractSalaryStrategy : ISalaryStrategy
    {
        public decimal Calculate(Employee employee) => employee.BaseSalary * 1.1m;
    }

    public class InternSalaryStrategy : ISalaryStrategy
    {
        public decimal Calculate(Employee employee) => employee.BaseSalary * 0.8m;
    }

    public class EmployeeSalaryCalculator
    {
        public decimal CalculateSalary(Employee employee) => employee.SalaryStrategy.Calculate(employee);
    }

    public interface IPrinter
    {
        void Print(string content);
    }

    public interface IScanner
    {
        void Scan(string content);
    }

    public interface IFax
    {
        void Fax(string content);
    }

    public class AllInOnePrinter : IPrinter, IScanner, IFax
    {
        public void Print(string content) => Console.WriteLine("Print: " + content);
        public void Scan(string content) => Console.WriteLine("Scan: " + content);
        public void Fax(string content) => Console.WriteLine("Fax: " + content);
    }

    public class BasicPrinter : IPrinter
    {
        public void Print(string content) => Console.WriteLine("Print: " + content);
    }

    class Program
    {
        static void Main1()
        {
            var discounts = new IDiscountRule[] { new PercentOffRule(0.1m), new FixedAmountRule(5m) };
            var calculator = new SimpleOrderCalculator(discounts);
            var paymentProcessor = new PaymentProcessor();
            var senders = new INotificationSender[] { new EmailSender("shop@store.com"), new SmsSender("FastSMS") };
            var notifier = new NotificationService(senders);
            var orderService = new OrderService(calculator, paymentProcessor, notifier);

            var order = new Order("Book", 3, 15.00m, "customer@example.com");
            var payment = new CreditCardPayment("4111-xxxx-xxxx-1111");
            orderService.PlaceOrder(order, payment);

            var emp1 = new Employee("Alice", 1000m, new PermanentSalaryStrategy());
            var emp2 = new Employee("Bob", 800m, new ContractSalaryStrategy());
            var emp3 = new Employee("Intern", 400m, new InternSalaryStrategy());
            var salaryCalc = new EmployeeSalaryCalculator();
            Console.WriteLine($"{emp1.Name} salary: {salaryCalc.CalculateSalary(emp1):C}");
            Console.WriteLine($"{emp2.Name} salary: {salaryCalc.CalculateSalary(emp2):C}");
            Console.WriteLine($"{emp3.Name} salary: {salaryCalc.CalculateSalary(emp3):C}");

            IPrinter p1 = new BasicPrinter();
            p1.Print("Hello World");

            IPrinter p2 = new AllInOnePrinter();
            p2.Print("Doc");
            ((IScanner)p2).Scan("Doc");
            ((IFax)p2).Fax("Doc");
        }
    }
}
