using System;

namespace AppProduct.Module_7.Prak7.SmartHome.Devices
{
    public class Television
    {
        public string Location { get; }
        public bool IsOn { get; private set; }
        public int Channel { get; private set; } = 1;
        public Television(string location) { Location = location; }
        public void On() { IsOn = true; Console.WriteLine($"TV {Location}: ВКЛ"); }
        public void Off() { IsOn = false; Console.WriteLine($"TV {Location}: ВЫКЛ"); }
        public void SetChannel(int ch) { Channel = ch; Console.WriteLine($"TV {Location}: канал {ch}"); }
    }
}
