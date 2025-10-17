using System;
using System.Linq;
using System.Threading.Tasks;
using AppProduct.Module_6.Prak6.StockObserver.Core;
using AppProduct.Module_6.Prak6.StockObserver.Observers;

namespace AppProduct.Module_6.Prak6.StockObserver
{
    class Program
    {
        static async Task Main()
        {
            var ex = new StockExchange();
            var alice = new ConsoleTrader("Alice");
            var bot = new AutoBot("Bot#1", buyBelow: 95m, sellAbove: 110m);
            var email = new EmailNotifier("alerts@stocks.dev");

            await ex.SubscribeAsync("AAPL", alice);
            await ex.SubscribeAsync("AAPL", bot);
            await ex.SubscribeAsync("AAPL", email, price => price >= 100m);
            await ex.SubscribeAsync("TSLA", alice);
            await ex.SubscribeAsync("TSLA", bot);

            var prices = new (string, decimal)[] { ("AAPL", 98m), ("TSLA", 205m), ("AAPL", 101m), ("TSLA", 90m), ("AAPL", 112m) };
            foreach (var (sym, p) in prices)
                await ex.UpdatePriceAsync(sym, p);

            var report = ex.ReportSubscriptions();
            Console.WriteLine("Subscriptions report:");
            foreach (var kv in report)
                Console.WriteLine($"{kv.Key}: {string.Join(", ", kv.Value)}");
        }
    }
}
