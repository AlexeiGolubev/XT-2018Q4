using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Round
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Round round = new Round(startPoint: new Point(-10, 0), radius: 10);
                round.Show();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
