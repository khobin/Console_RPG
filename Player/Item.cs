using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string Desc {  get; set; }
        public ItemType ItemType { get; set; }
        public event Action<Item> OnUse;

        public Item(string name, string desc, ItemType type)
        {
            Name = name;
            Desc = desc;
            ItemType = type;
            OnUse -= Data.player.ItemUse;
            OnUse += Data.player.ItemUse;
        }
        public void Use()
        {
            OnUse(this);
        }
    }
}
