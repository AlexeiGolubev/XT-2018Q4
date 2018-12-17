using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task5.CustomSort;

namespace Epam.Task5.SortingUnit
{
    public class Program
    {
        private static SortingUnit<Student> sortingUnit = new SortingUnit<Student>();

        public static void Main(string[] args)
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

            Student[] studentsCopy = new Student[students.Length];
            Array.Copy(students, studentsCopy, students.Length);

            sortingUnit.EndOfSorting += PrintSortingEvent;

            sortingUnit.RunSortInNewThread(students, Student.CompareByName, "Thread CompareByName");
            sortingUnit.RunSortInNewThread(studentsCopy, Student.CompareByAge, "Thread CompareByAge");
            sortingUnit.SortingUnitThread.Join();

            Console.WriteLine();
            ConsolePrintArray(students, "Sorted array of students by name");
            ConsolePrintArray(studentsCopy, "Sorted array of students by age");
        }

        public static void PrintSortingEvent(string message)
        {
            Console.WriteLine($"{message} is finished");
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
