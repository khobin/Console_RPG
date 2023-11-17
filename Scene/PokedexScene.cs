using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class PokedexScene : Scene
    {
        Dictionary<int, Pokemon> pokedex;
        public PokedexScene(Game game) : base(game)
        {
            pokedex = new Dictionary<int, Pokemon>();
            //json 파싱 해서 pokedex에 넣기
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();
        }

        public override void Update()
        {
            
        }
    }
}
