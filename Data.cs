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
                sb.AppendFormat($"HP : {hp,03}\t");
                sb.AppendFormat($"ATK : {attack,03}\t");
                sb.AppendFormat($"DEF : {defense,03} \t");
                sb.AppendFormat($"SPD : {speed,03}\t");


                return sb.ToString();
            }
        }
        public enum Type
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

    }
}
