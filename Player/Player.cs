﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class Player
    {
        int money;
        public List<Pokemon> pokemons;


        public void ItemUse(Item item)
        {
            switch (item.ItemType)
            {
                case Type.ItemType.볼:

                    break;
                case Type.ItemType.물약:
                    HealItem(item);
                    break;
                case Type.ItemType.배틀아이템:
                    BattleItem(item);
                    break;
                case Type.ItemType.기타:
                    
                    break;

            }
        }
        //private Pokemon SelectPokemon()
        //{
        //    Console.WriteLine("아이템을 사용할 포켓몬을 고르세요.");
        //    //TODO : SelectPokemom Scene , class만들기.
        //    StringBuilder sb = new StringBuilder();
        //    for (int i = 0; i < pokemons.Count; i++)
        //    {
        //        sb.AppendLine($"Index : {i}");
        //        sb.AppendLine(pokemons[i].PrintPokemon());
        //    }
        //}
        private void HealItem(Item item)
        {

        }
        private void BattleItem(Item item)
        {

        }
    }
}