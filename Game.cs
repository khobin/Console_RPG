
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class Game
    {
        public bool running = true;

        private Scene curScene;
        private MainMenuScene mainMenuScene;
        private PokedexScene pokedexScene;

        private Game() { }
        private static Game instance = null;
        public static Game Instance
        {
            get
            {
                if (instance == null)
                    instance = new Game();
                return instance;
            }
        }
        public void Run()
        {
            Init();

            while (running)
            {
                Render();

                Update();
            }
            Release();
        }
        private void Init()
        {
            Data.Init();

            pokedexScene = new PokedexScene();
            mainMenuScene = new MainMenuScene();

            curScene = mainMenuScene;
        }
        private void Render()   // 렌더에서 그리고 업데이트로 값 입력 받거나 상황이 달라짐
        {
            Thread.Sleep(1000);
            Console.Clear();
            curScene.Render();
        }
        private void Update()   // 계속 돌면서 값을 받고 그에 따라 그려주는게(Render) 달라지게 함
        {
            curScene.Update();
        }


        public bool Input(out int command)
        {
            string input = Console.ReadLine();
            bool result = int.TryParse(input, out command);
            return result;
        }
        public bool Input(out string name)
        {
            string? input = Console.ReadLine();
            name = input;
            return input != null;
        }
        public void GameOver()
        {
            running = false;
        }
        public void Deck()
        {
            curScene = pokedexScene;
        }
        public void MainMenu()
        {
            curScene = mainMenuScene;
        }

        private void Release()
        {
            Data.Release();
        }
    }
}
