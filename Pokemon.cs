using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int type;//public Data.Type type;
        public Data.Stat stat;
        private List<Skill>? skills;

        public Pokemon(int id, string name, int type, Data.Stat stat)
        {
            this.Id = id;
            this.Name = name;
            this.type = type;
            this.stat = stat;
        }
        public void AddSkill(Skill skill)
        {
            if (skills == null)
                skills = new List<Skill>();
            skills.Add(skill);
        }

        public string PrintPokemon()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0,-5}", Id);
            sb.AppendFormat("{0,8}", Name);
            sb.AppendFormat("{0,5}", type);
            sb.AppendFormat("{0}", stat.PrintStat());

            return sb.ToString();
        }

    }
}
