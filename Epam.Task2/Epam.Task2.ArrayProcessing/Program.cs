using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.ArrayProcessing
{
    public class Program
    {
        public static Random random = new Random();

        public static void GenerateArray(ref int[] array)
        {
            int limit = 10;
            
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-limit, limit);
            }
        }

        public static int GetArrayMaxValue(int[] array)
        {
            int max = 0;
            if (array.Length > 0)
            {
                max = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] > max)
                    {
                        max = array[i];
                    }
                }
            }

            return max;
        }

        public static int GetArrayMinValue(int[] array)
        {
            int min = 0;
            if (array.Length > 0)
            {
                min = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] < min)
                    {
                        min = array[i];
                    }
                }
            }

            return min;
        }

        public static void SortArray(ref int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
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

        public static void Main(string[] args)
        {
            Console.WriteLine("The application generate and sort array, show the sorted array ");
            Console.WriteLine("and the max and the min elements of array.");

            const int ArrayLength = 10;
            int[] array = new int[ArrayLength];

            GenerateArray(ref array);

            Console.Write(Environment.NewLine + "Generated array: ");
            ShowArray(array);

            Console.WriteLine();
            Console.WriteLine("Max of array: " + GetArrayMaxValue(array));
            Console.WriteLine("Min of array: " + GetArrayMinValue(array));

            SortArray(ref array);
            Console.Write(Environment.NewLine + "Sorted array: ");
            ShowArray(array);
        }
    }
}
