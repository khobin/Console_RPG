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
                case ItemType.볼:

                    break;
                case ItemType.배틀아이템:
                    BattleItem(item);
                    break;
                case ItemType.기타:
                    
                    break;

            }
        }
        private void HealItem(Item item)
        {

        }
        private void BattleItem(Item item)
        {

        }
    }
}
