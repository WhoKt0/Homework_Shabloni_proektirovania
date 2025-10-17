namespace AppProduct.Module_6.Dz6.Payment.Domain
{
    public interface IPaymentStrategy
    {
        string Name { get; }
        bool Pay(decimal amount);
    }
}
