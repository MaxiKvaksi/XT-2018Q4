using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.IntOrNotToInt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The application demonstrates work of string extension 'IsInt'");
            string inputString = Console.ReadLine();
            Console.WriteLine($"Is integer: {inputString.IsInt()}");
        }
    }
}
