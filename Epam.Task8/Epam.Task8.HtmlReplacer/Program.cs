using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task8.HtmlReplacer
{
    public class Program
    {
        private const string HtmlTagPattern = @"(<!--.*?-->)|(<[A-Za-z\!/]+[A-Za-z0-9\s\./=\-""]*>)";
        private const string Replacer = "_";

        public static void Main(string[] args)
        {
            Console.WriteLine("The application replaces all HTML tags found in the string with an underscore.");
            Console.WriteLine();
            string testString = @"<!DOCTYPE html><b>Это</b> текст <i>с</i> <font color=""red"">HTML</font> кодами<audio controls=""controls""> <source src=""song.mp3"" type=""audio / mp3""> Ваш браузер не поддерживает тег audio </audio> <!--Это комментарий. комментарии не отображаются в окне браузера--> <!--горизонтальная линия-->лалалал-->лалалала-->";
            Show(testString);
            Console.WriteLine("Input string:");
            Show(Console.ReadLine());
        }

        public static string ReplaceHtmlTags(string str)
        {
            return Regex.Replace(str, HtmlTagPattern, Replacer);
        }

        public static void Show(string str)
        {
            string resultString = ReplaceHtmlTags(str);
            Console.WriteLine($"Original string: {Environment.NewLine}{str}");
            Console.WriteLine();
            Console.WriteLine($"Result string: {Environment.NewLine}{resultString}");
            Console.WriteLine();
        }
    }
}
