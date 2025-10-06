using Lab.Transport.Domain;
namespace Lab.Transport.Factories
{
    public class PlaneFactory : TransportFactory
    {
        public override ITransport Create(string model, int maxSpeed) => new Plane(model, maxSpeed);
    }
}
