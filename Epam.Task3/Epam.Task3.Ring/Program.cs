using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task3.Round;

namespace Epam.Task3.Ring
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Ring ring = new Ring(new Point(), 5, 10);
                ring.Show();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
