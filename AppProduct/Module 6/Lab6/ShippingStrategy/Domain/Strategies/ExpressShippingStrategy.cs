namespace AppProduct.Module_6.Lab6.Shipping.Domain.Strategies
{
    public class ExpressShippingStrategy : IShippingStrategy
    {
        public string Name => "Express";
        public decimal CalculateShippingCost(decimal weight, decimal distance)
        {
            return (weight * 0.75m + distance * 0.2m) + 10m;
        }
    }
}
