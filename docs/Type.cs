using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public static class Type
    {
        public enum PokemonType
        {
            노말 = 0,
            불꽃 = 1,
            물 = 2,
            풀 = 3,
            전기 = 4,
            얼음 = 5,
            격투 = 6,
            독 = 7,
            땅 = 8,
            비행 = 9,
            에스퍼 = 10,
            벌레 = 11,
            바위 = 12,
            고스트 = 13,
            드래곤 = 14,
            악 = 15,
            강철 = 16,
            페어리 = 17
        }
        public enum ItemType
        {
            볼 = 0,
            배틀아이템 = 1,
            기타 = 2,
        }
        public enum SkillType
        {
            공격 = 0,
            디버프 = 1,
        }
    }
}
