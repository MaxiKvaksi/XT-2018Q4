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
            Console.WriteLine("The application demonstrates the class 'Round' using." + Environment.NewLine);
            Round round = new Round(x: 0, y: 0, radius: 1);
            Console.WriteLine("1: " + round);
            round = new Round(23, 0.76, 1.33);
            Console.WriteLine("2: " + round);
        }
    }
}
