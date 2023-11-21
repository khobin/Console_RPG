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
        public PokedexScene()
        {
            //json 파싱 해서 pokedex에 넣기
            JsonManager.Instance.LoadPokemonData();
            pokedex = JsonManager.Instance.GetAllData();
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();
            if(findPokemon != null)
            {
                sb.AppendLine("=============================Search================================");
                sb.AppendLine(findPokemon.PrintPokemon());
                sb.AppendLine("===================================================================");
            }
            foreach (Pokemon p in pokedex.Values)
            {
                sb.AppendLine(p.PrintPokemon());
                sb.AppendLine("-------------------------------------------------------------------");
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
                    //TODO : 포켓몬 찾는 class 새로 생성해서 전담하기.
                    break;
                case 2:
                    Game.Instance.MainMenu();
                    break;
            }
        }


    }
}
