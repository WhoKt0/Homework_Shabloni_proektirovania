using System;
using LogisticsAdapterFactory.Factory;
using LogisticsAdapterFactory.Abstractions;

namespace LogisticsAdapterFactory
{
    public static class Program
    {
        public static void Main()
        {
            IInternalDeliveryService s1 = DeliveryServiceFactory.Create("internal");
            s1.DeliverOrder("101");
            Console.WriteLine(s1.GetDeliveryStatus("101"));
            Console.WriteLine("Cost: " + s1.CalculateCost(2.5, "EU"));

            IInternalDeliveryService s2 = DeliveryServiceFactory.Create("A");
            s2.DeliverOrder("202");
            Console.WriteLine(s2.GetDeliveryStatus("202"));
            Console.WriteLine("Cost: " + s2.CalculateCost(3.0, "EU"));

            IInternalDeliveryService s3 = DeliveryServiceFactory.Create("B");
            s3.DeliverOrder("303");
            Console.WriteLine(s3.GetDeliveryStatus("303"));
            Console.WriteLine("Cost: " + s3.CalculateCost(1.2, "KZ"));
        }
    }
}
