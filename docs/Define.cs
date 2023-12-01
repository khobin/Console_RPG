using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public enum PokemonType
    {
        불꽃 = 1 << 0,
        물 = 1 << 1,
        풀 = 1 << 2,
        노말 = 1 << 3,
    }
    public enum ItemType
    {
        볼 = 0,
        배틀아이템 = 1,
        기타 = 2,
    }
    public enum SkillType
    {
        공격 = 1,
        디버프 = 2,
    }
    public struct Stat
    {
        public int hp;
        public int maxHp;
        public int attack;
        public int defense;
        public int speed;

        public Stat(int hp, int maxHp, int attack, int defense, int speed)
        {
            this.hp = hp;
            this.maxHp = maxHp;
            this.attack = attack;
            this.defense = defense;
            this.speed = speed;
        }
        public string PrintStat()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"HP : {hp,03}\t");
            sb.AppendFormat($"ATK : {attack,03}\t");
            sb.AppendFormat($"DEF : {defense,03} \t");
            sb.AppendFormat($"SPD : {speed,03}\t");


            return sb.ToString();
        }
    }
    public struct Position
    {
        public int x;
        public int y;
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public enum Direction
    {
        Up =0,
        Down = 1,
        Left = 2,
        Right = 3,

    }
}
