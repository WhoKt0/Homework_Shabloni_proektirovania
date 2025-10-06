using System;

namespace AppProduct.Module_4.Dz4.Domain
{
    public class Motorcycle : IVehicle
    {
        public string Kind { get; }
        public int EngineCc { get; }
        public Motorcycle(string kind, int engineCc) { Kind = kind; EngineCc = engineCc; }
        public void Drive() => Console.WriteLine($"Motorcycle {Kind} {EngineCc}cc rides");
        public void Refuel() => Console.WriteLine("Motorcycle refueled: gasoline");
        public override string ToString() => $"Motorcycle[{Kind}, {EngineCc}cc]";
    }
}
