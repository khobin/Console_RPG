﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Console_RPG.Data;

namespace Console_RPG
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int[] types = new int[2];//public Data.Type type;
        public Data.Stat stat;
        private List<Skill>? skills;

        public Pokemon(int id, string name, int[] types, Data.Stat stat)
        {
            this.Id = id;
            this.Name = name;
            this.types = types;
            this.stat = stat;
        }
        public void AddSkill(Skill skill)
        {
            if (skills == null)
                skills = new List<Skill>();
            skills.Add(skill);
        }

        public string PrintPokemon()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"ID : {Id,03}\t");
            sb.AppendFormat($"Name : {Name}\t");
            sb.AppendFormat($"Type : ");
            foreach (int type in types)
            {
                sb.AppendFormat("{0} ",(Data.Type)type);
            }
            sb.AppendLine();
            sb.Append(stat.PrintStat());

            return sb.ToString();
        }


    }
}
