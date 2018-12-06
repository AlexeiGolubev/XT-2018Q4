using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Triangle
{
    public class Triangle
    {
        private double a;
        private double b;
        private double c;

        public Triangle(double a, double b, double c)
        {
            if (a < 0 || b < 0 || c < 0)
            {
                throw new ArgumentException("The triangle cannot have a negative or zero side");
            }

            if (a + b < c || a + c < b || c + b < a)
            {
                throw new ArgumentException("The side of the triangle cannot be greater than the sum of the other two");
            }

            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double A
        {
            get => this.a;
            set
            {
                if (value > 0)
                {
                    if (value > this.b + this.c)
                    {
                        throw new ArgumentException("The side of the triangle cannot be greater than the sum of the other two");
                    }
                    else
                    {
                        this.a = value;
                    }
                }
                else
                {
                    throw new ArgumentException("The triangle cannot have a negative or zero side");
                }
            }
        }

        public double B
        {
            get => this.b;
            set
            {
                if (value > 0)
                {
                    if (value > this.a + this.c)
                    {
                        throw new ArgumentException("The side of the triangle cannot be greater than the sum of the other two");
                    }
                    else
                    {
                        this.b = value;
                    }
                }
                else
                {
                    throw new ArgumentException("The triangle cannot have a negative or zero side");
                }
            }
        }

        public double C
        {
            get => this.c;
            set
            {
                if (value > 0)
                {
                    if (value > this.a + this.b)
                    {
                        throw new ArgumentException("The side of the triangle cannot be greater than the sum of the other two");
                    }
                    else
                    {
                        this.c = value;
                    }
                }
                else
                {
                    throw new ArgumentException("The triangle cannot have a negative or zero side");
                }
            }
        }

        public double Perimeter => this.a + this.b + this.c;

        public double PoliPerimeter => this.Perimeter / 2;

        public double Area => Math.Sqrt(this.PoliPerimeter * (this.PoliPerimeter - this.A) * (this.PoliPerimeter - this.B) * (this.PoliPerimeter - this.C));

        public override string ToString()
        {
            return $"The triangle with the sides {this.a}, {this.b}, {this.c}.{Environment.NewLine}Area is {this.Area} and perimeter is {this.Perimeter}";
        }
    }
}
