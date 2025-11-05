using System;

namespace PaymentAdapter.External
{
    // Third-party service with a different interface.
    public class StripePaymentService
    {
        public void MakeTransaction(double totalAmount)
        {
            Console.WriteLine($"[Stripe] Transaction for {totalAmount:0.00} processed.");
        }
    }
}
