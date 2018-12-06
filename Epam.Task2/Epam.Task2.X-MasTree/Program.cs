using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.X_MasTree
{
    public class Program
    {
        public static void ShowX_masTree(int number)
        {
            const string As = "*";
            const string Space = " ";

            Console.ForegroundColor = ConsoleColor.Green;
            for (int k = 0; k <= number; k++)
            {
                for (int i = 0; i < k; i++)
                {
                    for (int j = i + 1; j < number; j++)
                    {
                        Console.Write(Space);
                    }

                    for (int j = (i * 2) + 1; j > 0; j--)
                    {
                        Console.Write(As);
                    }

                    Console.WriteLine();
                }
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void EnterNumber()
        {
            bool success = false;

            do
            {
                Console.Write("Enter the positive number: ");
                string value = Console.ReadLine();

                success = int.TryParse(value, out int number);
                if (success)
                {
                    if (number > 0)
                    {
                        ShowX_masTree(number);
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
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("The drawing of X-mas tree");
            EnterNumber();
        }
    }
}
