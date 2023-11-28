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
        public Type.PokemonType pokemonType { get; set; }
        public Type.SkillType skillType { get; set; }
        public Action<Pokemon> action;

        
        public Skill(int id, string? name, string? description,int amount, int PP, int MaxPP, Type.PokemonType pokemonType, Type.SkillType skillType)
        {
            Id = id;
            Name = name;
            Desc = description;
            Amount = amount;
            this.PP = PP;
            this.MaxPP = MaxPP;
            this.pokemonType = pokemonType;
            this.skillType = skillType;
        }
        public Skill Clone()
        {
            Skill newSkill = new Skill(Id, Name, Desc, Amount, PP, MaxPP, pokemonType, skillType);
            
            return newSkill;
        }
        public string PrintSkill()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{Name}  {PP,2}/{MaxPP,2}");

            return sb.ToString();
        }
    }
}
