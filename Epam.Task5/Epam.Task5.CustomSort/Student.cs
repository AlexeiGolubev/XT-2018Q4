using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.CustomSort
{
    public class Student
    {
        private int age;
        private string name;

        public Student(string name, int age)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Age = age;
        }

        public string Name { get => this.name; set => this.name = value; }

        public int Age
        {
            get => this.age;
            set
            {
                if (value > 0)
                {
                    this.age = value;
                }
                else
                {
                    throw new ArgumentException("The student age must be greater than 0.");
                }
            }
        }

        public static int CompareByName(Student s1, Student s2)
        {
            if (ReferenceEquals(s1, s2))
            {
                return 0;
            }

            if (s1 is null)
            {
                return -1;
            }

            if (s2 is null)
            {
                return 1;
            }

            int min = s1.Name.Length < s2.Name.Length
                ? s1.Name.Length
                : s2.Name.Length;

            for (int i = 0; i < min; i++)
            {
                if (s1.Name[i] < s2.Name[i])
                {
                    return -1;
                }

                if (s1.Name[i] > s2.Name[i])
                {
                    return 1;
                }
            }

            if (s1.Name.Length < s2.Name.Length)
            {
                return -1;
            }
            else if (s1.Name.Length > s2.Name.Length)
            {
                return 1;
            }
            else if (s1.Age < s2.Age)
            {
                return -1;
            }
            else if (s1.Age > s2.Age)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static int CompareByAge(Student s1, Student s2)
        {
            if (ReferenceEquals(s1, s2))
            {
                return 0;
            }

            if (s1 is null)
            {
                return -1;
            }

            if (s2 is null)
            {
                return 1;
            }

            if (s1.Age < s2.Age)
            {
                return -1;
            }
            else if (s1.Age > s2.Age)
            {
                return 1;
            }
            else if (s1.Name.Length < s2.Name.Length)
            {
                return -1;
            }
            else if (s1.Name.Length > s2.Name.Length)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return $"Name {this.Name} age {this.Age}";
        }
    }
}
