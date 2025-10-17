using System;
using System.Threading.Tasks;
using AppProduct.Module_6.Prak6.StockObserver.Abstractions;

namespace AppProduct.Module_6.Prak6.StockObserver.Observers
{
    public class AutoBot : IObserver
    {
        public string Name { get; }
        private readonly decimal _buyBelow;
        private readonly decimal _sellAbove;
        public AutoBot(string name, decimal buyBelow, decimal sellAbove) { Name = name; _buyBelow = buyBelow; _sellAbove = sellAbove; }

        public Task OnPriceChangedAsync(string symbol, decimal newPrice)
        {
            if (newPrice <= _buyBelow)
                Console.WriteLine($"{Name}: BUY {symbol} at {newPrice}");
            else if (newPrice >= _sellAbove)
                Console.WriteLine($"{Name}: SELL {symbol} at {newPrice}");
            return Task.CompletedTask;
        }
    }
}
