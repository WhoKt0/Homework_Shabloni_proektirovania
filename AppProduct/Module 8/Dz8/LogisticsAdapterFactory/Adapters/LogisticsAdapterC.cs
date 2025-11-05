using System;
using LogisticsAdapterFactory.Abstractions;
using LogisticsAdapterFactory.External;

namespace LogisticsAdapterFactory.Adapters
{
    public class LogisticsAdapterC : IInternalDeliveryService
    {
        private readonly ExternalLogisticsServiceC _ext;
        public LogisticsAdapterC(ExternalLogisticsServiceC ext) => _ext = ext;

        public void DeliverOrder(string orderId)
        {
            _ext.CreateOrder(orderId);
        }

        public string GetDeliveryStatus(string orderId)
        {
            return _ext.Query(Guid.Empty);
        }

        public double CalculateCost(double weightKg, string region) => _ext.Calc(8.0, weightKg);
    }
}
