using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.SumOfNumbers
{
    //Task 1.5
    //Если выписать все натуральные числа меньше 10, кратные 3 или 5, то получим 3, 5, 6 и 9.Сумма
    //этих чисел будет равна 23.Напишите программу, которая выводит на экран сумму всех чисел
    //меньше 1000, кратных 3 или 5.
    public class Program
    {
        public static int SumOfNumbers()
        {
            

            int sum = 0;
            int limiter = 20;
            for (int i = 0; i < limiter; i += 3)
            {
                sum += i;
            }
            for (int i = 0; i < limiter; i += 5)
            {
                if(i % 3 != 0)
                {
                    sum += i;
                }
            }
            return sum;
        }

        public static void Main(string[] args)
        {
            int sum = SumOfNumbers();
            Console.WriteLine("The sum of all numbers less than 1000, multiples of 3 or 5 is equal to " + sum);
        }
    }
}
