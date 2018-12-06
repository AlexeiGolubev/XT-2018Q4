using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task3.Round;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Rectangle : Figure
    {
        private double firstSide;
        private double secondSide;

        public Rectangle() : base()
        {
            this.FirstSide = 1;
            this.SecondSide = 1;
        }

        public Rectangle(double firstSide, double secondSide) : base()
        {
            this.FirstSide = firstSide;
            this.SecondSide = secondSide;
        }

        public Rectangle(Point startPoint, double firstSide, double secondSide) : base(startPoint)
        {
            this.FirstSide = firstSide;
            this.SecondSide = secondSide;
        }

        public double FirstSide
        {
            get => this.firstSide;
            set
            {
                if (value > 0)
                {
                    this.firstSide = value;
                }
                else
                {
                    throw new ArgumentException("The rectangle cannot have a negative side");
                }
            }
        }

        public double SecondSide
        {
            get => this.secondSide;
            set
            {
                if (value > 0)
                {
                    this.secondSide = value;
                }
                else
                {
                    throw new ArgumentException("The rectangle cannot have a negative side");
                }
            }
        }

        public double Area => this.FirstSide * this.SecondSide;

        public override void Show()
        {
            Console.WriteLine($"The rectangle with start coordinates {this.StartPoint}, sides {this.FirstSide} and {this.SecondSide} and area is {this.Area}.");
        }
    }
}
