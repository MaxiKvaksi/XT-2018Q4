using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task8.TimeCounter
{
    public class Program
    {
        private const string TIME_REGEX_PATTERN = @"\d{1,2}:\d{1,2}";

        public static void Main(string[] args)
        {
            Console.WriteLine("The application demonstrates working of regular expression for count time entries in string");
            Console.WriteLine("Input string:");
            string inputString = Console.ReadLine();
            int countOfTimeEntries = CountTimeEntries(inputString);
            Console.WriteLine($"Count of time entries: {countOfTimeEntries}");
        }

        public static int CountTimeEntries(string inputString)
        {
            string[] matches = Regex.Matches(inputString, TIME_REGEX_PATTERN).Cast<Match>().Select(m => m.Value).ToArray();
            int counter = 0;
            DateTime result;
            foreach (var item in matches)
            {
                if (DateTime.TryParse(item, out result))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
