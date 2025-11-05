using LogisticsAdapterFactory.Abstractions;
using LogisticsAdapterFactory.Internal;
using LogisticsAdapterFactory.Adapters;
using LogisticsAdapterFactory.External;

namespace LogisticsAdapterFactory.Factory
{
    public static class DeliveryServiceFactory
    {
        // Simple factory illustrating DI at composition root.
        public static IInternalDeliveryService Create(string provider)
        {
            return provider switch
            {
                "internal" => new InternalDeliveryService(),
                "A"       => new LogisticsAdapterA(new ExternalLogisticsServiceA()),
                "B"       => new LogisticsAdapterB(new ExternalLogisticsServiceB()),
                "C"       => new LogisticsAdapterC(new ExternalLogisticsServiceC()),
                _         => new InternalDeliveryService()
            };
        }
    }
}
