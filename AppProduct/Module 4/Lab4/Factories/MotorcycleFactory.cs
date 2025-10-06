using Lab.Transport.Domain;
namespace Lab.Transport.Factories
{
    public class MotorcycleFactory : TransportFactory
    {
        public override ITransport Create(string model, int maxSpeed) => new Motorcycle(model, maxSpeed);
    }
}
