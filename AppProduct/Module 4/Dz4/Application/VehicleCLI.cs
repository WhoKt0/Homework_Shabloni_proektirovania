using System;
using System.Collections.Generic;
using AppProduct.Module_4.Dz4.Domain;
using AppProduct.Module_4.Dz4.Factories;

namespace AppProduct.Module_4.Dz4.Application
{
    public class VehicleCLI
    {
        private readonly IDictionary<string, TransportFactory> _factories;
        private readonly IDictionary<string, string[]> _prompts;

        public VehicleCLI(IDictionary<string, TransportFactory> factories, IDictionary<string, string[]> prompts)
        {
            _factories = factories;
            _prompts = prompts;
        }

        public void Run()
        {
            Console.WriteLine("Types: car, moto, truck, bus");
            Console.Write("Type: ");
            var type = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
            if (!_factories.ContainsKey(type))
            {
                Console.WriteLine("Unknown type");
                return;
            }

            var answers = new List<string>();
            foreach (var p in _prompts[type])
            {
                Console.Write($"{p}: ");
                answers.Add(Console.ReadLine() ?? "");
            }

            var vehicle = _factories[type].CreateVehicle(answers.ToArray());
            Console.WriteLine(vehicle.ToString());
            vehicle.Refuel();
            vehicle.Drive();
        }
    }
}
