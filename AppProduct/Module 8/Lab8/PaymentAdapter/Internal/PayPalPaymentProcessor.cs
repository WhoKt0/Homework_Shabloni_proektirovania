using System;
using PaymentAdapter.Abstractions;

namespace PaymentAdapter.Internal
{
    public class PayPalPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"[PayPal] Paid {amount:0.00}");
        }
    }
}
