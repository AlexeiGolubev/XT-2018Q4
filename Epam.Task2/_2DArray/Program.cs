using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DArray
{
    public class Program
    {
        public static void Generate2DArray(out int[,] array2d)
        {
            Random random = new Random();
            const int ArrayLength = 3;
            int limit = 10;
            array2d = new int[ArrayLength, ArrayLength];

            for (int i = 0; i < array2d.GetLength(0); i++)
            {
                for (int j = 0; j < array2d.GetLength(1); j++)
                {
                    array2d[i, j] = random.Next(-limit, limit);
                }
            }
        }

        public static int EvenPositionItemsSum(int[,] array)
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = i % 2; j < array.GetLength(1); j += 2)
                {
                    sum += array[i, j];
                }
            }

            return sum;
        }

        public static void ShowArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    Console.Write(array[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("The determining the sum of array elements in even positions." +
                Environment.NewLine);
            Generate2DArray(out int[,] array);

            Console.WriteLine(Environment.NewLine + "Generated array: ");
            ShowArray(array);

            Console.Write(Environment.NewLine + "The sum of array elements in even positions is " +
                EvenPositionItemsSum(array) + Environment.NewLine);
        }
    }
}
