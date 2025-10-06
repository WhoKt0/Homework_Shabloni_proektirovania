using System;

namespace AppProduct.Module_4.Dz4.Domain
{
    public class Truck : IVehicle
    {
        public int CapacityKg { get; }
        public int Axles { get; }
        public Truck(int capacityKg, int axles) { CapacityKg = capacityKg; Axles = axles; }
        public void Drive() => Console.WriteLine($"Truck {CapacityKg}kg, {Axles} axles hauls");
        public void Refuel() => Console.WriteLine("Truck refueled: diesel");
        public override string ToString() => $"Truck[{CapacityKg}kg, {Axles} axles]";
    }
}
