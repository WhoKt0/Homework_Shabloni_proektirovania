namespace AppProduct.Module_5.Lab5.ComputerBuilder
{
    public interface IComputerBuilder
    {
        void SetCPU();
        void SetRAM();
        void SetStorage();
        void SetGPU();
        void SetOS();
        Computer GetComputer();
    }
}
