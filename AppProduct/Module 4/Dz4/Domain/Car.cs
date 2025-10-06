using System;

namespace AppProduct.Module_4.Dz4.Domain
{
    public class Car : IVehicle
    {
        public string Brand { get; }
        public string Model { get; }
        public string Fuel { get; }
        public Car(string brand, string model, string fuel) { Brand = brand; Model = model; Fuel = fuel; }
        public void Drive() => Console.WriteLine($"Car {Brand} {Model} drives");
        public void Refuel() => Console.WriteLine($"Car {Brand} {Model} refueled: {Fuel}");
        public override string ToString() => $"Car[{Brand} {Model}, {Fuel}]";
    }
}
