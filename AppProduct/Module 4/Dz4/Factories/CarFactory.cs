using AppProduct.Module_4.Dz4.Domain;

namespace AppProduct.Module_4.Dz4.Factories
{
    public class CarFactory : TransportFactory
    {
        public override IVehicle CreateVehicle(params string[] args)
        {
            var brand = args.Length > 0 ? args[0] : "";
            var model = args.Length > 1 ? args[1] : "";
            var fuel  = args.Length > 2 ? args[2] : "gasoline";
            return new Car(brand, model, fuel);
        }
    }
}
