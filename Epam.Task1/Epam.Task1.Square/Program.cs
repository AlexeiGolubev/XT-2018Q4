using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Square
{
    public class Program
    {
        private static void Stars(int n)
        {
            if (n % 2 == 1)
            {
                Console.WriteLine();
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        if (i != (n / 2 + 1) || j != (n / 2 + 1))
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine("You entered an even number {0}", n);
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Drawing stars\n");
            Console.Write("Enter a positive odd number = ");
            string value = Console.ReadLine();

            bool success = Int32.TryParse(value, out int number);
            if (success)
            {
                if(number > 0)
                    Stars(number);
                else
                    Console.WriteLine("You entered an unpositive number {0}.", number);
            }
            else
            {
                Console.WriteLine("Unable to parse '{0}'.", value);
            }
        }
    }
}
