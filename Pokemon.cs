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
        public Data.Type[] types;
        public Data.Stat stat;
        private List<Skill> skills;

    }
}
