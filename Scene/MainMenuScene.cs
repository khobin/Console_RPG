using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class MainMenuScene : Scene
    {
        public MainMenuScene() { }
        
        public override void Render()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("1. 포켓몬 도감");
            sb.AppendLine("2. 인벤토리");
            sb.AppendLine("3. 배틀");
            sb.AppendLine("3. 종료하기");

            Console.WriteLine(sb.ToString());
        }

        public override void Update()
        {
            int command;
            
            Game.Instance.Input(out command);
            switch (command)
            {
                case 1:
                    Game.Instance.PushScene("도감");
                    break;
                case 2:
                    Game.Instance.PushScene("인벤토리");
                    break;
                case 3:
                    Game.Instance.PushScene("배틀");
                    break;
                case 4:
                    Game.Instance.PopScene();
                    break;
                default:
                    Console.WriteLine("잘못된 값 입력. .");
                    break;
            }
        }
    }
}
