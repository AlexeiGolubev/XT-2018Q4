using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.FontAdjustment
{
    //Task 1.6
    //Для форматирования текста надписи можно использовать различные начертания: полужирное,
    //курсивное и подчёркнутое, а также их сочетания.Предложите способ хранения информации о
    //форматировании текста надписи и напишите программу, которая позволяет устанавливать и
    //изменять начертание.
    public class Program
    {
        [Flags]
        public enum TextStyle
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4
        }

        public static void Main(string[] args)
        {
            TextStyle currentStyle = TextStyle.None;
            Console.ForegroundColor = ConsoleColor.Green;
            while (true)
            {
                Console.WriteLine($"The changing text style.{ Environment.NewLine + Environment.NewLine}" +
                    $"Enter a menu item or another character to exit.{Environment.NewLine}" +
                    $"Style parameters: {currentStyle}{Environment.NewLine}\t1.Bold" +
                    $"{Environment.NewLine}\t2.Italic{Environment.NewLine}\t3.Underline");

                if (int.TryParse(Console.ReadLine(), out int n) && n <= 3 && n > 0)
                {
                    if (n == 3)
                    {
                        n = 4;
                    }
                    currentStyle ^= (TextStyle)n;
                    Console.WriteLine(currentStyle);
                }
                else
                {
                    Console.WriteLine("Incorrect input or exit.");
                    break;
                }
                Console.Clear();
            }
        }
    }
}
