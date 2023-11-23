using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class BattleItem : Item
    {
        int increse;
        public BattleItem(string name, string desc, Type.ItemType type) : base(name, desc, type)
        {

        }
    }
}
