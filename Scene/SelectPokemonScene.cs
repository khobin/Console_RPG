using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class SelectPokemonScene : Scene
    {

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Data.player.pokemons.Count; i++)
            {
                sb.AppendLine($"Index : {i}");
                sb.AppendLine(Data.player.pokemons[i].PrintPokemon());
            }
            sb.AppendLine("아이템을 사용할 포켓몬 인덱스 입력");
            sb.AppendLine("9.돌아가기");
        }

        public override void Update()
        {
            int command;
            Game.Instance.Input(out command);
            if (command == 9)
            {

            }
            if (command >= Data.player.pokemons.Count)
            {
                Console.WriteLine("잘못된 값 입력. .");
            }
            
            

        }
    }
}
