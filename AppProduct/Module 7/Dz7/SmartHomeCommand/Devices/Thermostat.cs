using System;

namespace AppProduct.Module_7.Dz7.SmartHome.Devices
{
    public class Thermostat
    {
        public string Location { get; }
        public int Temperature { get; private set; } = 22;
        public Thermostat(string location) { Location = location; }
        public void Increase(int delta) { Temperature += delta; Console.WriteLine($"Термостат [{Location}] +{delta} -> {Temperature}°C"); }
        public void Decrease(int delta) { Temperature -= delta; Console.WriteLine($"Термостат [{Location}] -{delta} -> {Temperature}°C"); }
    }
}
