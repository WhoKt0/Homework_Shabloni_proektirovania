using System;
using System.Text.RegularExpressions;

namespace AppProduct.Module_6.Dz6.Payment.Domain.Strategies
{
    public class CardPaymentStrategy : IPaymentStrategy
    {
        public string Name => "Card";
        public string CardNumber { get; }
        public string Holder { get; }
        public string Cvv { get; }
        public CardPaymentStrategy(string cardNumber, string holder, string cvv)
        {
            CardNumber = cardNumber; Holder = holder; Cvv = cvv;
        }
        public bool Pay(decimal amount)
        {
            if (amount <= 0) return false;
            if (string.IsNullOrWhiteSpace(CardNumber) || string.IsNullOrWhiteSpace(Cvv)) return false;
            if (!Regex.IsMatch(CardNumber.Replace(" ", ""), @"^\d{13,19}$")) return false;
            if (!Regex.IsMatch(Cvv, @"^\d{3,4}$")) return false;
            Console.WriteLine($"Оплата {amount:C} банковской картой {Mask(CardNumber)} держатель {Holder}");
            return true;
        }
        static string Mask(string n)
        {
            var d = n.Replace(" ", "");
            if (d.Length < 8) return "****";
            return d[:4] + " **** **** " + d[-4:];
        }
    }
}
