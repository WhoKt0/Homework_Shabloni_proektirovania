using System;
using AppProduct.Module_4.Dz4.Domain;

namespace AppProduct.Module_4.Dz4.Factories
{
    public class MotorcycleFactory : TransportFactory
    {
        public override IVehicle CreateVehicle(params string[] args)
        {
            var kind = args.Length > 0 ? args[0] : "sport";
            int.TryParse(args.Length > 1 ? args[1] : "0", out var cc);
            return new Motorcycle(kind, cc);
        }
    }
}
