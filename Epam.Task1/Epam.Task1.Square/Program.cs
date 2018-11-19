using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Square
{
    class Program
    {
        public static void Stars(int n)
        {
            if (n % 2 == 1)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        if (i != (n / 2 + 1) || j != (n / 2 + 1))
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
        static void Main(string[] args)
        {
            Stars(7);
            Console.ReadKey();
        }
    }
}
