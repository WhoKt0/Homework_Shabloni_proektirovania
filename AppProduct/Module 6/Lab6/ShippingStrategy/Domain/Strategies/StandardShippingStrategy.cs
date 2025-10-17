namespace AppProduct.Module_6.Lab6.Shipping.Domain.Strategies
{
    public class StandardShippingStrategy : IShippingStrategy
    {
        public string Name => "Standard";
        public decimal CalculateShippingCost(decimal weight, decimal distance)
        {
            return weight * 0.5m + distance * 0.1m;
        }
    }
}
