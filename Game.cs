
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

        public int command;
        public ConsoleKey inputKey;

        private Stack<Scene> sceneStack;

        public Dictionary<string, Scene> sceneDic;

        private Scene curScene;

        public Game() { }
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
            Console.CursorVisible = false;
            
            Data.Instance.Init();

            sceneStack = new Stack<Scene>();

            sceneDic = new Dictionary<string, Scene>
            {
                { "메인메뉴", new MainMenuScene(this) },
                { "인벤토리", new InventoryScene(this) },
                { "도감", new PokedexScene(this) },
                { "맵", new MapScene(this) },
                { "배틀", new BattleScene(this) }
            };

            sceneStack.Push(sceneDic["메인메뉴"]);

            curScene = sceneStack.Peek();
        }
        private void Render()   // 렌더에서 그리고 업데이트로 값 입력 받거나 상황이 달라짐
        {
            Console.Clear();
            curScene.Render();
        }
        private void Update()   // 계속 돌면서 값을 받고 그에 따라 그려주는게(Render) 달라지게 함
        {
            Input();
            curScene.Update();
        }
        public void Input()
        {
            ConsoleKeyInfo input = Console.ReadKey();
            inputKey = input.Key;
            Console.WriteLine();
        }
        
        public void GameOver()
        {
            running = false;
        }
        
        public void PushScene(string sceneKey, Pokemon battlePokemon = null, bool isWild = false)
        {
            Scene scene;
            // sceneDic에 sceneKey가 없다면
            if(false == sceneDic.TryGetValue(sceneKey, out scene))
            {
                Console.Clear();
                Console.WriteLine("Push Scene Error !");
                Thread.Sleep(1000);
                Environment.Exit(0); // 강제 종료

            }
            else
            {
                sceneStack.Push(scene);
                curScene = sceneStack.Peek();
            }
            
            if(battlePokemon != null)
            {
                (scene as BattleScene).SetEnemy(battlePokemon, isWild);
            }
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
            Console.Clear();
            
            Data.Release();
        }
    }
}
