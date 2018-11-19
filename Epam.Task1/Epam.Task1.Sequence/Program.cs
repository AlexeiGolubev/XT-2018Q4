using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Sequence
{
    class Program
    {
        public static string NumberString(int n)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                if(i == n)
                    str.Append(i);
                else
                    str.Append(i + ", ");
            }
            return str.ToString();
        }
        static void Main(string[] args)
        {
            Console.WriteLine(NumberString(50));
            Console.ReadKey();
        }
    }
}
