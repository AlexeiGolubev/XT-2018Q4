using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task3.Round;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Line : Figure
    {
        private Point endPoint;

        public Line() : base()
        {
            this.endPoint = new Point(1, 1);
        }

        public Line(Point startPoint, Point endPoint) : base(startPoint)
        {
            if ((startPoint.X != endPoint.X) && (startPoint.Y != endPoint.Y))
            {
                this.endPoint = endPoint;
            }
            else
            {
                throw new ArgumentException("The line is set by two different points");
            }
        }

        public Point EndPoint
        {
            get => this.endPoint;
            set
            {
                if ((this.StartPoint.X != this.endPoint.X) && (this.StartPoint.Y != this.endPoint.Y))
                {
                    this.endPoint = value;
                }
                else
                {
                    throw new ArgumentException("The line is set by two different points");
                }
            }
        }

        public override void Show()
        {
            Console.WriteLine($"The line with start coordinates {this.StartPoint} and end coordinates {this.EndPoint}.");
        }
    }
}
