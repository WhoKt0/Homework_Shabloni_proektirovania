using System;
using AppProduct.Module_6.Dz6.Payment.Services;
using AppProduct.Module_6.Dz6.Payment.Domain.Strategies;

namespace AppProduct.Module_6.Dz6.Payment
{
    class Program
    {
        static void Main()
        {
            var ctx = new PaymentContext();
            Console.WriteLine("Способ оплаты: 1-Карта, 2-PayPal, 3-Crypto");
            var choice = (Console.ReadLine() ?? "").Trim();
            switch (choice)
            {
                case "1":
                    Console.Write("Номер карты: "); var num = Console.ReadLine() ?? "";
                    Console.Write("Держатель: "); var holder = Console.ReadLine() ?? "";
                    Console.Write("CVV: "); var cvv = Console.ReadLine() ?? "";
                    ctx.SetStrategy(new CardPaymentStrategy(num, holder, cvv));
                    break;
                case "2":
                    Console.Write("Email PayPal: "); var email = Console.ReadLine() ?? "";
                    ctx.SetStrategy(new PayPalPaymentStrategy(email));
                    break;
                case "3":
                    Console.Write("Wallet: "); var wallet = Console.ReadLine() ?? "";
                    Console.Write("Network: "); var net = Console.ReadLine() ?? "";
                    ctx.SetStrategy(new CryptoPaymentStrategy(wallet, net));
                    break;
                default:
                    Console.WriteLine("Неверный выбор."); return;
            }
            Console.Write("Сумма: ");
            if (!decimal.TryParse(Console.ReadLine(), out var amount) || amount <= 0) { Console.WriteLine("Некорректная сумма."); return; }
            var ok = ctx.Pay(amount);
            Console.WriteLine(ok ? "Оплачено." : "Оплата отклонена.");
        }
    }
}
