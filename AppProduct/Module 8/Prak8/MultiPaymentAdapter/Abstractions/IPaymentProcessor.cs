namespace MultiPaymentAdapter.Abstractions
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(double amount);
        void RefundPayment(double amount);
    }
}
