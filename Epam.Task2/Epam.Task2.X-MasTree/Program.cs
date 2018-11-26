using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.X_MasTree
{
    //Task 1.4
    public class Program
    {
        public static void EnterNumber()
        {
            bool success = false;
            do
            {
                Console.Write("Enter the positive number: ");
                string value = Console.ReadLine();

                success = Int32.TryParse(value, out int number);
                if (success)
                {
                    if (number > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        for (int k = 0; k <= number; k++)
                        {
                            for (int i = 0; i < k; i++)
                            {
                                for (int j = i + 1; j < number; j++)
                                {
                                    Console.Write(" ");
                                }
                                for (int j = i * 2 + 1; j > 0; j--)
                                {
                                    Console.Write("*");
                                }
                                Console.WriteLine();
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (number == 0)
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
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("The image output");
            EnterNumber();
        }
    }
}
