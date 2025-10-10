namespace AppProduct.Module_5.Prak5.GamePrototype
{
    public class Skill : IPrototype<Skill>
    {
        public string Title { get; set; } = "";
        public string Kind { get; set; } = "";
        public int Power { get; set; }
        public Skill Clone() => new Skill { Title = Title, Kind = Kind, Power = Power };
    }
}
