using System;

namespace AppProduct.Module_7.Prak7.SmartHome.Devices
{
    public class Light
    {
        public string Location { get; }
        public bool IsOn { get; private set; }
        public Light(string location) { Location = location; }
        public void On() { IsOn = true; Console.WriteLine($"Свет {Location}: ВКЛ"); }
        public void Off() { IsOn = false; Console.WriteLine($"Свет {Location}: ВЫКЛ"); }
    }
}
