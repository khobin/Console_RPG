using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class Data
    {
        public char[,] map;
        public List<Pokemon> enemies;

        public Player player;
        public Inventory inventory;
        public Dictionary<string, Pokemon> pokedex;
        public Dictionary<string, Skill> skillDic;

        private Data() { }
        private static Data instance;
        public static Data Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Data();
                }
                return instance;
            }
        }

        public void Init()
        {
            JsonManager jsonManager = new JsonManager();
            
            skillDic = jsonManager.LoadSkill();
            pokedex = jsonManager.LoadPokemon();
            inventory = new Inventory();
            player = new Player();
            enemies = new List<Pokemon>();

            LoadMap();

        }
        public void LoadMap()
        {
            
            map = new char[,]
            {
             //   0   1   2   3   4   5   6   7   8   9   10  11  12  13  14  15  16  17  18  19  20  21  22  23 
                {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X' },     // 0
                {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X' },     // 1
                {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X' },     // 2
                {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X' },     // 3
                {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X' },     // 4
                {'X',' ',' ',' ',' ',' ',' ','G','G',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X' },     // 5
                {'X',' ',' ',' ',' ',' ',' ','G','G','G','G',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X' },     // 6
                {'X',' ',' ',' ',' ',' ',' ','G','G','G','G',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X' },     // 7
                {'X',' ',' ',' ',' ',' ',' ','G','G','G','G',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X' },     // 8
                {'X',' ',' ',' ',' ',' ',' ','G','G','G','G',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X' },     // 9
                {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X' },     // 10
                {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X' },     // 11
                {'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X' },     // 12
                {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X' },     // 13
            };

            player.pos = new Position(1, 1);

            //#region 몬스터 추가
            //Pokemon enemy1 = pokedex["이상해씨"].Clone();
            //enemy1.pos = new Position(22, 1);
            //enemies.Add(enemy1);
            //
            //Pokemon enemy2 = pokedex["파이리"].Clone();
            //enemy2.pos = new Position(3, 4);
            //enemies.Add(enemy2);
            //
            //Pokemon enemy3 = pokedex["리자몽"].Clone();
            //enemy3.pos = new Position(2,13);
            //enemies.Add(enemy3);
            //#endregion
        }
        public Pokemon GetPokemonInPosition(Position position)
        {
            foreach (Pokemon pokemon in enemies)
            {
                if (position.x == pokemon.pos.x && position.y == pokemon.pos.y)
                    return pokemon;
            }
            return null;
        }
        public static void Release()
        {

        }


    }
}
