using System;
using AppProduct.Module_6.Dz6.Currency.Abstractions;

namespace AppProduct.Module_6.Dz6.Currency.Observers
{
    public class ThresholdAlert : IObserver
    {
        public string Name { get; }
        readonly decimal _min;
        readonly decimal _max;
        public ThresholdAlert(string name, decimal min, decimal max) { Name = name; _min = min; _max = max; }
        public void Update(string symbol, decimal rate)
        {
            if (rate < _min) Console.WriteLine($"{Name}: {symbol} упал ниже {_min}, сейчас {rate}");
            else if (rate > _max) Console.WriteLine($"{Name}: {symbol} вырос выше {_max}, сейчас {rate}");
        }
    }
}
