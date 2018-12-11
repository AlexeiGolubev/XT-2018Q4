using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.DynamicArray
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Class 'DynamicArray'");
            Console.WriteLine("Creating dynamic array:");
            DynamicArray<int> emptyDynamicArray = new DynamicArray<int>();

            try
            {
                DynamicArray<int> emptyDynamicArrayWithCapacity = new DynamicArray<int>(10);
                Console.WriteLine("Constructor with capacity parameter:");
                Console.WriteLine($"{emptyDynamicArrayWithCapacity}{Environment.NewLine}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                Environment.Exit(1);
            }

            try
            {
                DynamicArray<int> dynamicArray = new DynamicArray<int>(new int[] { 1, 2, 3 });
                Console.WriteLine("Default constructor:");
                Console.WriteLine($"{emptyDynamicArray}{Environment.NewLine}");

                Console.WriteLine("Constructor with collection parameter:");
                Console.WriteLine($"{dynamicArray}{Environment.NewLine}");

                Console.WriteLine("Add method(adding '30'):");
                dynamicArray.Add(30);
                Console.WriteLine($"{dynamicArray}{Environment.NewLine}");

                Console.WriteLine("AddRange method(adding { 3, 6, 8, 4, 5, 5, 1, 4, 8, 5, 3, 2, 7 }):");
                int[] ar = new int[] { 3, 6, 8, 4, 5, 5, 1, 4, 8, 5, 3, 2, 7 };
                dynamicArray.AddRange(ar);
                Console.WriteLine($"{dynamicArray}{Environment.NewLine}");

                Console.WriteLine("Change array to:");
                dynamicArray = new DynamicArray<int>(new int[] { 1, 2, 3, 4, 5 });
                Console.WriteLine($"{dynamicArray}{Environment.NewLine}");

                Console.WriteLine("Remove method(removing 3rd element):");
                dynamicArray.Remove(3);
                Console.WriteLine($"{dynamicArray}{Environment.NewLine}");

                Console.WriteLine("Insert method(inserting to 3rd position):");
                dynamicArray.Insert(3, 4);
                Console.WriteLine($"{dynamicArray}{Environment.NewLine}");

                Console.WriteLine("Access to array element by index (index:4)");
                Console.WriteLine($"4th element is: {dynamicArray[4]}{Environment.NewLine}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                Environment.Exit(1);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                Environment.Exit(1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Environment.Exit(1);
            }
        }
    }
}
