using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Simple
{
    public class Program
    {
        public static bool CheckSimpleNumber(int number)
        {
            bool result = true;
            for (int i = 2; i < Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Checking the number for simplicity");
            Console.Write("Enter a positive number = ");

            string value = Console.ReadLine();
            bool success = int.TryParse(value, out int number);

            if (success)
            {
                if (number > 0)
                {
                    bool result = CheckSimpleNumber(number);
                    Console.WriteLine();
                    Console.WriteLine($"Is {value} a simple number? - {result}");
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
