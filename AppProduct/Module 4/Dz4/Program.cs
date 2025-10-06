using System.Collections.Generic;
using AppProduct.Module_4.Dz4.Application;
using AppProduct.Module_4.Dz4.Factories;

namespace AppProduct.Module_4.Dz4
{
    class Program
    {
        static void Main()
        {
            var factories = new Dictionary<string, TransportFactory>
            {
                ["car"] = new CarFactory(),
                ["moto"] = new MotorcycleFactory(),
                ["truck"] = new TruckFactory(),
                ["bus"] = new BusFactory()
            };

            var prompts = new Dictionary<string, string[]>
            {
                ["car"] = new[] { "brand", "model", "fuel" },
                ["moto"] = new[] { "kind", "engineCc" },
                ["truck"] = new[] { "capacityKg", "axles" },
                ["bus"] = new[] { "seats", "route" }
            };

            var cli = new VehicleCLI(factories, prompts);
            cli.Run();
        }
    }
}
