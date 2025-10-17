namespace AppProduct.Module_6.Lab6.Shipping.Domain.Strategies
{
    public class NightShippingStrategy : IShippingStrategy
    {
        public string Name => "Night";
        public decimal CalculateShippingCost(decimal weight, decimal distance)
        {
            return (weight * 0.6m + distance * 0.15m) + 20m;
        }
    }
}
