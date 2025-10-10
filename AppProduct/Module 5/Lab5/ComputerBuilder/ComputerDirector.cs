namespace AppProduct.Module_5.Lab5.ComputerBuilder
{
    public class ComputerDirector
    {
        IComputerBuilder _builder;
        public ComputerDirector(IComputerBuilder builder) { _builder = builder; }
        public void ConstructComputer()
        {
            _builder.SetCPU();
            _builder.SetRAM();
            _builder.SetStorage();
            _builder.SetGPU();
            _builder.SetOS();
        }
        public Computer GetComputer() => _builder.GetComputer();
    }
}
