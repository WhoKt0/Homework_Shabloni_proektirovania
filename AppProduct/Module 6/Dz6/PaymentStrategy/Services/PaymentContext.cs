using System;
using AppProduct.Module_6.Dz6.Payment.Domain;

namespace AppProduct.Module_6.Dz6.Payment.Services
{
    public class PaymentContext
    {
        IPaymentStrategy _strategy;
        public void SetStrategy(IPaymentStrategy strategy) { _strategy = strategy; }
        public bool Pay(decimal amount)
        {
            if (_strategy == null) throw new InvalidOperationException("Стратегия оплаты не установлена.");
            return _strategy.Pay(amount);
        }
    }
}
