using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task8.NumberValidator
{
    public class Program
    {
        private const string ScientificNumberPattern = @"(^[+-]?[0-9]+(?:\.[0-9]+)*(?:E|e)[+-]?[0-9]+$)";
        private const string NormalNumberPattern = @"(^[+-]?[0-9]+(?:\.[0-9]+)?$)";

        public static void Main(string[] args)
        {
            Console.WriteLine("The application checks a string for its text format real number and displays the format in which this number is written.");
            Console.WriteLine();
            Console.WriteLine("Enter number: ");
            string input = Console.ReadLine();

            if (Regex.IsMatch(input, NormalNumberPattern))
            {
                Console.WriteLine($"{input} is a normal notation.");
            }
            else if (Regex.IsMatch(input, ScientificNumberPattern))
            {
                Console.WriteLine($"{input} is a scientific natation.");
            }
            else
            {
                Console.WriteLine($"{input} is not a number.");
            }
        }
    }
}
