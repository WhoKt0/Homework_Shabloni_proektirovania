namespace AppProduct.Module_6.Lab6.Weather.Abstractions
{
    public interface IObserver
    {
        void Update(float temperature);
        string Name { get; }
    }
}
