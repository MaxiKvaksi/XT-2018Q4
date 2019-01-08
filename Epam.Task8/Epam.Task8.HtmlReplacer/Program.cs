using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task8.HtmlReplacer
{
    public class Program
    {
        private const string HTML_TAG_REGEX_PATTERN = "(<[\\w\\s\"=]+>)|(</[\\w\\s\"=]+>)";
        private const string REPLACE_STRING = "_";

        public static void Main(string[] args)
        {
            Console.WriteLine("The application demonstrates working of regular expression for html tags replacing");
            Console.WriteLine("Input string:");
            string inputString = Console.ReadLine();
            string resultString = ReplaceHtmlTags(inputString);
            Console.WriteLine($"Result string: {resultString}");
        }

        public static string ReplaceHtmlTags(string stringWithTags)
        {
            return Regex.Replace(stringWithTags, HTML_TAG_REGEX_PATTERN, REPLACE_STRING);
        }
    }
}
