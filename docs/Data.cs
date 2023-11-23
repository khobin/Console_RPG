using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public static class Data
    {
        public static Player player;
        public static Inventory inventory;
        public static Dictionary<string, Pokemon> pokedex;
        public static Dictionary<string, Skill> skillDic;
        public static void Init()
        {
            JsonManager.Instance.LoadData();
            pokedex = JsonManager.Instance.GetPokemonData();
            skillDic = JsonManager.Instance.GetSkillData();
            inventory = new Inventory();
            player = new Player();
        }

        public static void Release()
        {

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
}
