using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.Rectangle
{
    public class Program
    {
        public enum Side
        {
            first = 1,
            second = 2
        }

        public static int EnterSide(Side sequence)
        {
            bool success = false;
            do
            {
                switch (sequence)
                {
                    case Side.first:
                        Console.Write($"Enter the {Side.first} side of rectangle: ");
                        break;
                    case Side.second:
                        Console.Write($"Enter the {Side.second} side of rectangle: ");
                        break;
                }

                string value = Console.ReadLine();
                success = int.TryParse(value, out int number);

                if (success)
                {
                    if (number > 0)
                    {
                        return number;
                    }
                    else if (number == 0)
                    {
                        Console.WriteLine("You entered a zero.");
                        success = false;
                    }
                    else
                    {
                        Console.WriteLine($"You entered an unpositive number {value}.");
                        success = false;
                    }
                }
                else
                {
                    Console.WriteLine($"Unable to parse '{value}'.");
                }
            }
            while (!success);
            return 0;
        }

        public static int Area(int firstSide, int secondSide)
            => firstSide * secondSide;

        public static void Main(string[] args)
        {
            Console.WriteLine("Determining the area of a rectangle with sides a and b");
            int firstSide = EnterSide(Side.first);
            int secondSide = EnterSide(Side.second);
            int area = Area(firstSide, secondSide);

            Console.WriteLine();
            Console.WriteLine($"Rectangle area with sides {firstSide} and {secondSide} is {area}");
        }
    }
}
