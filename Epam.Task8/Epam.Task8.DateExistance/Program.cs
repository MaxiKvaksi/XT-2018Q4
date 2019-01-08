using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task8.DateExistance
{
    public class Program
    {
        private const string DATE_REGEX_PATTERN = @"\d{2}-\d{2}-\d{4}";

        public static void Main(string[] args)
        {
            Console.WriteLine("The application demonstrates working of regular expression for date searching in string");
            Console.WriteLine("Input string:");
            string inputString = Console.ReadLine();
            bool dateContains = DateContains(inputString);
            Console.WriteLine($"Input string '{inputString}' {(dateContains ? "" : "not")} contains date.");
        }

        public static bool DateContains(string str)
        {
            return Regex.IsMatch(str, DATE_REGEX_PATTERN);
        }
    }
}
