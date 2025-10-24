using System;

namespace AppProduct.Module_7.Prak7.SmartHome.Devices
{
    public class AirConditioner
    {
        public string Location { get; }
        public bool IsOn { get; private set; }
        public int Temperature { get; private set; } = 24;
        public AirConditioner(string location) { Location = location; }
        public void On() { IsOn = true; Console.WriteLine($"Кондиционер {Location}: ВКЛ"); }
        public void Off() { IsOn = false; Console.WriteLine($"Кондиционер {Location}: ВЫКЛ"); }
        public void SetTemperature(int temp) { Temperature = temp; Console.WriteLine($"Кондиционер {Location}: температура {temp}°C"); }
    }
}
