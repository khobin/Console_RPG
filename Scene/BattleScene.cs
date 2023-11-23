using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class BattleScene : Scene
    {
        Pokemon enemy;
        bool fighting = false;
        bool hasPokemon;
        
        public override void Render()
        {
            hasPokemon = Data.player.pokemons.Count > 0 ? true : false;
            if (!hasPokemon) return;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("====================Enemy====================");
            if (!fighting)
            {

                Random random = new Random();
                int randIdx = random.Next(0, Data.pokedex.Count);

                enemy = Data.pokedex.ElementAt(randIdx).Value.Clone();

                sb.AppendLine($"야생의 {enemy.Name}이/가 나타났다 !");
                sb.AppendLine(enemy.PrintPokemon());
                fighting = true;
            }
            else
            {
                sb.AppendLine($"{enemy.Name}\t\t\t{enemy.stat.hp,3}/{enemy.stat.maxHp,3}");
                sb.AppendLine("\n\n\n");
                sb.AppendLine("====================Pokemon====================");
                sb.AppendLine($"{Data.player.pokemons[0].Name}\t\t\t{Data.player.pokemons[0].stat.hp,3}/{Data.player.pokemons[0].stat.maxHp,3}");
            }
            Console.WriteLine(sb.ToString());
        }

        public override void Update()
        {
            StringBuilder sb = new StringBuilder();
            if (!hasPokemon)
            {
                Console.WriteLine("싸울 수 있는 포켓몬이 없습니다.");
                Game.Instance.PopScene();
                return;
            }
                
            if (fighting)
            {
                sb.AppendLine("무엇을 할까?");
                for (int i = 0; i < Data.player.pokemons[0].skills.Count; i++)
                {
                    sb.Append($"{i + 1}. {Data.player.pokemons[0].skills[i].PrintSkill()}");
                }
                sb.AppendLine();
                sb.Append("사용할 스킬 인덱스 입력 : ");
                Console.Write(sb.ToString());

                int command;
                Game.Instance.Input(out command);
                if (command < 1 || command > Data.player.pokemons[0].skills.Count)
                {
                    Console.WriteLine("잘못된 값 입력. .");
                    return;
                }

                // player의 포켓몬이 스킬 쓰기 -> enemy에게.. 
                // action을 어떻게 구현할지 고민 -> action 안써도 가능할 듯 그냥 Pokemon의 useSkill 에 switch(SkillType) 으로 해도 상관 없을 지도
                //Data.player.pokemons[0].skills[command]

            }
            else
            {
                
            }
        }
    }
}
