using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class Player
    {
        public char icon = 'P';
        public Pokemon pokemon;
        public Position pos;
        public Player()
        {
            pokemon = Data.Instance.pokedex["리자몽"].Clone();
        }

        public void Move(Direction dir)
        {
            Position prevPos = pos;
            switch (dir)
            {
                case Direction.Up:
                    pos.y--;
                    break;
                case Direction.Down:
                    pos.y++;
                    break;
                case Direction.Left:
                    pos.x--;
                    break;
                case Direction.Right:
                    pos.x++;
                    break;
            }

            if ('X' == Data.Instance.map[pos.y, pos.x])
            {
                pos = prevPos;
            }
        }
        public void ItemUse(Item item)
        {
            switch (item.ItemType)
            {
                case ItemType.강화:
                    BattleItem(item);
                    break;
                case ItemType.포션:
                    HealItem(item);
                    break;
                case ItemType.기타:
                    Console.WriteLine("사용할 수 없는 아이템입니다.");
                    Thread.Sleep(1000);
                    break;

            }
        }
        private void HealItem(Item item)
        {
            Potion potion = item as Potion;
            if (potion == null)
            {
                Console.WriteLine("Casting Error");
                Thread.Sleep(1000);
                return;
            }

            Console.WriteLine($"{potion.Name}을 {pokemon.Name}에게 사용합니다.");
            Thread.Sleep(1000);
            Console.WriteLine($"{potion.heal}만큼 회복합니다.");
            Thread.Sleep(1000);
            pokemon.stat.hp += potion.heal;

            Data.Instance.inventory.items.Remove(item);

        }
        private void BattleItem(Item item)
        {
            BattleItem battleItem = item as BattleItem;
            if (battleItem == null)
            {
                Console.WriteLine("Casting Error");
                Thread.Sleep(1000);
                return;
            }

            Console.WriteLine($"{battleItem.Name}을 {pokemon.Name}에게 사용합니다.");
            Thread.Sleep(1000);
            Console.WriteLine($"{battleItem.increase}만큼 공격력이 상승합니다.");
            Thread.Sleep(1000);
            pokemon.stat.attack += battleItem.increase;

            Data.Instance.inventory.items.Remove(item);
        }
    }
}
