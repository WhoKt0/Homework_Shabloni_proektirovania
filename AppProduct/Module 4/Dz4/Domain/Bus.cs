using System;

namespace AppProduct.Module_4.Dz4.Domain
{
    public class Bus : IVehicle
    {
        public int Seats { get; }
        public string Route { get; }
        public Bus(int seats, string route) { Seats = seats; Route = route; }
        public void Drive() => Console.WriteLine($"Bus on route {Route} with {Seats} seats");
        public void Refuel() => Console.WriteLine("Bus refueled: diesel or CNG");
        public override string ToString() => $"Bus[{Route}, {Seats}]";
    }
}
