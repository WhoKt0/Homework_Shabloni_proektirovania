namespace AppProduct.Module_7.Lab7.SmartHome.Commands
{
    public interface ICommand
    {
        void Execute();
        void Undo();
        string Name { get; }
    }
}
