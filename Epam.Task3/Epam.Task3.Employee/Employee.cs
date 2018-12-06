using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Employee
{
    public class Employee : User.User
    {
        private int workExperience;
        private string position;
        
        public Employee(string lastName, string firstName, string middleName, DateTime dateOfBirth, int workExperience, string position) 
            : base(lastName, firstName, middleName, dateOfBirth)
        {
            this.WorkExperience = workExperience;
            this.Position = position ?? throw new ArgumentNullException(nameof(position));
        }

        public int WorkExperience
        {
            get => this.workExperience;
            set
            {
                if (value >= 0 && value <= this.Age)
                {
                    this.workExperience = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Work experience", "Invalid work experience");
                }
            }
        }

        public string Position
        {
            get => this.position;
            set
            {
                if ((value != null) && (value != string.Empty) && (value.Length != 0))
                {
                    this.CheckOnSymbols(value);
                    this.position = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Position", "Invalid position");
                }
            }
        }

        public override void Show()
        {
            Console.Write(typeof(Employee).Name);
            Console.Write(" ");
            base.Show();
            Console.WriteLine($"Work experience: {this.WorkExperience}");
            Console.WriteLine($"Position: {this.Position}");
        }
    }
}
