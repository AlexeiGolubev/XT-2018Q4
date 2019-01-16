using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task8.TimeCounter
{
    public class Program
    {
        private const string TimePattern = @"\b(0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]";

        public static void Main(string[] args)
        {
            Console.WriteLine("The application determines how many times the time is found in the string.");
            Console.WriteLine();
            Console.WriteLine("Enter string: ");
            string input = Console.ReadLine();
            int counter = Regex.Matches(input, TimePattern).Count;
            Console.WriteLine($"There is {counter} time records in the text.");
        }
    }
}
