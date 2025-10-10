namespace AppProduct.Module_5.Lab5.ComputerBuilder
{
    public class Computer
    {
        public string CPU { get; set; } = "";
        public string RAM { get; set; } = "";
        public string Storage { get; set; } = "";
        public string GPU { get; set; } = "";
        public string OS { get; set; } = "";
        public override string ToString() => $"Компьютер: CPU - {CPU}, RAM - {RAM}, Накопитель - {Storage}, GPU - {GPU}, ОС - {OS}";
    }
}
