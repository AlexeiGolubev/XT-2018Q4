using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.FontAdjustment
{
    public class Program
    {
        [Flags]
        public enum TextStyle
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4
        }

        public static void Main(string[] args)
        {
            TextStyle currentStyle = TextStyle.None;
            Console.ForegroundColor = ConsoleColor.Green;

            while (true)
            {
                Console.WriteLine("The changing text style.");
                Console.WriteLine();
                Console.WriteLine("Enter a menu item or another character to exit.");
                Console.WriteLine($"Style parameters: {currentStyle}");
                Console.WriteLine("\t1.Bold");
                Console.WriteLine("\t2.Italic");
                Console.WriteLine("\t3.Underline");

                string value = Console.ReadLine();
                bool success = int.TryParse(value, out int number);

                if (success && number <= 3 && number > 0)
                {
                    if (number == 3)
                    {
                        number = 4;
                    }

                    currentStyle ^= (TextStyle)number;
                }
                else
                {
                    Console.WriteLine("Incorrect input or exit.");
                    break;
                }

                Console.Clear();
            }
        }
    }
}
