namespace PaymentAdapter.Abstractions
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(double amount);
    }
}
