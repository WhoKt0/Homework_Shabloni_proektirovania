using System.Threading.Tasks;

namespace AppProduct.Module_6.Prak6.StockObserver.Abstractions
{
    public interface ISubject
    {
        Task SubscribeAsync(string symbol, IObserver observer);
        Task UnsubscribeAsync(string symbol, IObserver observer);
        Task UpdatePriceAsync(string symbol, decimal newPrice);
    }
}
