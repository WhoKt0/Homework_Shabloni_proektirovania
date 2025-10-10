namespace AppProduct.Module_5.Prak5.GamePrototype
{
    public class Weapon : IPrototype<Weapon>
    {
        public string Name { get; set; } = "";
        public int Damage { get; set; }
        public Weapon Clone() => new Weapon { Name = Name, Damage = Damage };
    }
}
