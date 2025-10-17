namespace AppProduct.Module_6.Dz6.Currency.Abstractions
{
    public interface IObserver
    {
        string Name { get; }
        void Update(string symbol, decimal rate);
    }
}
