using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.SumOfNumbers
{
    public class Program
    {
        public static int SumOfNumbers(int limiter)
        {
            int sum = 0;

            for (int i = 0; i < limiter; i += 3)
            {
                sum += i;
            }

            for (int i = 0; i < limiter; i += 5)
            {
                if (i % 3 != 0)
                {
                    sum += i;
                }
            }

            return sum;
        }

        public static void Main(string[] args)
        {
            int limiter = 1000;
            int sum = SumOfNumbers(limiter);
            Console.WriteLine($"The sum of all numbers less than {limiter.ToString()}, multiples of 3 or 5 is equal to {sum.ToString()}");
        }
    }
}
