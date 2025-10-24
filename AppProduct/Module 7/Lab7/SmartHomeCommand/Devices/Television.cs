using System;

namespace AppProduct.Module_7.Lab7.SmartHome.Devices
{
    public class Television
    {
        public string Location { get; }
        public bool IsOn { get; private set; }
        public Television(string location) { Location = location; }
        public void On() { IsOn = true; Console.WriteLine($"TV [{Location}] включен."); }
        public void Off() { IsOn = false; Console.WriteLine($"TV [{Location}] выключен."); }
    }
}
