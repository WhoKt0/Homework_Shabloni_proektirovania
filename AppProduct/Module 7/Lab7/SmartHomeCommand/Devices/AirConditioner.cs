using System;

namespace AppProduct.Module_7.Lab7.SmartHome.Devices
{
    public class AirConditioner
    {
        public string Location { get; }
        public bool IsOn { get; private set; }
        public int Temperature { get; private set; } = 24;
        public bool EcoMode { get; private set; }

        public AirConditioner(string location) { Location = location; }
        public void On() { IsOn = true; Console.WriteLine($"AC [{Location}] включен."); }
        public void Off() { IsOn = false; Console.WriteLine($"AC [{Location}] выключен."); }
        public void SetTemp(int t) { Temperature = t; Console.WriteLine($"AC [{Location}] температура {t}°C."); }
        public void SetEco(bool on) { EcoMode = on; Console.WriteLine($"AC [{Location}] эко-режим: {(on ? "ON" : "OFF")}"); }
    }
}
