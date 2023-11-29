using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public enum PokemonType
    {
        노말 = 0,
        불꽃 = 1,
        물 = 2,
        풀 = 3,
        전기 = 4,
        얼음 = 5,
        격투 = 6,
        독 = 7,
        땅 = 8,
        비행 = 9,
        에스퍼 = 10,
        벌레 = 11,
        바위 = 12,
        고스트 = 13,
        드래곤 = 14,
        악 = 15,
        강철 = 16,
        페어리 = 17
    }
    public enum ItemType
    {
        볼 = 0,
        배틀아이템 = 1,
        기타 = 2,
    }
    public enum SkillType
    {
        공격 = 0,
        디버프 = 1,
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
    
}
