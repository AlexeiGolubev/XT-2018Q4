using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Round
{
    public class RoundShape : Figure
    {
        private double radius;

        public RoundShape(Point startPoint, double radius) : base(startPoint)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get => this.radius;
            set
            {
                if (value >= 0)
                {
                    this.radius = value;
                }
                else
                {
                    throw new ArgumentException("The round cannot have a negative radius");
                }
            }
        }

        public override void Show()
        {
            Console.WriteLine($"The round shape with center {this.StartPoint} and radius is {this.Radius}.");
        }
    }
}
