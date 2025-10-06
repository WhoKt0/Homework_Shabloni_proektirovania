using System;
using AppProduct.Module_4.Dz4.Domain;

namespace AppProduct.Module_4.Dz4.Factories
{
    public class BusFactory : TransportFactory
    {
        public override IVehicle CreateVehicle(params string[] args)
        {
            int.TryParse(args.Length > 0 ? args[0] : "0", out var seats);
            var route = args.Length > 1 ? args[1] : "Unknown";
            return new Bus(seats, route);
        }
    }
}
