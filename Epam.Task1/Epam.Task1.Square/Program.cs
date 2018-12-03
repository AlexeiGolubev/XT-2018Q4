using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Square
{
    public class Program
    {
        public static bool IsOdd(int number)
            => number % 2 == 1;

        public static void Stars(int number)
        {
            const string As = "*";
            const string Space = " ";

            if (IsOdd(number))
            {
                Console.WriteLine();
                for (int i = 1; i <= number; i++)
                {
                    for (int j = 1; j <= number; j++)
                    {
                        if (i != ((number / 2) + 1) || j != ((number / 2) + 1))
                        {
                            Console.Write(As);
                        }
                        else
                        {
                            Console.Write(Space);
                        }
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"You entered an even number {number}");
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine($"Drawing stars");
            Console.Write("Enter a positive odd number = ");

            string value = Console.ReadLine();
            bool success = int.TryParse(value, out int number);

            if (success)
            {
                if (number > 0)
                {
                    Stars(number);
                }
                else
                {
                    Console.WriteLine($"You entered an unpositive number {value}.");
                }
            }
            else
            {
                Console.WriteLine($"Unable to parse '{value}'.");
            }
        }
    }
}
