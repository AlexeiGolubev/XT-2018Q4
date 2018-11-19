using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Simple
{
    class Program
    {
        public static bool Simple(int n)
        {
            bool res = true;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    res = false;
                    break;
                }
            }
            return res;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Is 37 simple number? " + Simple(37));
            Console.WriteLine("Is 35 simple number? " + Simple(35));
            Console.ReadKey();
        }
    }
}
