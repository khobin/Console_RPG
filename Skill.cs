using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class Skill
    {
        public int Id {  get; set; }
        public string? Name { get; set; }
        public string? Desc { get; set; }
        public int Amount { get; set; }
        public int PP { get; set; }
        public int MaxPP;
        public int pokemonType { get; set; }
        public SkillType skillType { get; set; }
        public Action<Pokemon> action;

        
        public Skill(int id, string? name, string? description,int amount, int PP, int MaxPP, string pokemonType, SkillType skillType)
        {
            Id = id;
            Name = name;
            Desc = description;
            Amount = amount;
            this.PP = PP;
            this.MaxPP = MaxPP;
            if (Enum.TryParse(pokemonType, out PokemonType parsedType))
            {
                this.pokemonType = (int)parsedType;
            }
            this.skillType = skillType;
        }
        public Skill Clone()
        {
            Skill newSkill = new Skill(Id, Name, Desc, Amount, PP, MaxPP, pokemonType.ToString(), skillType);
            
            return newSkill;
        }
        public string PrintSkill()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{Name}  {PP,2}/{MaxPP,2}");

            return sb.ToString();
        }
        public bool Equals(Skill otherSkill)
        {
            if (otherSkill == null)
                return false;

            return this.Name == otherSkill.Name;
        }
    }
}
