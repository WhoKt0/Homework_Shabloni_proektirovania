using System;
using System.Collections.Generic;
using System.Linq;

namespace AppProduct.Module_3
{
    public class Product
    {
        public string Name { get; }
        public decimal Price { get; }
        public Product(string name, decimal price) { Name = name; Price = price; }
    }

    public class OrderItem
    {
        public Product Product { get; }
        public int Quantity { get; private set; }
        public OrderItem(Product product, int quantity) { Product = product; Quantity = quantity; }
        public decimal LineTotal() => Product.Price * Quantity;
        public void Increase(int delta) { if (delta > 0) Quantity += delta; }
    }

    public class Order
    {
        public Guid Id { get; } = Guid.NewGuid();
        private readonly List<OrderItem> _items = new List<OrderItem>();
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
        public string CustomerEmail { get; }
        public Order(string customerEmail) { CustomerEmail = customerEmail; }

        public void AddItem(Product product, int quantity)
        {
            if (product == null || quantity <= 0) return;
            var existing = _items.FirstOrDefault(i => i.Product.Name == product.Name);
            if (existing != null) existing.Increase(quantity);
            else _items.Add(new OrderItem(product, quantity));
        }

        public decimal Subtotal() => _items.Sum(i => i.LineTotal());
    }

    public interface IPayment
    {
        bool ProcessPayment(decimal amount);
        string PaymentName { get; }
    }

    public class CreditCardPayment : IPayment
    {
        private readonly string _cardNumber;
        public string PaymentName => "CreditCard";
        public CreditCardPayment(string cardNumber) { _cardNumber = cardNumber; }
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment {_cardNumber} for {amount:C}");
            return amount > 0;
        }
    }

    public class PayPalPayment : IPayment
    {
        private readonly string _account;
        public string PaymentName => "PayPal";
        public PayPalPayment(string account) { _account = account; }
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment {_account} for {amount:C}");
            return amount > 0;
        }
    }

    public class BankTransferPayment : IPayment
    {
        private readonly string _iban;
        public string PaymentName => "BankTransfer";
        public BankTransferPayment(string iban) { _iban = iban; }
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing bank transfer {_iban} for {amount:C}");
            return amount > 0;
        }
    }

    public interface IDelivery
    {
        bool DeliverOrder(Order order);
        string DeliveryName { get; }
    }

    public class CourierDelivery : IDelivery
    {
        public string DeliveryName => "Courier";
        public bool DeliverOrder(Order order)
        {
            Console.WriteLine($"Courier will deliver order {order.Id} to {order.CustomerEmail}");
            return true;
        }
    }

    public class PostDelivery : IDelivery
    {
        public string DeliveryName => "Post";
        public bool DeliverOrder(Order order)
        {
            Console.WriteLine($"Post service queued delivery for order {order.Id}");
            return true;
        }
    }

    public class PickUpPointDelivery : IDelivery
    {
        public string DeliveryName => "PickUpPoint";
        public bool DeliverOrder(Order order)
        {
            Console.WriteLine($"Order {order.Id} will be available at pickup point");
            return true;
        }
    }

    public interface INotification
    {
        void SendNotification(string to, string message);
    }

    public class EmailNotification : INotification
    {
        public void SendNotification(string to, string message)
        {
            Console.WriteLine($"Email to {to}: {message}");
        }
    }

    public class SmsNotification : INotification
    {
        public void SendNotification(string to, string message)
        {
            Console.WriteLine($"SMS to {to}: {message}");
        }
    }

    public interface IDiscountRule
    {
        decimal Calculate(Order order);
    }

    public class PercentageDiscountRule : IDiscountRule
    {
        private readonly decimal _percent;
        public PercentageDiscountRule(decimal percent) { _percent = percent; }
        public decimal Calculate(Order order) => order.Subtotal() * _percent;
    }

    public class ThresholdDiscountRule : IDiscountRule
    {
        private readonly decimal _threshold;
        private readonly decimal _discountAmount;
        public ThresholdDiscountRule(decimal threshold, decimal discountAmount) { _threshold = threshold; _discountAmount = discountAmount; }
        public decimal Calculate(Order order) => order.Subtotal() >= _threshold ? _discountAmount : 0m;
    }

    public class DiscountCalculator
    {
        private readonly IEnumerable<IDiscountRule> _rules;
        public DiscountCalculator(IEnumerable<IDiscountRule> rules) { _rules = rules ?? Enumerable.Empty<IDiscountRule>(); }
        public decimal CalculateTotalWithDiscounts(Order order)
        {
            var subtotal = order.Subtotal();
            var totalDiscount = _rules.Sum(r => r.Calculate(order));
            var total = subtotal - totalDiscount;
            return total < 0 ? 0m : total;
        }
    }

    public class OrderProcessor
    {
        private readonly DiscountCalculator _discountCalculator;
        private readonly INotification _notification;
        public OrderProcessor(DiscountCalculator discountCalculator, INotification notification)
        {
            _discountCalculator = discountCalculator;
            _notification = notification;
        }

        public bool Process(Order order, IPayment payment, IDelivery delivery)
        {
            var amountToPay = _discountCalculator.CalculateTotalWithDiscounts(order);
            _notification.SendNotification(order.CustomerEmail, $"Your order {order.Id} total is {amountToPay:C}. Payment method: {payment.PaymentName}.");
            var paid = payment.ProcessPayment(amountToPay);
            if (!paid)
            {
                _notification.SendNotification(order.CustomerEmail, $"Payment failed for order {order.Id}.");
                return false;
            }
            var delivered = delivery.DeliverOrder(order);
            if (delivered)
            {
                _notification.SendNotification(order.CustomerEmail, $"Order {order.Id} processed and sent via {delivery.DeliveryName}.");
                return true;
            }
            _notification.SendNotification(order.CustomerEmail, $"Delivery failed for order {order.Id}.");
            return false;
        }
    }

    class Program
    {
        static void Main1()
        {
            var prodA = new Product("T-shirt", 20m);
            var prodB = new Product("Mug", 7.5m);

            var order = new Order("customer@example.com");
            order.AddItem(prodA, 2);
            order.AddItem(prodB, 3);

            var rules = new IDiscountRule[]
            {
                new PercentageDiscountRule(0.05m),
                new ThresholdDiscountRule(100m, 10m)
            };

            var discountCalculator = new DiscountCalculator(rules);
            INotification notifier = new EmailNotification();
            var processor = new OrderProcessor(discountCalculator, notifier);

            IPayment payment = new CreditCardPayment("4111-xxxx-xxxx-1111");
            IDelivery delivery = new CourierDelivery();

            processor.Process(order, payment, delivery);
        }
    }
}
