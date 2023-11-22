using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class InventoryScene : Scene
    {
        public override void Render()
        {
            Data.inventory.ShowItems();
            Console.WriteLine("1. 사용하기");
            Console.WriteLine("2. 종료하기");
        }

        public override void Update()
        {
            int command;
            Game.Instance.Input(out command);

            switch (command)
            {
                case 1:
                    UseItem();
                    break;
                case 2:
                    Game.Instance.MainMenu();
                    break;
                default:
                    Console.WriteLine("잘못된 값 입력. .");
                    break;
            }
        }
        private void UseItem()
        {
            Console.WriteLine("사용할 아이템 인덱스 입력");
            int command;
            Game.Instance.Input(out command);
            if(command >= Data.inventory.items.Count)
            {
                Console.WriteLine("잘못된 값 입력. .");
                return;
            }
            Data.inventory.items[command].Use();
        }
    }
}
