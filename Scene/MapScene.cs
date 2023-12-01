using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class MapScene : Scene
    {
        private bool[,] map;
        public MapScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            PrintMap();
            PrintInfo();
        }

        public override void Update()
        {
            
            switch (game.inputKey)
            {
                // 플레이어 이동
                case ConsoleKey.UpArrow:
                    Data.Instance.player.Move(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                    Data.Instance.player.Move(Direction.Down);
                    break;
                case ConsoleKey.LeftArrow:
                    Data.Instance.player.Move(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    Data.Instance.player.Move(Direction.Right);
                    break;
                case ConsoleKey.I:
                    game.PushScene("인벤토리");
                    return;
                case ConsoleKey.P:
                    game.PushScene("도감");
                    return;
            }

            // 야생포켓몬 이동
            foreach (Pokemon pokemon in Data.Instance.enemies)
            {
                pokemon.MoveBaseAstar();
            }

            // 야생포켓몬이 플레이어를 만나면 전투씬 호출
            Pokemon wildPokemon = Data.Instance.GetPokemonInPosition(Data.Instance.player.pos);
            if(wildPokemon != null)
            {
                game.PushScene("배틀", wildPokemon, isWild : true);
                return;
            }

            // 플레이어가 G를 밟으면 일정 확률로 랜덤포켓몬과 결투
            if ('G' == Data.Instance.map[Data.Instance.player.pos.y, Data.Instance.player.pos.x])
            {
                Random random = new Random();
                int per = random.Next(0, 5);
                if (per % 2 == 0)
                {
                    Pokemon enemy = Data.Instance.pokedex.ElementAt(random.Next(0, Data.Instance.pokedex.Count)).Value.Clone();
                    game.PushScene("배틀", enemy);
                    return;
                }
            }
            
        }
        public void PrintMap()
        {
            StringBuilder sb = new StringBuilder(0);
            for (int y = 0; y < Data.Instance.map.GetLength(0); y++)
            {
                for (int x = 0; x < Data.Instance.map.GetLength(1); x++)
                {
                    if ('X' == Data.Instance.map[y, x])
                    {
                        sb.Append('X');
                    }
                    else if ('G' == Data.Instance.map[y, x])
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        sb.Append('G');
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                        sb.Append(' ');
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(Data.Instance.player.pos.x, Data.Instance.player.pos.y);
            Console.Write(Data.Instance.player.icon);

            Console.ForegroundColor= ConsoleColor.Red;
            foreach (Pokemon enemy in Data.Instance.enemies)
            {
                Console.SetCursorPosition(enemy.pos.x, enemy.pos.y);
                Console.Write(enemy.icon);
            }


            Console.ForegroundColor = ConsoleColor.White;
        }
        public void PrintInfo()
        {
            int padding = 5;
            Console.SetCursorPosition(Data.Instance.map.GetLength(1) + padding, 0);
            Console.Write("I : 인벤토리");
            Console.SetCursorPosition(Data.Instance.map.GetLength(1) + padding, 1);
            Console.Write("P : 포켓몬 도감");
            
        }
    }
}
