using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.ToIntOrNotToInt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a natural number:");
            string number = Console.ReadLine();
            Console.WriteLine(number.IsNaturalNumber());
        }
    }
}
