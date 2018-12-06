using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Employee
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Employee employee = new Employee("Ivanov", "Ivan", "Ivanovich", new DateTime(2000, 12, 31), 1, "Student");

                employee.Show();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }
    }
}
