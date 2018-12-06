using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Round
{
    public abstract class Figure
    {
        public Figure()
        {
            this.StartPoint = new Point();
        }

        public Figure(Point startPoint)
        {
            this.StartPoint = startPoint ?? throw new ArgumentNullException(nameof(startPoint));
        }

        public Point StartPoint { get; set; }

        public abstract void Show();
    }
}
