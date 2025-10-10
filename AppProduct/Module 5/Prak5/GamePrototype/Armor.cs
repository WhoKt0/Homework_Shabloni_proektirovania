namespace AppProduct.Module_5.Prak5.GamePrototype
{
    public class Armor : IPrototype<Armor>
    {
        public string Name { get; set; } = "";
        public int Defense { get; set; }
        public Armor Clone() => new Armor { Name = Name, Defense = Defense };
    }
}
