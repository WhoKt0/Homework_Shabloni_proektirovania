using AppProduct.Module_4.Dz4.Domain;

namespace AppProduct.Module_4.Dz4.Factories
{
    public abstract class TransportFactory
    {
        public abstract IVehicle CreateVehicle(params string[] args);
    }
}
