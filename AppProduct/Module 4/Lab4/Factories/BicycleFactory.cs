using Lab.Transport.Domain;
namespace Lab.Transport.Factories
{
    public class BicycleFactory : TransportFactory
    {
        public override ITransport Create(string model, int maxSpeed) => new Bicycle(model, maxSpeed);
    }
}
