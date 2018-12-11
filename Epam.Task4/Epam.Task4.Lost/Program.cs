using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.Lost
{
    public class Program
    {
        public static int EnterNumber()
        {
            bool success = false;

            do
            {
                Console.Write("Enter the positive number: ");
                string value = Console.ReadLine();
                success = int.TryParse(value, out int number);

                if (success)
                {
                    if (number > 0)
                    {
                        return number;
                    }
                    else
                    {
                        Console.WriteLine($"You entered an unpositive number {value}.");
                        success = false;
                    }
                }
                else
                {
                    Console.WriteLine($"Unable to parse '{value}'.");
                }
            }
            while (!success);

            return 0;
        }

        public static LinkedList<int> GenerateList(int size)
        {
            var array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }

            var list = new LinkedList<int>(array);

            return list;
        }

        public static void ShowList<T>(LinkedList<T> list)
        {
            Console.WriteLine();
            Console.WriteLine("The generated circle");

            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }

        public static void FindLostItem<T>(LinkedList<T> list)
        {
            var firstItem = list.First;

            while (list.Count > 1)
            {
                list.Remove(firstItem.Next ?? list.First);
                firstItem = firstItem.Next ?? list.First;
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("The find the last element in the circle, removing every second until one is left");

            var sizeArray = EnterNumber();
            var list = GenerateList(sizeArray);

            ShowList(list);
            FindLostItem(list);

            Console.WriteLine();
            Console.WriteLine($"The lost item in circle is {list.First.Value}");
        }
    }
}