using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Sequence
{
    public class Program
    {
        private static string NumberString(int n)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 1; i < n; i++)
            {
                str.Append(i + ", ");
            }
            str.Append(n);
            return str.ToString();
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Output a sequence of numbers\n");
            Console.Write("Enter a positive number = ");
            string value = Console.ReadLine();

            bool success = Int32.TryParse(value, out int number);
            if (success)
            {
                if (number > 0)
                {
                    Console.WriteLine(NumberString(number));
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
