using Lab.Transport.Domain;
namespace Lab.Transport.Factories
{
    public abstract class TransportFactory
    {
        public abstract ITransport Create(string model, int maxSpeed);
    }
}
