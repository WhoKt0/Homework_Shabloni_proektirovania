using System;
namespace Lab.Transport.Domain
{
    public class Car : ITransport
    {
        public string Model { get; }
        public int MaxSpeed { get; }
        public Car(string model, int maxSpeed) { Model = model; MaxSpeed = maxSpeed; }
        public void Move() => Console.WriteLine($"Car {Model} cruises on road at up to {MaxSpeed} km/h");
        public void FuelUp() => Console.WriteLine($"Car {Model} refueled with gasoline");
    }
}
