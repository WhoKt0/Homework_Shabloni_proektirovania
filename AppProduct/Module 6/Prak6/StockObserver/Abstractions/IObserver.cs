using System.Threading.Tasks;

namespace AppProduct.Module_6.Prak6.StockObserver.Abstractions
{
    public interface IObserver
    {
        string Name { get; }
        Task OnPriceChangedAsync(string symbol, decimal newPrice);
    }
}
