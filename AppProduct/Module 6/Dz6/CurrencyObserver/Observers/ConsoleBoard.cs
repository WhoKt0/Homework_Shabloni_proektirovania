using System;
using AppProduct.Module_6.Dz6.Currency.Abstractions;

namespace AppProduct.Module_6.Dz6.Currency.Observers
{
    public class ConsoleBoard : IObserver
    {
        public string Name { get; }
        public ConsoleBoard(string name) { Name = name; }
        public void Update(string symbol, decimal rate) => Console.WriteLine($"{Name}: {symbol} = {rate}");
    }
}
