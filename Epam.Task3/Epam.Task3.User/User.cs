using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.User
{
    public class User
    {
        private string lastName;
        private string firstName;
        private string middleName;
        private DateTime dateOfBirth;

        public User()
        {
            this.LastName = "noLastName";
            this.FirstName = "noFirstName";
            this.MiddleName = "noMiddleName";
            this.DateOfBirth = DateTime.Now;
        }

        public User(string lastName, string firstName, string middleName, DateTime dateOfBirth)
        {
            this.LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            this.FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            this.MiddleName = middleName ?? throw new ArgumentNullException(nameof(middleName));
            this.DateOfBirth = dateOfBirth;
        }

        public string LastName
        {
            get => this.lastName;
            set
            {
                if ((value != null) && (value != string.Empty) && (value.Length != 0))
                {
                    this.CheckOnSymbols(value);
                    this.lastName = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Last name", "Invalid last name");
                }
            }
        }

        public string FirstName
        {
            get => this.firstName;
            set
            {
                if ((value != null) && (value != string.Empty) && (value.Length != 0))
                {
                    this.CheckOnSymbols(value);
                    this.firstName = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("First name", "Invalid first name");
                }
            }
        }

        public string MiddleName
        {
            get => this.middleName;
            set
            {
                if ((value != null) && (value != string.Empty) && (value.Length != 0))
                {
                    this.CheckOnSymbols(value);
                    this.middleName = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Middle name", "Invalid middle name");
                }
            }
        }

        public DateTime DateOfBirth
        {
            get => this.dateOfBirth;
            set
            {
                if ((DateTime.Now.Year - value.Year < 200) && (DateTime.Now.Year - value.Year >= 0))
                {
                    this.dateOfBirth = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Date of birth", "Invalid date of birth");
                }
            }
        }

        public int Age
        {
            get
            {
                DateTime date = DateTime.Now;
                if ((date.Month >= this.DateOfBirth.Month) && (date.Day >= this.DateOfBirth.Day))
                {
                    return DateTime.Now.Year - this.DateOfBirth.Year;
                }
                else
                {
                    return DateTime.Now.Year - this.DateOfBirth.Year - 1;
                }
            }
        }

        public virtual void Show()
        {
            Console.WriteLine(typeof(User).Name);
            Console.WriteLine($"Last name: {this.LastName}");
            Console.WriteLine($"First name: {this.FirstName}");
            Console.WriteLine($"Middle name: {this.MiddleName}");
            Console.WriteLine($"Date of birth: {this.DateOfBirth.ToShortDateString()}");
            Console.WriteLine($"Age: {this.Age}");
        }

        protected void CheckOnSymbols(string checkString)
        {
            char[] symbols = checkString.ToCharArray();
            foreach (char symbol in symbols)
            {
                if (!char.IsLetter(symbol))
                {
                    throw new ArgumentException("The name isn't word");
                }
            }
        }
    }
}
