using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public abstract class Scene
    {
        public abstract void Render();
        public abstract void Update();
    }
}
