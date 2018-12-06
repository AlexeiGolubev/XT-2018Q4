using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.User
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                User u = new User();
                User user = new User("Ivanov", "Ivan", "Ivanovich", new DateTime(2000, 12, 31));
                u.Show();
                Console.WriteLine();
                user.Show();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }
    }
}
