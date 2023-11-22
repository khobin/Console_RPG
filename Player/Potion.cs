using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class Potion : Item
    {
        public int heal;

        public Potion(string name, string desc, Type.ItemType type, int heal) : base(name, desc, type)
        {
            this.heal = heal;
        }
    }
}
