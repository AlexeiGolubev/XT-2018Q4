using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task8.EmailFinder
{
    public class Program
    {
        private const string EmailPattern = @"[A-Za-z0-9][A-Za-z0-9_\-\.]*[A-Za-z0-9][@][A-Za-z0-9][A-Za-z0-9_\-\.]*[A-Za-z0-9][\.]+[A-Za-z]{2,6}";

        public static void Main(string[] args)
        {
            Console.WriteLine("The application finds all emails in the string.");
            Console.WriteLine("Input string");
            string input = Console.ReadLine();
            Regex emailRegex = new Regex(EmailPattern);
            Console.WriteLine();

            if (emailRegex.IsMatch(input))
            {
                Console.WriteLine("The following email addresses were found in the text:");
                foreach (var address in emailRegex.Matches(input))
                {
                    Console.WriteLine(address);
                }
            }
            else
            {
                Console.WriteLine("There is no the matching email address in the string.");
            }
        }
    }
}
