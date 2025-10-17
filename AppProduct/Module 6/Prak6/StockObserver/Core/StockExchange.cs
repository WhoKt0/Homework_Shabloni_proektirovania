using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppProduct.Module_6.Prak6.StockObserver.Abstractions;

namespace AppProduct.Module_6.Prak6.StockObserver.Core
{
    public class StockExchange : ISubject
    {
        private readonly ConcurrentDictionary<string, decimal> _prices = new(StringComparer.OrdinalIgnoreCase);
        private readonly ConcurrentDictionary<string, List<(IObserver observer, Func<decimal,bool>? filter)>> _subs = new(StringComparer.OrdinalIgnoreCase);

        public Task SubscribeAsync(string symbol, IObserver observer) => SubscribeAsync(symbol, observer, null);

        public Task SubscribeAsync(string symbol, IObserver observer, Func<decimal,bool>? filter)
        {
            var list = _subs.GetOrAdd(symbol, _ => new List<(IObserver, Func<decimal,bool>?)>());
            lock (list) list.Add((observer, filter));
            return Task.CompletedTask;
        }

        public Task UnsubscribeAsync(string symbol, IObserver observer)
        {
            if (_subs.TryGetValue(symbol, out var list))
            {
                lock (list) list.RemoveAll(x => ReferenceEquals(x.observer, observer));
            }
            return Task.CompletedTask;
        }

        public async Task UpdatePriceAsync(string symbol, decimal newPrice)
        {
            _prices[symbol] = newPrice;
            if (_subs.TryGetValue(symbol, out var list))
            {
                List<(IObserver observer, Func<decimal,bool>? filter)> snapshot;
                lock (list) snapshot = list.ToList();
                var tasks = new List<Task>(snapshot.Count);
                foreach (var (obs, filter) in snapshot)
                {
                    if (filter != null && !filter(newPrice)) continue;
                    tasks.Add(obs.OnPriceChangedAsync(symbol, newPrice));
                }
                await Task.WhenAll(tasks);
            }
        }

        public Dictionary<string, List<string>> ReportSubscriptions()
        {
            var result = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            foreach (var kv in _subs)
            {
                lock (kv.Value) result[kv.Key] = kv.Value.Select(x => x.observer.Name).ToList();
            }
            return result;
        }
    }
}
