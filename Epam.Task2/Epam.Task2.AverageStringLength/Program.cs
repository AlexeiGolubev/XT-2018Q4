﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.AverageStringLength
{
    public class Program
    {
        public static float GetAverageStringLength(string str)
        {
            int sumWordLength = 0;
            int wordsCounter = 0;
            bool isWord = false;

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsSeparator(str[i]))
                {
                    if (!isWord)
                    {
                        continue;
                    }

                    isWord = false;
                    continue;
                }

                if (!isWord)
                {
                    wordsCounter++;
                    isWord = true;
                }

                sumWordLength++;
            }

            return (float)sumWordLength / wordsCounter;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("The determining the average words length in sentence." +
                Environment.NewLine);
            string inputString = string.Empty;

            do
            {
                Console.Write("Enter the string: ");
                inputString = Console.ReadLine();
                if (inputString.Length != 0)
                {
                    Console.WriteLine("Average words length: " + GetAverageStringLength(inputString));
                }
                else
                {
                    Console.WriteLine("You entered an empty string");
                }
            }
            while (inputString.Length == 0);
        }
    }
}
