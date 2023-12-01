using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class BattleScene : Scene
    {
        private Pokemon enemy;
        private bool isWild; // true -> 쫓아오는 포켓몬 false -> 풀 숲에서 발견한 포켓몬
        private bool fighting = false;

        public BattleScene(Game game) : base(game)
        {
        }
        public void SetEnemy(Pokemon enemy, bool isWild)
        {
            this.enemy = enemy;
            this.isWild = isWild;
        }
        public override void Render()
        {
            StringBuilder sb = new StringBuilder();
            

            sb.AppendLine("====================Enemy====================");
            // 첫 싸움 -> 싸우고 있는 도중이 아님
            if (!fighting)
            {

                sb.AppendLine($"야생의 {enemy.Name}이/가 나타났다 !");
                sb.AppendLine(enemy.PrintPokemon());

                sb.AppendLine("1. 싸운다.");
                sb.AppendLine("2. 겁쟁이가 된다.");

            }
            // 싸우고 있는중
            else
            {
                sb.AppendLine($"{enemy.Name}\t\t\t{enemy.stat.hp,3}/{enemy.stat.maxHp,3}");
                sb.AppendLine("\n\n\n");
                sb.AppendLine("====================Pokemon====================");
                sb.AppendLine($"{Data.Instance.player.pokemon.Name}\t\t\t{Data.Instance.player.pokemon.stat.hp,3}/{Data.Instance.player.pokemon.stat.maxHp,3}");

                sb.AppendLine();
                sb.AppendLine("무엇을 할까?");
                sb.AppendLine("A. 싸운다.");
                sb.AppendLine("I : 인벤토리");
                sb.AppendLine("Q : 도망가기");
                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());
        }

        public override void Update()
        {
            StringBuilder sb = new StringBuilder();

            // 몬스터를 처음 만났을 때
            // 싸울지 안싸울지 결정
            if (!fighting)
            {
                switch (game.inputKey)
                {
                    case ConsoleKey.D1:
                        fighting = true;
                        break;
                    case ConsoleKey.D2:
                        RunAway();
                        break;
                    default:
                        
                        break;
                }
            }

            // 싸우기 시작함
            else
            {   
                // 플레이어 턴
                switch (game.inputKey)
                {
                    // 스킬 보여주는 로직
                    case ConsoleKey.A:
                        Attack();
                        break;
                    case ConsoleKey.I:
                        game.PushScene("인벤토리");
                        return;
                    case ConsoleKey.Q:
                        game.PopScene();
                        return;
                    default:
                        return;
                }
                if (enemy.stat.hp <= 0)
                {
                    EndBattle();
                    return;
                }

                // 상대 턴
                Random random = new Random();
                int enemySkillIndex = random.Next(0, enemy.skills.Count);
                enemy.UseSkill(Data.Instance.player.pokemon, enemySkillIndex);
            }
        }
        private void Attack()
        {
            for (int i = 0; i < Data.Instance.player.pokemon.skills.Count; i++)
            {
                // 스킬 두 번씩 나옴
                // Pokemon 생성자에서 한 번, Clone에서 한 번 더 들어가서인듯
                Console.WriteLine($"{i + 1}. {Data.Instance.player.pokemon.skills[i].PrintSkill()} ");
            }
            Console.WriteLine();
            Console.Write("스킬 인덱스 입력 : ");


            string input = Console.ReadLine();
            int command;
            if(!int.TryParse(input, out command))
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(1000);
                return;
            }

            if (command < 1 || command > Data.Instance.player.pokemon.skills.Count)
            {
                Console.WriteLine("잘못된 값 입력. .");
                return;
            }

            // player의 포켓몬이 스킬 쓰기 -> enemy에게.. 
            // action을 어떻게 구현할지 고민 -> action 안써도 가능할 듯 그냥 Pokemon의 useSkill 에 switch(SkillType) 으로 해도 상관 없을 지도
            //Data.player.pokemons[0].skills[command]
            Data.Instance.player.pokemon.UseSkill(enemy, command - 1);

        }
        private void EndBattle()
        {
            Console.Clear();
            // 쫓아오는 포켓몬이면 enemies에서 제거
            if(isWild)
            {
                Data.Instance.enemies.Remove(enemy);
            }
            Console.WriteLine($"{enemy.Name} 과 전투 종료 !");
            Thread.Sleep(1000);
            enemy = null;
            game.PopScene();

        }
        private void RunAway()
        {
            fighting = false;

            Console.WriteLine("겁쟁이처럼 도망쳤다. . !");
            Thread.Sleep(1000);
            enemy = null;
            game.PopScene();
        }
    }
}
