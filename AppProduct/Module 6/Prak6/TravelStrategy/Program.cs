using System;
using System.Collections.Generic;
using AppProduct.Module_6.Prak6.Travel.Domain;
using AppProduct.Module_6.Prak6.Travel.Pricing;
using AppProduct.Module_6.Prak6.Travel.Context;

namespace AppProduct.Module_6.Prak6.Travel
{
    class Program
    {
        static void Main()
        {
            var strategies = new Dictionary<TransportType, ICostCalculationStrategy>
            {
                [TransportType.Airplane] = new AirplaneCostStrategy(),
                [TransportType.Train]    = new TrainCostStrategy(),
                [TransportType.Bus]      = new BusCostStrategy()
            };
            var ctx = new TravelBookingContext(strategies);

            Console.WriteLine("Тип транспорта (airplane/train/bus): ");
            var t = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
            var transport = t switch
            {
                "airplane" => TransportType.Airplane,
                "train" => TransportType.Train,
                "bus" => TransportType.Bus,
                _ => TransportType.Bus
            };

            Console.Write("Дистанция, км: ");
            double.TryParse(Console.ReadLine(), out var dist);

            Console.Write("Класс (economy/business): ");
            var c = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
            var svc = c == "business" ? ServiceClass.Business : ServiceClass.Economy;

            Console.Write("Пассажиров всего: ");
            int.TryParse(Console.ReadLine(), out var p);
            Console.Write("Из них дети: ");
            int.TryParse(Console.ReadLine(), out var ch);
            Console.Write("Из них пенсионеры: ");
            int.TryParse(Console.ReadLine(), out var sn);
            Console.Write("Доп. багаж (шт): ");
            int.TryParse(Console.ReadLine(), out var bag);
            Console.Write("Регион. коэф. (напр. 1.0 / 1.2): ");
            decimal.TryParse(Console.ReadLine(), out var rc);
            if (rc <= 0) rc = 1m;

            var trip = new Trip
            {
                Transport = transport,
                DistanceKm = dist,
                Class = svc,
                Passengers = p,
                Children = ch,
                Seniors = sn,
                ExtraBaggage = bag,
                RegionalCoefficient = rc
            };
            trip.Extras["WiFi"] = 2m;
            trip.Extras["Meal"] = svc == ServiceClass.Business ? 0m : 5m;

            try
            {
                var total = ctx.Calculate(trip);
                Console.WriteLine($"Итого: {total}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
