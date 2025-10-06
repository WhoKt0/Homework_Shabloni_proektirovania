namespace Lab.Transport.Domain
{
    public interface ITransport
    {
        string Model { get; }
        int MaxSpeed { get; }
        void Move();
        void FuelUp();
    }
}
