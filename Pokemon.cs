using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Console_RPG.Data;

namespace Console_RPG
{
    public class Pokemon 
    {
        public int Id { get; }
        public string? Name { get; }
        public int[] types = new int[2];//public Type.PokemonType type;
        public Type.Stat stat;
        public List<Skill>? skills;

        public Pokemon(int id, string name, int[] types, Type.Stat stat)
        {
            this.Id = id;
            this.Name = name;
            this.types = types;
            this.stat = stat;
            skills = new List<Skill>();
            if(skills.Count == 0)
                skills.Add(skillDic["몸통박치기"].Clone());
        }
        
        public Pokemon Clone()
        {
            Pokemon p = new Pokemon(Id, Name, types, stat);
            
            if(skills != null && skills.Count > 0)
            {
                foreach (Skill skill in skills)
                {
                    p.AddSkill(skill.Clone());
                }
            }
            return p;
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
            Skill skill = skills[index];
            Console.WriteLine($"{Name} 이/가 {enemy.Name}에게 {skill.Name}을 사용합니다.");
            Thread.Sleep(1000);
            Console.WriteLine($"{skill.Desc} ! !");
            switch (skill.skillType)
            {
                case Type.SkillType.공격:
                    Attack(enemy, skill);
                    break;
                case Type.SkillType.디버프:
                    DeBuff(enemy, skill);
                    break;

            }
        }
        private void Attack(Pokemon enemy, Skill skill)
        {
            Thread.Sleep(1000);


            enemy.TakeDamage(skill.Amount);
        }
        private void TakeDamage(int damage)
        {
            // PokemonType, SkillType 비교해서 데미지 계산
            // ex) 효과가 굉장했다. 미비했다.
            Thread.Sleep(1000);

            Console.WriteLine($"{Name} 이/가 {damage - stat.defense}만큼 공격받았습니다.");
            stat.hp -= (damage - stat.defense);
        }
        private void DeBuff(Pokemon enemy, Skill skill)
        {
            Thread.Sleep(1000);

            Console.WriteLine($"{enemy.Name}의 방어력이 {skill.Amount}만큼 떨어졌습니다.");
            enemy.stat.defense -= skill.Amount;
        }
        public string PrintPokemon()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"ID : {Id,03:X3}\t");
            sb.AppendFormat($"Name : {Name}\t\t");
            sb.AppendFormat($"Type : ");
            foreach (int type in types)
            {
                sb.AppendFormat("{0} ",(Type.PokemonType)type);
            }
            sb.AppendLine("\n");
            sb.Append(stat.PrintStat());
            sb.Append("\n-------------------------------------------------------------------");

            return sb.ToString();
        }

        
    }
}
