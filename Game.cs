
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

        private Stack<Scene> sceneStack = new Stack<Scene>();

        public Dictionary<string, Scene> sceneDic = new Dictionary<string, Scene>();

        private Scene curScene;

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

            sceneDic.Add("메인메뉴", new MainMenuScene());
            sceneDic.Add("인벤토리", new InventoryScene());
            sceneDic.Add("도감", new PokedexScene());
            sceneDic.Add("포켓몬선택",new SelectPokemonScene());
            sceneDic.Add("배틀",new BattleScene());

            sceneStack.Push(sceneDic["메인메뉴"]);

            curScene = sceneStack.Peek();
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
        public int Random(int max)
        {
            Random rand = new Random();
            return rand.Next(0, max);
        }
        public void GameOver()
        {
            running = false;
        }
        
        public void PushScene(string sceneKey)
        {
            if(!sceneDic.ContainsKey(sceneKey))
            {
                Console.WriteLine($"key {sceneKey} is not exist !!");
                return;
            }
            sceneStack.Push(sceneDic[sceneKey]);
            
            curScene = sceneStack.Peek();
        }
        public void PopScene()
        {
            if(sceneStack.Count > 0)
            {
                sceneStack.Pop();
            }
            if(!sceneStack.TryPeek(out curScene))
            {
                GameOver();
            }
        }
        private void Release()
        {
            Data.Release();
        }
    }
}
