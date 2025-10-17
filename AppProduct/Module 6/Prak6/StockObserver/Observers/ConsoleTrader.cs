using System;
using System.Threading.Tasks;
using AppProduct.Module_6.Prak6.StockObserver.Abstractions;

namespace AppProduct.Module_6.Prak6.StockObserver.Observers
{
    public class ConsoleTrader : IObserver
    {
        public string Name { get; }
        public ConsoleTrader(string name) { Name = name; }
        public Task OnPriceChangedAsync(string symbol, decimal newPrice)
        {
            Console.WriteLine($"{Name}: {symbol} = {newPrice}");
            return Task.CompletedTask;
        }
    }
}
