using MultiPaymentAdapter.Abstractions;
using MultiPaymentAdapter.External;

namespace MultiPaymentAdapter.Adapters
{
    public class PaymentAdapterA : IPaymentProcessor
    {
        private readonly ExternalPaymentSystemA _ext;
        public PaymentAdapterA(ExternalPaymentSystemA ext) => _ext = ext;
        public void ProcessPayment(double amount) => _ext.MakePayment(amount);
        public void RefundPayment(double amount)  => _ext.MakeRefund(amount);
    }
}
