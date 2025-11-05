using System;
using LogisticsAdapterFactory.Abstractions;

namespace LogisticsAdapterFactory.Internal
{
    public class InternalDeliveryService : IInternalDeliveryService
    {
        public void DeliverOrder(string orderId) => Console.WriteLine($"[Internal] Deliver {orderId}");
        public string GetDeliveryStatus(string orderId) => $"[Internal] Status for {orderId}: InTransit";
        public double CalculateCost(double weightKg, string region) => 5.0 + weightKg * 1.2;
    }
}
