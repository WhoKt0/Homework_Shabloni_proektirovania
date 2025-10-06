using Lab.Transport.Domain;
namespace Lab.Transport.Factories
{
    public class CarFactory : TransportFactory
    {
        public override ITransport Create(string model, int maxSpeed) => new Car(model, maxSpeed);
    }
}
