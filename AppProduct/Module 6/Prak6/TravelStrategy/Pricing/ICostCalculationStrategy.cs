namespace AppProduct.Module_6.Prak6.Travel.Pricing
{
    using AppProduct.Module_6.Prak6.Travel.Domain;
    public interface ICostCalculationStrategy
    {
        decimal Calculate(Trip trip);
        string Name { get; }
    }
}
