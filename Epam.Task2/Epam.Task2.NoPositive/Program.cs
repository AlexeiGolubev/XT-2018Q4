using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.NoPositive
{
    //Task 1.8
    //Написать программу, которая заменяет все положительные элементы в трёхмерном массиве на
    //нули.Число элементов в массиве и их тип определяются разработчиком.
    public class Program
    {
        public static void Generate3DArray(out int[,,] array3d)
        {
            Random random = new Random();
            const int size = 3;
            int limit = 10;
            array3d = new int[size, size, size];
            for (int i = 0; i < array3d.GetLength(0); i++)
            {
                for (int j = 0; j < array3d.GetLength(1); j++)
                {
                    for (int k = 0; k < array3d.GetLength(2); k++)
                    {
                        array3d[i, j, k] = random.Next(-limit, limit);
                    }
                }
            }
        }

        public static void ChangePositiveElements(ref int[,,] array3d)
        {
            for (int i = 0; i < array3d.GetLength(0); i++)
            {
                for (int j = 0; j < array3d.GetLength(1); j++)
                {
                    for (int k = 0; k < array3d.GetLength(2); k++)
                    {
                        if (array3d[i, j, k] > 0) array3d[i, j, k] = 0;
                    }
                }
            }
        }

        public static void Show3dArray(int[,,] array3d)
        {
            for (int i = 0; i < array3d.GetLength(0); i++)
            {
                Console.WriteLine($"[{i}]");
                for (int j = 0; j < array3d.GetLength(1); j++)
                {
                    for (int k = 0; k < array3d.GetLength(2); k++)
                    {
                        Console.Write(array3d[i, j, k] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("The change positive numbers to zeros in 3D array." +
                Environment.NewLine);

            Generate3DArray(out int[,,] array);
            Console.WriteLine("Generated array:");
            Show3dArray(array);

            Console.WriteLine("Processed array:");
            ChangePositiveElements(ref array);
            Show3dArray(array);
        }
    }
}
