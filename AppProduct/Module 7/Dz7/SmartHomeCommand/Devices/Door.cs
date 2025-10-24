using System;

namespace AppProduct.Module_7.Dz7.SmartHome.Devices
{
    public class Door
    {
        public string Location { get; }
        public bool IsOpen { get; private set; }
        public Door(string location) { Location = location; }
        public void Open() { IsOpen = true; Console.WriteLine($"Дверь [{Location}] ОТКРЫТА"); }
        public void Close() { IsOpen = false; Console.WriteLine($"Дверь [{Location}] ЗАКРЫТА"); }
    }
}
