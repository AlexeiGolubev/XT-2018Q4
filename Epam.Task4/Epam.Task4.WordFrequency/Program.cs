using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.WordFrequency
{
    public class Program
    {
        public static Dictionary<string, int> FindFrequencyOfOccurrence(string str)
        {
            var listOfWords = GetListOfWords(str);
            var frequencyOfOccurrence = new Dictionary<string, int>();

            foreach (var item in listOfWords)
            {
                if (!frequencyOfOccurrence.ContainsKey(item))
                {
                    frequencyOfOccurrence.Add(item, 1);
                }
                else
                {
                    frequencyOfOccurrence[item]++;
                }
            }

            return frequencyOfOccurrence;
        }

        public static List<string> GetListOfWords(string str)
        {
            str = str.ToLower();
            var temp = new StringBuilder();
            var listOfWords = new List<string>();

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsSeparator(str[i]) && char.IsPunctuation(str[i]))
                {
                    continue;
                }

                while (i < str.Length && !char.IsSeparator(str[i]) && !char.IsPunctuation(str[i]))
                {
                    temp.Append(str[i]);
                    i++;
                }

                if (temp.ToString() != string.Empty)
                {
                    listOfWords.Add(temp.ToString());
                }

                temp.Clear();
            }

            return listOfWords;
        }

        public static void PrintFrequencyOfOccurrence<T1, T2>(IDictionary<T1, T2> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine($"Word '{item.Key}' is found {item.Value}");
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("The text");
            string str = "Solar power generators differ greatly from other electric generators in that they have no moving parts. In this section, we focus on the energy conversion principles of solar batteries rather than the use of solar energy to drive a steam turbine. (Steam turbines may be powered indirectly by solar energy by evaporating water with mirrors focusing solar heat.)";
            Console.WriteLine(str);

            var result = FindFrequencyOfOccurrence(str);

            PrintFrequencyOfOccurrence(result);
        }
    }
}
