using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class PokedexScene : Scene
    {
        Pokemon findPokemon = null;

        public PokedexScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();
            if(findPokemon != null)
            {
                sb.AppendLine("=============================Search================================");
                sb.AppendLine(findPokemon.PrintPokemon());
                sb.AppendLine("===================================================================");

                findPokemon = null;
            }
            foreach (Pokemon p in Data.Instance.pokedex.Values)
            {
                sb.AppendLine(p.PrintPokemon());
            }
            sb.AppendLine("1. 검색하기");
            sb.AppendLine("2. 돌아가기");
            Console.WriteLine(sb.ToString());
        }

        
        public override void Update()
        {
            switch (game.inputKey)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("검색할 포켓몬의 이름을 입력하세요.");
                    string find = Console.ReadLine();
                    if(Data.Instance.pokedex.ContainsKey(find))
                        findPokemon = Data.Instance.pokedex[find];
                    else
                    {
                        Console.WriteLine("잘못된 값 입력. .");
                        Thread.Sleep(1000);
                    }
                    break;
                case ConsoleKey.D2:
                    game.PopScene();
                    break;
            }
        }


    }
}
