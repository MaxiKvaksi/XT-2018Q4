using System;
using System.Text;

namespace Epam.Task2.CharDoubler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The application duplicates symbols in first string from second string.");
            Console.WriteLine("Input first string:");
            string firstString = Console.ReadLine();
            Console.WriteLine("Input first string:");
            string secondString = Console.ReadLine();
            string resultString = DuplicateCharactersInSentence(firstString, secondString);
            Console.WriteLine("Result:");
            Console.WriteLine(resultString);
        }

        private static string DuplicateCharactersInSentence(string firstString, string secondString)
        {
            StringBuilder sbstr1 = new StringBuilder(firstString);
            StringBuilder sbstr2 = new StringBuilder(secondString);
            string currentSymbol;
            while (sbstr2.Length > 0)
            {
                currentSymbol = sbstr2[0].ToString();
                sbstr1.Replace(currentSymbol, currentSymbol + currentSymbol);
                sbstr2.Replace(currentSymbol, string.Empty);
            }

            return sbstr1.ToString();
        }
    }
}
