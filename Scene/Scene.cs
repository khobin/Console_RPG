using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public abstract class Scene
    {
        protected Game game;
        public Scene(Game game)
        {
            this.game = game;
        }

        public abstract void Render();
        public abstract void Update();
    }
}
