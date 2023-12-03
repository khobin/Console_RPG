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
        private event Action<Item> OnUse;

        public Item(string name, string desc)
        {
            Name = name;
            Desc = desc;
            OnUse -= Data.Instance.player.ItemUse;
            OnUse += Data.Instance.player.ItemUse;
        }
        public void Use()
        {
            OnUse(this);
        }
        public void ShowItem()
        {
            
            Console.WriteLine($"이름 : {Name}  타입 : {ItemType}  설명 : {Desc}");
        }

    }
}
