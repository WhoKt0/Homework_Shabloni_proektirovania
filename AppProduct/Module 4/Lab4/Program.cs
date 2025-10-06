using System;
using System.Collections.Generic;
using Lab.Transport.Application;
using Lab.Transport.Factories;

namespace Lab.Transport
{
    class Program
    {
        static void Main()
        {
            var factories = new Dictionary<string, TransportFactory>
            {
                ["car"] = new CarFactory(),
                ["moto"] = new MotorcycleFactory(),
                ["plane"] = new PlaneFactory(),
                ["bike"] = new BicycleFactory()
            };

            var cli = new TransportCLI(factories);
            cli.Run();
        }
    }
}
