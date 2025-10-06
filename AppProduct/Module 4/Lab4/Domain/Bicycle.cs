using System;
namespace Lab.Transport.Domain
{
    public class Bicycle : ITransport
    {
        public string Model { get; }
        public int MaxSpeed { get; }
        public Bicycle(string model, int maxSpeed) { Model = model; MaxSpeed = maxSpeed; }
        public void Move() => Console.WriteLine($"Bicycle {Model} pedals along up to {MaxSpeed} km/h");
        public void FuelUp() => Console.WriteLine($"Bicycle {Model} needs no fuel");
    }
}
