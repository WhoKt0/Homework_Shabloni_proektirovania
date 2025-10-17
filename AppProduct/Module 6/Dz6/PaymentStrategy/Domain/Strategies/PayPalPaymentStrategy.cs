using System;
using System.Text.RegularExpressions;

namespace AppProduct.Module_6.Dz6.Payment.Domain.Strategies
{
    public class PayPalPaymentStrategy : IPaymentStrategy
    {
        public string Name => "PayPal";
        public string Email { get; }
        public PayPalPaymentStrategy(string email) { Email = email; }
        public bool Pay(decimal amount)
        {
            if (amount <= 0) return false;
            if (string.IsNullOrWhiteSpace(Email)) return false;
            if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) return false;
            Console.WriteLine($"Оплата {amount:C} через PayPal аккаунт {Email}");
            return true;
        }
    }
}
