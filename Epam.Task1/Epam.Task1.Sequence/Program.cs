using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Sequence
{
    public class Program
    {
        public static string NumberString(int number)
        {
            const string Comma = ", ";
            StringBuilder str = new StringBuilder();

            for (int i = 1; i < number; i++)
            {
                str.Append(i + Comma);
            }

            str.Append(number);
            return str.ToString();
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Output a sequence of numbers");
            Console.Write("Enter a positive number = ");

            string value = Console.ReadLine();
            bool success = int.TryParse(value, out int number);

            if (success)
            {
                if (number > 0)
                {
                    Console.WriteLine(NumberString(number));
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
