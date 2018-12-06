using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Triangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Triangle triangle = new Triangle(a: 3, b: 4, c: 5);

                Console.WriteLine(triangle);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
