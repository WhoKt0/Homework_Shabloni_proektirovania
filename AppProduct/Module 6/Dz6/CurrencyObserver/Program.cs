using System;
using AppProduct.Module_6.Dz6.Currency.Core;
using AppProduct.Module_6.Dz6.Currency.Observers;

namespace AppProduct.Module_6.Dz6.Currency
{
    class Program
    {
        static void Main()
        {
            var ex = new CurrencyExchange();
            var board = new ConsoleBoard("Табло");
            var alert = new ThresholdAlert("Сигнал", min: 90m, max: 110m);
            var email = new EmailNotifier("fx@notify.dev");

            ex.RegisterObserver("USD/KZT", board);
            ex.RegisterObserver("USD/KZT", alert);
            ex.RegisterObserver("USD/KZT", email);
            ex.RegisterObserver("EUR/KZT", board);

            ex.SetRate("USD/KZT", 98m);
            ex.SetRate("EUR/KZT", 520m);
            ex.SetRate("USD/KZT", 112m);

            ex.RemoveObserver("USD/KZT", email);
            ex.SetRate("USD/KZT", 100m);
        }
    }
}
