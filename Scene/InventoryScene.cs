using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class InventoryScene : Scene
    {
        public InventoryScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            Data.Instance.inventory.ShowItems();
            Console.WriteLine("1. 사용하기");
            Console.WriteLine("2. 종료하기");
        }

        public override void Update()
        {
           
            switch (game.inputKey)
            {
                case ConsoleKey.D1:
                    UseItem();
                    break;
                case ConsoleKey.D2:
                    game.PopScene();
                    break;
                default:
                    Console.WriteLine("잘못된 값 입력. .");
                    Thread.Sleep(1000);
                    break;
            }
        }
        private void UseItem()
        {
            if (Data.Instance.inventory.items.Count <= 0)
            {
                Console.WriteLine("아이템이 없습니다.");
                Thread.Sleep(1000);
                game.PopScene();
                return;
            }
            Console.WriteLine("사용할 아이템 인덱스 입력");
            
            //Data.Instance.inventory.items[command].Use();
        }
    }
}
