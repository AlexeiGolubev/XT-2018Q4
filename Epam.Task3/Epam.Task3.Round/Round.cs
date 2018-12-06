using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Round
{
    public class Round : RoundShape
    {
        public Round(Point startPoint, double radius) : base(startPoint, radius)
        {
        }

        public double CircumFerence => 2 * Math.PI * this.Radius;

        public double Area => Math.PI * this.Radius * this.Radius;

        public static implicit operator Round(double radius)
        {
            return new Round(new Point(), radius);
        }

        public override void Show()
        {
            Console.WriteLine($"The round with center {this.StartPoint} and radius is {this.Radius}.");
            Console.WriteLine($"Length is {this.CircumFerence} and area is {this.Area}.");
        }
    }
}
