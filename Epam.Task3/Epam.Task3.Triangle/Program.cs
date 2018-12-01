using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Triangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The application demonstrates the class 'Triangle' using." + Environment.NewLine);
            Triangle triangle = new Triangle(a: 3, b: 4, c: 5);
            Console.WriteLine("1: " + triangle);
            triangle = new Triangle(1, 0.76, 1.33);
            Console.WriteLine("2: " + triangle);
        }
    }
}
