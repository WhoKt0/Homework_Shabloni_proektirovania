using System;
using AppProduct.Module_6.Dz6.Currency.Abstractions;

namespace AppProduct.Module_6.Dz6.Currency.Observers
{
    public class EmailNotifier : IObserver
    {
        public string Name { get; }
        readonly string _email;
        public EmailNotifier(string email) { _email = email; Name = $"Email<{email}>"; }
        public void Update(string symbol, decimal rate)
        {
            Console.WriteLine($"{Name}: уведомление о {symbol} = {rate}");
        }
    }
}
