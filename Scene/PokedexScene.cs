using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class PokedexScene : Scene
    {
        List<Pokemon> pokedex;
        //Dictionary<string, Pokemon> pokedex;
        public PokedexScene(Game game) : base(game)
        {
            
            //pokedex = new Dictionary<string, Pokemon>();

            //json 파싱 해서 pokedex에 넣기
            JsonManager.instance.LoadPokemonData();
            pokedex = JsonManager.instance.GetAllData();
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Pokemon p in pokedex)
            {
                sb.AppendLine(p.PrintPokemon());
            }
            sb.AppendLine("1. 검색하기");
            sb.AppendLine("2. 돌아가기");
            Console.WriteLine(sb.ToString());
        }

        public override void Update()
        {
            string input = Console.ReadLine();

            int command;
            if (int.TryParse(input, out command))
            {
                switch (command)
                {
                    case 1:
                        Console.WriteLine("검색. . .");
                        break;
                    case 2:
                        game.MainMenu();
                        break;
                }
                Thread.Sleep(1000);
            }

        }
    }
}
