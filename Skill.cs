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
        public string? Description { get; set; }
        public int PP { get; set; }
        private int MaxPP;
        public Type.PokemonType Type { get; set; }
    }
}
