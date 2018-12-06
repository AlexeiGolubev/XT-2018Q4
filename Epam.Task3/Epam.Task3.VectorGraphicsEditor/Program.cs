using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task3.Ring;
using Epam.Task3.Round;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Figure> figures = new List<Figure>();

            try
            {
                figures.Add(new Line(new Point(-10, 5), new Point(15, 3)));
                figures.Add(new RoundShape(new Point(5, 2), 3));
                figures.Add(new Rectangle(new Point(2, 9), 4, 5));
                figures.Add(new Round.Round(new Point(0, 10), 8));
                figures.Add(new Ring.Ring(new Point(7, -20), 2, 5));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            foreach (var figure in figures)
            {
                figure.Show();
                Console.WriteLine();
            }
        }
    }
}
