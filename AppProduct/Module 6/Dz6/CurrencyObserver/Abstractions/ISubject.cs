namespace AppProduct.Module_6.Dz6.Currency.Abstractions
{
    public interface ISubject
    {
        void RegisterObserver(string symbol, IObserver observer);
        void RemoveObserver(string symbol, IObserver observer);
        void SetRate(string symbol, decimal rate);
    }
}
