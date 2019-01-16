using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task8.HtmlReplacer
{
    public class Program
    {
        //private const string HtmlTagPattern = @"<[A-Za-z\!/]+[A-Za-z0-9=-\.\s/" + "\"]*>";
        private const string HtmlTagPattern = "<[A-Za-z/]+[A-Za-z0-9\"/ ]*>";
        private const string Replacer = "_";

        public static void Main(string[] args)
        {
            Console.WriteLine("The application replaces all HTML tags found in the string with an underscore.");
            Console.WriteLine("Input string:");
            string inputString = Console.ReadLine();
            string resultString = Regex.Replace(inputString, HtmlTagPattern, Replacer);
            Console.WriteLine($"Result string: {Environment.NewLine}{resultString}");
        }
    }
}
