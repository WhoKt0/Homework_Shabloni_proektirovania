namespace AppProduct.Module_6.Lab6.Shipping.Domain.Strategies
{
    public class InternationalShippingStrategy : IShippingStrategy
    {
        public string Name => "International";
        public decimal CalculateShippingCost(decimal weight, decimal distance)
        {
            return weight * 1.0m + distance * 0.5m + 15m;
        }
    }
}
