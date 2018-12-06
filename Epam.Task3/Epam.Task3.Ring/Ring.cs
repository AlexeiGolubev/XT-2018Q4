using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task3.Round;

namespace Epam.Task3.Ring
{
    public class Ring : Figure
    {
        private Round.Round inner;
        private Round.Round outer;

        public Ring(Point startPoint, double innerRadius, double outerRadius) : base(startPoint)
        {
            if (outerRadius > innerRadius)
            {
                this.inner = new Round.Round(startPoint, radius: innerRadius) ?? throw new ArgumentNullException(nameof(innerRadius));
                this.outer = new Round.Round(startPoint, radius: outerRadius) ?? throw new ArgumentNullException(nameof(outerRadius));
            }
            else
            {
                throw new ArgumentException("The outer radius must be greater than the inner radius");
            }
        }

        public Round.Round Inner
        {
            get => this.inner;
            set
            {
                if (value.Radius < this.outer.Radius)
                {
                    this.inner = value;
                }
                else
                {
                    throw new ArgumentException("The inner radius must be less than the outer radius");
                }
            }
        }

        public Round.Round Outer
        {
            get => this.outer;
            set
            {
                if (value.Radius > this.inner.Radius)
                {
                    this.outer = value;
                }
                else
                {
                    throw new ArgumentException("The outer radius must be greater than the inner radius");
                }
            }
        }

        public double CircumFerence => this.Inner.CircumFerence + this.Outer.CircumFerence;

        public double Area => this.Outer.Area - this.Inner.Area;

        public double Width => this.Outer.Radius - this.Inner.Radius;

        public override void Show()
        {
            Console.WriteLine($"The ring with center {this.StartPoint}, inner radius is {this.Inner.Radius} and outer radius is {this.Outer.Radius}.");
            Console.WriteLine($"Sum length is {this.CircumFerence}, area is {this.Area} and width is {this.Width}.");
        }
    }
}
