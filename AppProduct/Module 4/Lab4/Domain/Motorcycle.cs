using System;
namespace Lab.Transport.Domain
{
    public class Motorcycle : ITransport
    {
        public string Model { get; }
        public int MaxSpeed { get; }
        public Motorcycle(string model, int maxSpeed) { Model = model; MaxSpeed = maxSpeed; }
        public void Move() => Console.WriteLine($"Motorcycle {Model} zips through traffic up to {MaxSpeed} km/h");
        public void FuelUp() => Console.WriteLine($"Motorcycle {Model} refueled with gasoline");
    }
}
