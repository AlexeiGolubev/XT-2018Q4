using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Simple
{
    public class Program
    {
        private static bool Simple(int n)
        {
            bool result = true;
            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Checking the number for simplicity\n");
            Console.Write("Enter a positive number = ");
            string value = Console.ReadLine();

            bool success = Int32.TryParse(value, out int number);
            if (success)
            {
                if (number > 0)
                {
                    Console.WriteLine($"\nIs {number} a simple number? - " + Simple(number));
                }
                else
                {
                    Console.WriteLine("You entered an unpositive number {0}.", number);
                }
            }
            else
            {
                Console.WriteLine("Unable to parse '{0}'.", value);
            }
        }
    }
}
