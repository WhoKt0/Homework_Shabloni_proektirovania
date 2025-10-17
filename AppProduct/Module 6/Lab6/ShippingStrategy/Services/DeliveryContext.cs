using System;
using AppProduct.Module_6.Lab6.Shipping.Domain;

namespace AppProduct.Module_6.Lab6.Shipping.Services
{
    public class DeliveryContext
    {
        private IShippingStrategy _shippingStrategy;
        public void SetShippingStrategy(IShippingStrategy strategy)
        {
            _shippingStrategy = strategy;
        }
        public decimal CalculateCost(decimal weight, decimal distance)
        {
            if (_shippingStrategy == null) throw new InvalidOperationException("Стратегия доставки не установлена.");
            if (weight <= 0 || distance <= 0) throw new ArgumentOutOfRangeException("Вес и расстояние должны быть положительными.");
            return _shippingStrategy.CalculateShippingCost(weight, distance);
        }
    }
}
