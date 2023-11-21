using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class Data
    {
        public struct Stat
        {
            public int hp;
            public int attack;
            public int defense;
            public int speed;

            public Stat(int hp, int attack, int defense, int speed)
            {
                this.hp = hp;
                this.attack = attack;
                this.defense = defense;
                this.speed = speed;
            }
            public string PrintStat()
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendFormat("{0,4}", hp);
                sb.AppendFormat("{0,4}", attack);
                sb.AppendFormat("{0,4}", defense);
                sb.AppendFormat("{0,4}", speed);

                return sb.ToString();
            }
        }
        public enum Type
        {
            Normal = 0,
            Fire = 1,
            Water = 2,
            Grass = 3,
            Electric = 4,
            Ice = 5,
            Fighting = 6,
            Poison = 7,
            Ground = 8,
            Flying = 9,
            Psychic = 10,
            Bug = 11,
            Rock = 12,
            Ghost = 13,
            Dragon = 14,
            Dark = 15,
            Steel = 16,
            Fairy = 17
        }

    }
}
