using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class MainMenuScene : Scene
    {
        public MainMenuScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("1. 모험");
            sb.AppendLine("2. 포켓몬 도감");
            sb.AppendLine("3. 인벤토리");
            sb.AppendLine("Q. 종료하기");

            Console.WriteLine(sb.ToString());
        }

        public override void Update()
        {
            switch (game.inputKey)
            {
                case ConsoleKey.D1:
                    game.PushScene("맵");
                    break;
                case ConsoleKey.D2:
                    game.PushScene("도감");
                    break;
                case ConsoleKey.D3:
                    game.PushScene("인벤토리");
                    break;
                case ConsoleKey.Q:
                    game.PopScene();
                    break;
                default:
                    Console.WriteLine("잘못된 값 입력. .");
                    break;
            }
        }
    }
}
