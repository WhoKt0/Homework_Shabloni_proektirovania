using System;
using MultiPaymentAdapter.Abstractions;

namespace MultiPaymentAdapter.Internal
{
    public class InternalPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(double amount) => Console.WriteLine($"[Internal] Paid {amount:0.00}");
        public void RefundPayment(double amount)  => Console.WriteLine($"[Internal] Refunded {amount:0.00}");
    }
}
