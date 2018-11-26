using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.ArrayProcessing
{
    //Task 1.7
    //Написать программу, которая генерирует случайным образом элементы массива(число элементов
    //в массиве и их тип определяются разработчиком), определяет для него максимальное и
    //минимальное значения, сортирует массив и выводит полученный результат на экран.
    //Примечание: LINQ запросы и готовые функции языка (Sort, Max и т.д.) использовать в данном
    //задании запрещается.
    public class Program
    {
        public static void GenerateArray(out int[] array)
        {
            const int arrayLength = 10;
            array = new int[arrayLength];
            int limit = 10;

            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-limit, limit);
            }
        }

        public static int GetArrayMaxValue(int[] array)
        {
            //we can also use the last item in the sorted array
            int max = 0;
            if (array.Length > 0)
            {
                max = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] > max) max = array[i];
                }
            }
            return max;
        }

        public static int GetArrayMinValue(int[] array)
        {
            //we can also use the first item in the sorted array
            int min = 0;
            if(array.Length > 0)
            {
                min = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] < min) min = array[i];
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
            Console.WriteLine("The application generate and sort array, show the sorted array " +
                Environment.NewLine + "and the max and the min elements of array.");

            GenerateArray(out int[] array);

            Console.Write(Environment.NewLine + "Generated array: ");
            ShowArray(array);

            Console.WriteLine(Environment.NewLine + "Max of array: " + GetArrayMaxValue(array));
            Console.WriteLine("Min of array: " + GetArrayMinValue(array));

            SortArray(ref array);
            Console.Write(Environment.NewLine + "Sorted array: ");
            ShowArray(array);
        }
    }
}
