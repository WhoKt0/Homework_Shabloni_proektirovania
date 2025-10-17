using System;

namespace AppProduct.Module_6.Dz6.Payment.Domain.Strategies
{
    public class CryptoPaymentStrategy : IPaymentStrategy
    {
        public string Name => "Crypto";
        public string Wallet { get; }
        public string Network { get; }
        public CryptoPaymentStrategy(string wallet, string network) { Wallet = wallet; Network = network; }
        public bool Pay(decimal amount)
        {
            if (amount <= 0) return false;
            if (string.IsNullOrWhiteSpace(Wallet) || string.IsNullOrWhiteSpace(Network)) return false;
            Console.WriteLine($"Оплата {amount:C} криптовалютой в сети {Network}, кошелёк {Short(Wallet)}");
            return true;
        }
        static string Short(string w) => w.Length <= 10 ? w : w[:6] + "..." + w[-4:];
    }
}
