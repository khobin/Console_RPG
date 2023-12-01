using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class Inventory
    {
        public List<Item> items;

        public Inventory()
        {
            items = new List<Item>(10);

        }
        public void ShowItems()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < items.Count; i++)
            {
                sb.AppendLine($"Index : {i}");
                sb.AppendLine($"Name  : {items[i].Name}");
                sb.AppendLine($"Desc  : {items[i].Desc}");
                sb.AppendLine("=========================================================");
            }

            Console.WriteLine(sb.ToString());

        }
    }
}
