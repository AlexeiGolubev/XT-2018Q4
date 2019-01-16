using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task8.DateExistence
{
    public class Program
    {
        private const string DatePattern = @"(((0[1-9]|[12][0-9]|3[01])\-(0[13578]|1[02])\-([0-9]{4}))|((0[1-9]|1[0-9]|2[0-9])\-02\-[0-9]{4}) )|((0[1-9]|[12][0-9]|30)\-(0[469]|11)\-[0-9]{4})";

        public static void Main(string[] args)
        {
            Console.WriteLine("The application determines existiting dd-mm-yyyy date in the string.");
            Console.WriteLine();
            Console.WriteLine("Input string:");
            string inputString = Console.ReadLine();
            bool dateContains = Regex.IsMatch(inputString, DatePattern);
            Console.WriteLine($"The input string '{inputString}' is {(dateContains ? "" : "not ")}contains date.");
        }
    }
}
