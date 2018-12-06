using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task3.Game.Interfaces;

namespace Epam.Task3.Game.GameObjects
{
    public abstract class Enemy : GameObject, IMoveable
    {
        public abstract void Move(Algorithm algorithm);
    }
}
