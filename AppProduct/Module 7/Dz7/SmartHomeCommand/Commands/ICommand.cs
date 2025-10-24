namespace AppProduct.Module_7.Dz7.SmartHome.Commands
{
    public interface ICommand
    {
        void Execute();
        void Undo();
        string Name { get; }
        bool Executed { get; }
    }
}
