using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task8.EmailFinder
{
    public class Program
    {
        private const string EMAIL_REGEX_PATTERN = @"\b[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}\b";

        public static void Main(string[] args)
        {
            Console.WriteLine("The application demonstrates working of regular expression for finding emails in string");
            Console.WriteLine("Input string:");
            string inputString = Console.ReadLine();
            string[] resultStrings = FindEmails(inputString);
            Console.WriteLine("Founded emails: ");
            foreach (var item in resultStrings)
            {
                Console.WriteLine(item);
            }
        }

        public static string[] FindEmails(string inputString)
        {
            return Regex.Matches(inputString, EMAIL_REGEX_PATTERN).Cast<Match>().Select(m => m.Value).ToArray();
        }
    }
}
