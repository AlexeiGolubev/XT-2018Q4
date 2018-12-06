using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.MyString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MyString firstMyString = new MyString(new char[] { 'a', 'b', 'c' });
            MyString secondMyString = new MyString('x', 'y', 'z');
            Console.WriteLine("First string: " + firstMyString);
            Console.WriteLine("Second string: " + secondMyString);
            Console.WriteLine("Operation '+' with first string and second string: " + firstMyString + secondMyString);
            Console.WriteLine("Function 'Concat' with first string and second string: " + firstMyString.Concat(secondMyString));
            secondMyString = firstMyString;
            Console.WriteLine("Second string: " + secondMyString);
            Console.WriteLine("Operation '==' with first string and second string: " + (firstMyString == secondMyString));
            Console.WriteLine("Function 'GetHashCode' with first string: " + firstMyString.GetHashCode());
            Console.WriteLine("Function 'ToStringBuilder' with first string: " + firstMyString.ToStringBuilder());
            Console.WriteLine("Function 'ToCharArray' with first string: " + firstMyString.ToCharArray());
            Console.WriteLine("Function 'IndexOf' with first string with 'b' character: " + firstMyString.IndexOf('b'));
        }
    }
}
