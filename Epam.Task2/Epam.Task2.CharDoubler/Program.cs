using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.CharDoubler
{
    public class Program
    {
        public static string DoubleCharactersInSentence(string firstString, string secondString)
        {
            StringBuilder sbstr1 = new StringBuilder(firstString);
            StringBuilder sbstr2 = new StringBuilder(secondString);
            string currentSymbol = string.Empty;

            while (sbstr2.Length > 0)
            {
                currentSymbol = sbstr2[0].ToString();
                sbstr1.Replace(currentSymbol, currentSymbol + currentSymbol);
                sbstr2.Replace(currentSymbol, string.Empty);
            }

            return sbstr1.ToString();
        }
        
        public static void Main(string[] args)
        {
            Console.WriteLine("The enter double characters in first string from second string.");

            string firstString = string.Empty;
            string secondString = string.Empty;

            do
            {
                Console.WriteLine("Enter the first string:");
                firstString = Console.ReadLine();
                if (firstString.Length == 0)
                {
                    Console.WriteLine("You entered an empty string");
                }
            }
            while (firstString.Length == 0);
            
            do
            {
                Console.WriteLine("Enter the second string:");
                secondString = Console.ReadLine();
                if (secondString.Length == 0)
                {
                    Console.WriteLine("You entered an empty string");
                }
            }
            while (secondString.Length == 0);

            string resultString = DoubleCharactersInSentence(firstString, secondString);
            Console.WriteLine("Result: " + Environment.NewLine + resultString);
        }
    }
}
