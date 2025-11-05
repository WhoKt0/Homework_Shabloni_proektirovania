using MultiPaymentAdapter.Abstractions;
using MultiPaymentAdapter.External;

namespace MultiPaymentAdapter.Adapters
{
    public class PaymentAdapterB : IPaymentProcessor
    {
        private readonly ExternalPaymentSystemB _ext;
        public PaymentAdapterB(ExternalPaymentSystemB ext) => _ext = ext;
        public void ProcessPayment(double amount) => _ext.SendPayment(amount);
        public void RefundPayment(double amount)  => _ext.ProcessRefund(amount);
    }
}
