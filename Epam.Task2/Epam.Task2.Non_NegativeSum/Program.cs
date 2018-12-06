using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.Non_NegativeSum
{
    public class Program
    {
        public static void GenerateArray(out int[] array)
        {
            const int ArrayLength = 10;
            array = new int[ArrayLength];
            int limit = 10;

            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-limit, limit);
            }
        }

        public static void ShowArray(int[] array)
        {
            foreach (int item in array)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }

        public static int GetNonNegativeSum(int[] array)
        {
            int sum = 0;

            foreach (int item in array)
            {
                if (item > 0)
                {
                    sum += item;
                }
            }

            return sum;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("The determining the sum of non-negative elements in the array." +
                Environment.NewLine);

            GenerateArray(out int[] array);

            Console.Write(Environment.NewLine + "Generated array: ");
            ShowArray(array);

            Console.Write(Environment.NewLine + "The sum of non-negative elements in the array is " +
                GetNonNegativeSum(array) + Environment.NewLine);
        }
    }
}
