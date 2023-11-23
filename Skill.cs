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

        public Skill() { }
        public Skill(int id, string? name, string? description,int amount, int PP, Type.PokemonType pokemonType, Type.SkillType skillType)
        {
            Id = id;
            Name = name;
            Desc = description;
            Amount = amount;
            this.PP = PP;
            MaxPP = PP;
            this.pokemonType = pokemonType;
            this.skillType = skillType;
        }
        public Skill Clone()
        {
            Skill newSkill = new Skill();
            newSkill.Id = Id;
            newSkill.Name = Name;
            newSkill.Desc = Desc;
            newSkill.Amount = Amount;
            newSkill.PP = PP;
            newSkill.MaxPP = MaxPP;
            newSkill.pokemonType = pokemonType;
            newSkill.skillType = skillType;

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
