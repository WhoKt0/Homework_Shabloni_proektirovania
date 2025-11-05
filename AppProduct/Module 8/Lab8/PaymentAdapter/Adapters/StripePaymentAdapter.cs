using PaymentAdapter.Abstractions;
using PaymentAdapter.External;

namespace PaymentAdapter.Adapters
{
    // Adapter re-exposes Stripe as our IPaymentProcessor
    public class StripePaymentAdapter : IPaymentProcessor
    {
        private readonly StripePaymentService _stripe;
        public StripePaymentAdapter(StripePaymentService stripe) => _stripe = stripe;

        public void ProcessPayment(double amount) => _stripe.MakeTransaction(amount);
    }
}
