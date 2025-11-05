using System;

namespace MultiPaymentAdapter.External
{
    public class ExternalPaymentSystemB
    {
        public void SendPayment(double amount)     => Console.WriteLine($"[ExtB] SendPayment {amount:0.00}");
        public void ProcessRefund(double amount)   => Console.WriteLine($"[ExtB] ProcessRefund {amount:0.00}");
    }
}
