using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task8.NumberValidator
{
    public enum NumberType
    {
        NoNumber,
        Simple,
        Scientific,
    }

    public class Program
    {
        private const string SCIENTIFIC_REAL_NUMBER_REGEX_PATTERN = @"^[-]{0,1}\d+\.\d+(e|E|x)[-]{0,1}\d+$";
        private const string SIMPLE_REAL_NUMBER_REGEX_PATTERN = @"^[-]{0,1}\d+()|(.\d+)$";

        public static void Main(string[] args)
        {
            Console.WriteLine("The application demonstrates working of regular expression for resolving number type");
            Console.WriteLine("Input string:");
            string inputString = Console.ReadLine();
            NumberType numberType = ResolveNumberType(inputString);
            Console.WriteLine($"Number type is {numberType}");
        }

        public static NumberType ResolveNumberType(string inputString)
        {
            if (Regex.IsMatch(inputString, SCIENTIFIC_REAL_NUMBER_REGEX_PATTERN))
            {
                return NumberType.Scientific;
            }
            else if (Regex.IsMatch(inputString, SIMPLE_REAL_NUMBER_REGEX_PATTERN))
            {
                return NumberType.Simple;
            }
            else
            {
                return NumberType.NoNumber;
            }
        }
    }
}
