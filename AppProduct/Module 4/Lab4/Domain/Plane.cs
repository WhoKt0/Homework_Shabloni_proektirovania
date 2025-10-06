using System;
namespace Lab.Transport.Domain
{
    public class Plane : ITransport
    {
        public string Model { get; }
        public int MaxSpeed { get; }
        public Plane(string model, int maxSpeed) { Model = model; MaxSpeed = maxSpeed; }
        public void Move() => Console.WriteLine($"Plane {Model} flies at up to {MaxSpeed} km/h");
        public void FuelUp() => Console.WriteLine($"Plane {Model} fueled with jet fuel");
    }
}
