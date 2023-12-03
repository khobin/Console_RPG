using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class BattleItem : Item
    {
        public int increase;
        public BattleItem(string name, string desc, int increase) : base(name, desc)
        {
            this.increase = increase;
        }
    }
}
