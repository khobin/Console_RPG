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

            
            sb.AppendLine("아이템을 사용할 포켓몬 인덱스 입력");
            sb.AppendLine("9.돌아가기");

            Console.WriteLine(sb.ToString());
        }

        public override void Update()
        {
            int command;
            Game.Instance.Input(out command);
            if (command == 9)
            {

            }
            
            

        }
    }
}
