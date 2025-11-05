using System;

namespace MultiPaymentAdapter.External
{
    public class ExternalPaymentSystemA
    {
        public void MakePayment(double amount) => Console.WriteLine($"[ExtA] MakePayment {amount:0.00}");
        public void MakeRefund(double amount)  => Console.WriteLine($"[ExtA] MakeRefund {amount:0.00}");
    }
}
