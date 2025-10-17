using System;
using System.Threading.Tasks;
using AppProduct.Module_6.Prak6.StockObserver.Abstractions;

namespace AppProduct.Module_6.Prak6.StockObserver.Observers
{
    public class EmailNotifier : IObserver
    {
        public string Name { get; }
        private readonly string _email;
        public EmailNotifier(string email) { _email = email; Name = $"Email<{email}>"; }
        public Task OnPriceChangedAsync(string symbol, decimal newPrice)
        {
            Console.WriteLine($"{Name}: notify {symbol} price {newPrice}");
            return Task.CompletedTask;
        }
    }
}
