using System;

namespace AppProduct.Module_7.Prak7.SmartHome.Devices
{
    public class Shades
    {
        public string Location { get; }
        public bool IsOpen { get; private set; }
        public Shades(string location) { Location = location; }
        public void Open() { IsOpen = true; Console.WriteLine($"Шторы {Location}: ОТКР"); }
        public void Close() { IsOpen = false; Console.WriteLine($"Шторы {Location}: ЗАКР"); }
    }
}
