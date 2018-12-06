using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Game.GameObjects
{
    public class PlayingField : GameObject
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override void Interact()
        {
            throw new NotImplementedException();
        }
    }
}
