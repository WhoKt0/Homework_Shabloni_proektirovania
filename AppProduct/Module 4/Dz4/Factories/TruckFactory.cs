using System;
using AppProduct.Module_4.Dz4.Domain;

namespace AppProduct.Module_4.Dz4.Factories
{
    public class TruckFactory : TransportFactory
    {
        public override IVehicle CreateVehicle(params string[] args)
        {
            int.TryParse(args.Length > 0 ? args[0] : "0", out var cap);
            int.TryParse(args.Length > 1 ? args[1] : "2", out var axles);
            return new Truck(cap, axles);
        }
    }
}
