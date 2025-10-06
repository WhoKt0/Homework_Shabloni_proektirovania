using System;
using System.Collections.Generic;
using Lab.Transport.Domain;
using Lab.Transport.Factories;

namespace Lab.Transport.Application
{
    public class TransportCLI
    {
        private readonly Dictionary<string, TransportFactory> _factories;

        public TransportCLI(Dictionary<string, TransportFactory> factories)
        {
            _factories = factories;
        }

        public void Run()
        {
            Console.WriteLine("Types: car, moto, plane, bike");
            Console.Write("Type: ");
            var type = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
            if (!_factories.ContainsKey(type))
            {
                Console.WriteLine("Unknown type");
                return;
            }

            Console.Write("Model: ");
            var model = Console.ReadLine() ?? "Unknown";

            Console.Write("Max speed (km/h): ");
            if (!int.TryParse(Console.ReadLine(), out var speed)) speed = 0;

            var transport = _factories[type].Create(model, speed);
            transport.FuelUp();
            transport.Move();
        }
    }
}
