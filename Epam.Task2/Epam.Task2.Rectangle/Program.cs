using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.Rectangle
{
    //Task 1.1
    //Написать программу, которая определяет площадь прямоугольника со сторонами a и b.Если
    //пользователь вводит некорректные значения (отрицательные или ноль), должно выдаваться
    //сообщение об ошибке.Возможность ввода пользователем строки вида «абвгд» или нецелых чисел
    //игнорировать.
    public class Program
    {
        public enum Side
        {
            first,
            second
        }
        public static int EnterSide(Side sequence)
        {
            bool success = false;
            do
            {
                switch(sequence)
                {
                    case Side.first:
                        Console.Write($"Enter the {Side.first} side of rectangle: ");
                        break;
                    case Side.second:
                        Console.Write($"Enter the {Side.second} side of rectangle: ");
                        break;
                }
                string value = Console.ReadLine();//the string is needed to display the incorrect output

                success = Int32.TryParse(value, out int number);
                if (success)
                {
                    if (number > 0)
                    {
                        return number;
                    }
                    else if(number == 0)
                    {
                        Console.WriteLine("You entered a zero.");
                        success = false;
                    }
                    else
                    {
                        Console.WriteLine("You entered an unpositive number {0}.", number);
                        success = false;
                    }
                }
                else
                {
                    Console.WriteLine("Unable to parse '{0}'.", value);
                }
            }
            while (!success);
            return 0;
        }
        public static int Area(int firstSide, int secondSide)
        {
            return firstSide * secondSide;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Determining the area of a rectangle with sides a and b");
            int firstSide = EnterSide(Side.first);
            int secondSide = EnterSide(Side.second);
            int area = Area(firstSide, secondSide);

            Console.WriteLine(Environment.NewLine +
                $"Rectangle area with sides the {Side.first} side: {firstSide} " +
                $"and the {Side.second} side: {secondSide} is " + area);
        }
    }
}
