namespace AppProduct.Module_5.Lab5.ComputerBuilder
{
    public class OfficeComputerBuilder : IComputerBuilder
    {
        readonly Computer _computer = new Computer();
        public void SetCPU() => _computer.CPU = "Intel i3";
        public void SetRAM() => _computer.RAM = "8GB";
        public void SetStorage() => _computer.Storage = "1TB HDD";
        public void SetGPU() => _computer.GPU = "Integrated";
        public void SetOS() => _computer.OS = "Windows 10";
        public Computer GetComputer() => _computer;
    }
}
