using System.Collections.Generic;
using System.Linq;

namespace AppProduct.Module_5.Prak5.GamePrototype
{
    public class Character : IPrototype<Character>
    {
        public string Name { get; set; } = "";
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intellect { get; set; }
        public Weapon Weapon { get; set; } = new Weapon();
        public Armor Armor { get; set; } = new Armor();
        public List<Skill> Skills { get; } = new List<Skill>();

        public Character Clone()
        {
            var c = new Character
            {
                Name = Name,
                Health = Health,
                Strength = Strength,
                Agility = Agility,
                Intellect = Intellect,
                Weapon = Weapon?.Clone(),
                Armor = Armor?.Clone()
            };
            foreach (var s in Skills.Select(s => s.Clone())) c.Skills.Add(s);
            return c;
        }
    }
}
