using System;
using System.Collections.Generic;
using System.Linq;
using AppProduct.Module_6.Dz6.Currency.Abstractions;

namespace AppProduct.Module_6.Dz6.Currency.Core
{
    public class CurrencyExchange : ISubject
    {
        readonly Dictionary<string, decimal> rates = new(StringComparer.OrdinalIgnoreCase);
        readonly Dictionary<string, List<IObserver>> subs = new(StringComparer.OrdinalIgnoreCase);

        public void RegisterObserver(string symbol, IObserver observer)
        {
            if (!subs.TryGetValue(symbol, out var list)) subs[symbol] = list = new List<IObserver>();
            if (!list.Contains(observer)) list.Add(observer);
        }

        public void RemoveObserver(string symbol, IObserver observer)
        {
            if (subs.TryGetValue(symbol, out var list)) list.Remove(observer);
        }

        public void SetRate(string symbol, decimal rate)
        {
            if (rate <= 0) return;
            rates[symbol] = rate;
            if (subs.TryGetValue(symbol, out var list))
                foreach (var o in list.ToList()) o.Update(symbol, rate);
        }
    }
}
