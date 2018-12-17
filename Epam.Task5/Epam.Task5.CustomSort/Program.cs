using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.CustomSort
{
    public class Program
    {
        public static void ConsolePrintArray<T>(T[] array, string message)
        {
            Console.WriteLine(message);
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            try
            {
                Student[] students =
                {
                    new Student("Bob", 30),
                    new Student("Alex", 22),
                    new Student("Alexey", 22),
                    new Student("Alex", 22),
                    new Student("Max", 18),
                    new Student("Sergey", 20)
                };
                ConsolePrintArray(students, "Created array of students");

                Sorting.QuickSort(students, Student.CompareByName);
                ConsolePrintArray(students, "Sorted array of students by name");

                Sorting.QuickSort(students, Student.CompareByAge);
                ConsolePrintArray(students, "Sorted array of students by age");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
