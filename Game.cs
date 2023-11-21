
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

        private Stack<Scene> sceneStack = new Stack<Scene>();

        public void Run()
        {
            Init();

            while(running)
            {
                Render();

                Update();
            }
        }
        private void Init()
        {

            pokedexScene = new PokedexScene(this);
            mainMenuScene = new MainMenuScene(this);

            curScene = sceneStack.Peek();
        }
        private void Render()   // 렌더에서 그리고 업데이트로 값 입력 받거나 상황이 달라짐
        {
            Console.Clear();
            curScene.Render();
        }
        private void Update()   // 계속 돌면서 값을 받고 그에 따라 그려주는게(Render) 달라지게 함
        {
            curScene.Update();
        }
        public void Deck()
        {
            curScene = pokedexScene;
        }
        public void GameOver()
        {
            running = false;
        }
        public void MainMenu()
        {
            curScene = mainMenuScene;
        }
        }
    }
}
