using System;
using MultiPaymentAdapter.Abstractions;
using MultiPaymentAdapter.Internal;
using MultiPaymentAdapter.External;
using MultiPaymentAdapter.Adapters;

namespace MultiPaymentAdapter
{
    public static class Program
    {
        public static void Main()
        {
            IPaymentProcessor internalP = new InternalPaymentProcessor();
            internalP.ProcessPayment(100);
            internalP.RefundPayment(40);

            IPaymentProcessor extA = new PaymentAdapterA(new ExternalPaymentSystemA());
            extA.ProcessPayment(200);
            extA.RefundPayment(50);

            IPaymentProcessor extB = new PaymentAdapterB(new ExternalPaymentSystemB());
            extB.ProcessPayment(300);
            extB.RefundPayment(60);
        }
    }
}
