using System;
using PaymentAdapter.Abstractions;
using PaymentAdapter.Internal;
using PaymentAdapter.External;
using PaymentAdapter.Adapters;

namespace PaymentAdapter
{
    public static class Program
    {
        public static void Main()
        {
            IPaymentProcessor paypal = new PayPalPaymentProcessor();
            paypal.ProcessPayment(100.0);

            IPaymentProcessor stripe = new StripePaymentAdapter(new StripePaymentService());
            stripe.ProcessPayment(150.0);
        }
    }
}
