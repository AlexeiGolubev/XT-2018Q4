using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.MyString
{
    public sealed class MyString
    {
        private char[] characters;
        
        public MyString(params char[] characters)
        {
            this.characters = characters ?? throw new ArgumentNullException(nameof(characters));
        }

        public int Length => this.characters.Length;

        public char this[int index]
        {
            get
            {
                return this.characters[index];
            }

            set
            {
                this.characters[index] = value;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is MyString @string &&
                   EqualityComparer<char[]>.Default.Equals(this.characters, @string.characters);
        }

        public override int GetHashCode()
        {
            return 646361025 + EqualityComparer<char[]>.Default.GetHashCode(this.characters);
        }

        public override string ToString()
        {
            return new string(this.characters);
        }

        public static bool operator ==(MyString firstMyString, MyString secondMyString)
        {
            return firstMyString.Equals(secondMyString);
        }

        public static bool operator !=(MyString firstMyString, MyString secondMyString)
        {
            return !firstMyString.Equals(secondMyString);
        }

        public static MyString operator +(MyString firstMyString, MyString secondMyString)
        {
            char[] characters = new char[firstMyString.Length + secondMyString.Length];
            for (int i = 0; i < firstMyString.characters.Length; i++)
            {
                characters[i] = firstMyString[i];
            }

            for (int i = firstMyString.Length, j = 0; j < secondMyString.Length; i++, j++)
            {
                characters[i] = secondMyString[j];
            }

            return new MyString(characters);
        }

        public MyString Concat(MyString myString)
        {
            char[] characters = new char[this.Length + myString.Length];
            for (int i = 0; i < this.characters.Length; i++)
            {
                characters[i] = this[i];
            }

            for (int i = this.Length, j = 0; j < myString.Length; i++, j++)
            {
                characters[i] = myString[j];
            }

            return new MyString(characters: characters);
        }

        public StringBuilder ToStringBuilder()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.characters);
            return sb;
        }

        public char[] ToCharArray()
        {
            return this.characters;
        }

        public int IndexOf(char character)
        {
            int index = -1;
            for (int i = 0; i < this.characters.Length; i++)
            {
                if (character.Equals(this.characters[i]))
                {
                    return i;
                }
            }

            return index;
        }
    }
}
