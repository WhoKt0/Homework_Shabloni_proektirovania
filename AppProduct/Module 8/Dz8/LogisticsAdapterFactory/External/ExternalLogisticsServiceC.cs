using System;

namespace LogisticsAdapterFactory.External
{
    public class ExternalLogisticsServiceC
    {
        public Guid CreateOrder(string orderId) { Console.WriteLine($"[ExtC] Create order {orderId}"); return Guid.NewGuid(); }
        public string Query(Guid id) => $"[ExtC] {id} -> Pending";
        public double Calc(double baseCost, double weightKg) => baseCost + weightKg * 0.8;
    }
}
