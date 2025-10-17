using System;
using AppProduct.Module_6.Lab6.Weather.Abstractions;

namespace AppProduct.Module_6.Lab6.Weather.Observers
{
    public class WeatherDisplay : IObserver
    {
        public string Name { get; }
        public WeatherDisplay(string name) { Name = name; }
        public void Update(float temperature)
        {
            Console.WriteLine($"{Name} показывает новую температуру: {temperature}°C");
        }
    }
}
