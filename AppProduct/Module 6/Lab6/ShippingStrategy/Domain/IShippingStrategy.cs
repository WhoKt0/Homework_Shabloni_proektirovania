namespace AppProduct.Module_6.Lab6.Shipping.Domain
{
    public interface IShippingStrategy
    {
        decimal CalculateShippingCost(decimal weight, decimal distance);
        string Name { get; }
    }
}
