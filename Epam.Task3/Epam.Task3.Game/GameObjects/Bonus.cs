using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task3.Game.Interfaces;

namespace Epam.Task3.Game.GameObjects
{
    public abstract class Bonus : GameObject, IBooster
    {
        public abstract void Boost();
    }
}
