using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class Data
    {
        public static Player player;
        public static Inventory inventory;
        public static Dictionary<string, Pokemon> pokedex;
        public static Dictionary<string, Skill> skillDic;
        public static void Init()
        {
            JsonManager jsonManager = new JsonManager();
            
            skillDic = jsonManager.LoadSkill();
            pokedex = jsonManager.LoadPokemon();
            inventory = new Inventory();
            player = new Player();
        }

        public static void Release()
        {

        }


    }
}
