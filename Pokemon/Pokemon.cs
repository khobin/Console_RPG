using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class Pokemon 
    {
        public int Id { get; }
        public string? Name { get; }
        public int type;//public Type.PokemonType type;
        public Stat stat;
        public List<Skill>? skills;
        private int exp;
        // Map Move
        public Position pos;
        public char icon;
        
        // A* Algorithm
        private Position destPosition;
        private List<Position> path;
        public Pokemon(int id, string name, string type, Stat stat)
        {
            this.Id = id;
            this.Name = name;
            if (Enum.TryParse(type, out PokemonType enumType))
            {
                this.type = (int)enumType;
            }
            
            this.stat = stat;
            icon = 'M';
            skills = new List<Skill>();
            if(skills.Count == 0)
                skills.Add(Data.Instance.skillDic["몸통박치기"].Clone());
            path = new List<Position>();
        }
        
        public Pokemon Clone()
        {
            Pokemon p = new Pokemon(Id, Name, type.ToString(), stat);
            
            if(skills != null && skills.Count > 0)
            {
                // 새로 복사되는 포켓몬
                for (int i = 0; i < p.skills.Count; i++)
                {
                    // 기존의 포켓몬
                    for (int j = 0; j < skills.Count; j++)
                    {
                        if (p.skills[i].Equals(skills[j]))
                            continue;
                        else
                            p.skills.Add(skills[j].Clone());
                    }
                }
            }
            return p;
        }
        public void MoveBaseAstar()
        {
            Position nextPosition;

            // 이미 도착점이 같다면(플레어가 안움직임)
            // 경로를 다시 탐색하지 않고 이동
            if (false == Astar.PathFinding(pos, destPosition, path))
            {
                // path[0]으로 이동시키고
                // 0번 인덱스 제거 -> 그래야 같은 위치가 아니라 계속 움직임
                nextPosition = path[0];
                if (path.Count != 1)
                    path.RemoveAt(0);
            }
            else
                nextPosition = path[0];

            destPosition = path[path.Count - 1];

            pos = nextPosition;

        }
        public void AddSkill(Skill skill)
        {
            if(skills.Count == 4)
            {
                Console.WriteLine("스킬칸 꽉참;");
                //TODO : Skill 꽉 찼을 때 바꿀 스킬 고르기
            }
            else
            {
                skills.Add(skill);
            }
            
        }
        public void UseSkill(Pokemon enemy, int index)
        {
            Skill usingSkill = skills[index];
            if(usingSkill.PP <= 0)
            {
                Console.WriteLine("스킬 포인트가 없습니다.");
                Thread.Sleep(1000);
                return;
            }
            usingSkill.PP--;
            Console.WriteLine($"{Name} 이/가 {enemy.Name}에게 {usingSkill.Name}을 사용합니다.");
            Thread.Sleep(1000);
            Console.WriteLine($"{usingSkill.Desc} ! !");
            switch (usingSkill.skillType)
            {
                case SkillType.공격:
                    Attack(enemy, usingSkill);
                    enemy.TakeDamage(usingSkill.Amount);
                    break;
                case SkillType.디버프:
                    DeBuff(enemy, usingSkill);
                    break;

            }
        }
        private void Attack(Pokemon enemy, Skill skill)
        {
            // TODO : PokemonType, SkillType 비교해서 데미지 계산
            // ex) 효과가 굉장했다. 미비했다.
            int totalDamage = skill.Amount;


            // 0001 불
            // 0010 물
            // 0100 풀
            // 1000 노말
            int usingSkillType = skill.pokemonType;

            // 노말 스킬이 아닌
            // 다른 속성 공격일 때 totalDamage 변경
            if((usingSkillType & (int)PokemonType.노말) == 0)    // & == 0 -> 노말로 때린게 아님 -> 속성 중 하나가 있는 스킬
            {
                if((usingSkillType >> 1) == 0) // 0001(불꽃) >> 1 == 0000 -> 순회 돌 수 있게 1000(풀)으로 바꿔줌
                {
                    // 불꽃일 때만 다르게
                    usingSkillType = 0b0100;
                    // 상대: 불 나 : 풀
                    if(usingSkillType == type)                }
                else if(usingSkillType << 1 == type)
                {

                }


            }

            // 노말 스킬로 때렸다면
            // totalDamage 변화 없음
            enemy.TakeDamage(totalDamage);
            Thread.Sleep(1000);
        }
        public void DamageCalc(ref int totalDamage, bool critical)
        {

        }
        private void TakeDamage(int damage)
        {
            Console.WriteLine($"{Name} 이/가 {damage}만큼 공격받았습니다.");
            Thread.Sleep(1000);
            stat.hp -= (damage);
        }
        private void DeBuff(Pokemon enemy, Skill skill)
        {
            Thread.Sleep(1000);

            Console.WriteLine($"{enemy.Name}의 방어력이 {skill.Amount}만큼 떨어졌습니다.");
            Thread.Sleep(1000);
            enemy.stat.defense -= skill.Amount;
        }
        public string PrintPokemon()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"ID : {Id,03:X3}\t");
            sb.AppendFormat($"Name : {Name}\t\t");
            sb.AppendFormat($"Type : {(PokemonType)type}");           
            sb.AppendLine("\n");
            sb.Append(stat.PrintStat());
            sb.Append("\n-------------------------------------------------------------------");

            return sb.ToString();
        }

        public void GainExp(int exp)
        {
            this.exp += exp;
        }
    }
}
