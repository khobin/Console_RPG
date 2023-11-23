using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class PokedexScene : Scene
    {
        Dictionary<string, Pokemon> pokedex;
        Pokemon findPokemon = null;
        
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
            foreach (Pokemon p in Data.pokedex.Values)
            {
                sb.AppendLine(p.PrintPokemon());
            }
            sb.AppendLine("1. 검색하기");
            sb.AppendLine("2. 돌아가기");
            Console.WriteLine(sb.ToString());
        }

        
        public override void Update()
        {
            int command;
            Game.Instance.Input(out command);
            switch (command)
            {
                case 1:
                    Console.WriteLine("검색할 포켓몬의 이름을 입력하세요.");
                    string find;
                    Game.Instance.Input(out find);
                    if(pokedex.ContainsKey(find))
                        findPokemon = pokedex[find];
                    else
                        Console.WriteLine("잘못된 값 입력. .");
                    break;
                case 2:
                    Game.Instance.PopScene();
                    break;
            }
        }


    }
}
