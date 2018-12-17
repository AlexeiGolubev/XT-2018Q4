using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task5.CustomSort;

namespace Epam.Task5.CustomSortDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] array =
            {
                "Max",
                "Alex",
                "Sergey",
                "Alexey",
                "Alex",
                "Bob"
            };
            ConsolePrintArray(array, "Created array of strings");

            Sorting.QuickSort(array, CompareString);
            ConsolePrintArray(array, "Sorted array of strings by length");
        }

        public static int CompareString(string s1, string s2)
        {
            if (s1.Length < s2.Length)
            {
                return -1;
            }
            else if (s1.Length > s2.Length)
            {
                return 1;
            }
            else
            {
                int min = s1.Length < s2.Length
                ? s1.Length
                : s2.Length;

                for (int i = 0; i < min; i++)
                {
                    if (s1[i] < s2[i])
                    {
                        return -1;
                    }

                    if (s1[i] > s2[i])
                    {
                        return 1;
                    }
                }
            }

            return 0;
        }

        public static void ConsolePrintArray<T>(T[] array, string message)
        {
            Console.WriteLine(message);
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
    }
}
