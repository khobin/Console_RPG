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

            sb.AppendLine("1. 포켓몬 도감");
            sb.AppendLine("2. 종료하기");

            Console.WriteLine(sb.ToString());
        }

        public override void Update()
        {
            string? input = Console.ReadLine();

            int command;
            if(int.TryParse(input, out command))
            {
                switch(command)
                {
                    case 1:
                        game.Deck();
                        break;
                    case 2:
                        game.GameOver();
                        break;
                }
            }


        }
    }
}
