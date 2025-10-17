using System;
using AppProduct.Module_6.Lab6.Weather.Core;
using AppProduct.Module_6.Lab6.Weather.Observers;

namespace AppProduct.Module_6.Lab6.Weather
{
    class Program
    {
        static void Main()
        {
            var station = new WeatherStation();
            var mobile = new WeatherDisplay("Мобильное приложение");
            var board = new WeatherDisplay("Электронное табло");
            var email = new EmailAlert("meteo@notify.dev", threshold: 25f);

            station.RegisterObserver(mobile);
            station.RegisterObserver(board);
            station.RegisterObserver(email);

            Console.WriteLine("Введите температуры через запятую, например: 25,30,28");
            var line = Console.ReadLine() ?? "";
            var parts = line.Split(new[]{',',';',' '}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var p in parts)
            {
                if (float.TryParse(p, out var t))
                {
                    station.SetTemperature(t);
                }
            }

            station.RemoveObserver(board);
            station.SetTemperature(22f);
        }
    }
}
