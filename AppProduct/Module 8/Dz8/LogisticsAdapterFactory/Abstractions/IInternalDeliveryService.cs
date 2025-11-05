namespace LogisticsAdapterFactory.Abstractions
{
    public interface IInternalDeliveryService
    {
        void DeliverOrder(string orderId);
        string GetDeliveryStatus(string orderId);
        double CalculateCost(double weightKg, string region);
    }
}
