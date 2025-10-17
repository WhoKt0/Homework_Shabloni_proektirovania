using System;
using AppProduct.Module_6.Lab6.Shipping.Services;
using AppProduct.Module_6.Lab6.Shipping.Domain.Strategies;

namespace AppProduct.Module_6.Lab6.Shipping
{
    class Program
    {
        static void Main()
        {
            var ctx = new DeliveryContext();
            Console.WriteLine("Выберите тип доставки: 1-Стандартная, 2-Экспресс, 3-Международная, 4-Ночная");
            var choice = (Console.ReadLine() ?? "").Trim();
            switch (choice)
            {
                case "1": ctx.SetShippingStrategy(new StandardShippingStrategy()); break;
                case "2": ctx.SetShippingStrategy(new ExpressShippingStrategy()); break;
                case "3": ctx.SetShippingStrategy(new InternationalShippingStrategy()); break;
                case "4": ctx.SetShippingStrategy(new NightShippingStrategy()); break;
                default: Console.WriteLine("Неверный выбор."); return;
            }

            Console.WriteLine("Введите вес посылки (кг):");
            if (!decimal.TryParse(Console.ReadLine(), out var weight) || weight <= 0) { Console.WriteLine("Некорректный вес."); return; }

            Console.WriteLine("Введите расстояние доставки (км):");
            if (!decimal.TryParse(Console.ReadLine(), out var distance) || distance <= 0) { Console.WriteLine("Некорректное расстояние."); return; }

            try
            {
                var cost = ctx.CalculateCost(weight, distance);
                Console.WriteLine($"Стоимость доставки: {cost:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
