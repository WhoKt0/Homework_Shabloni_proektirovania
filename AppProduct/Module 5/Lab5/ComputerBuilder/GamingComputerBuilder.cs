namespace AppProduct.Module_5.Lab5.ComputerBuilder
{
    public class GamingComputerBuilder : IComputerBuilder
    {
        readonly Computer _computer = new Computer();
        public void SetCPU() => _computer.CPU = "Intel i9";
        public void SetRAM() => _computer.RAM = "32GB";
        public void SetStorage() => _computer.Storage = "1TB SSD";
        public void SetGPU() => _computer.GPU = "NVIDIA RTX 3080";
        public void SetOS() => _computer.OS = "Windows 11";
        public Computer GetComputer() => _computer;
    }
}
