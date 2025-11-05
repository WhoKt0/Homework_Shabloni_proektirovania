using LogisticsAdapterFactory.Abstractions;
using LogisticsAdapterFactory.External;

namespace LogisticsAdapterFactory.Adapters
{
    public class LogisticsAdapterB : IInternalDeliveryService
    {
        private readonly ExternalLogisticsServiceB _ext;
        public LogisticsAdapterB(ExternalLogisticsServiceB ext) => _ext = ext;

        public void DeliverOrder(string orderId)
        {
            _ext.SendPackage($"Order={orderId}");
        }

        public string GetDeliveryStatus(string orderId)
        {
            return _ext.CheckPackageStatus("TRACK-XYZ");
        }

        public double CalculateCost(double weightKg, string region) => _ext.Estimate(region, weightKg);
    }
}
