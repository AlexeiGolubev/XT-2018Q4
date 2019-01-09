using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Entities
{
    public class User
    {
        private DateTime dateOfBirth;

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth
        {
            get => this.dateOfBirth;
            set
            {
                if ((DateTime.Now.Year - value.Year < 150) && (DateTime.Now.Year - value.Year >= 0))
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

        public override string ToString()
        {
            return $"{this.Id}: Name: {this.Name} Date of birth: {this.DateOfBirth.ToShortDateString()} Age: {this.Age}";
        }
    }
}
