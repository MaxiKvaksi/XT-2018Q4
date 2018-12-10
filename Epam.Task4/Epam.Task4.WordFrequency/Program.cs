using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.WordFrequency
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The application demonstates the couner of words frequncy in string.");
            Dictionary<string, int> wordsFrequency = new Dictionary<string, int>();
            Console.WriteLine("Input a string:");
            string[] inputWords = Console.ReadLine().Split(' ', '.');
            foreach (var word in inputWords)
            {
                if (!wordsFrequency.ContainsKey(word.ToLower()))
                {
                    wordsFrequency.Add(word.ToLower(), 1);
                }
                else
                {
                    wordsFrequency[word.ToLower()]++;
                }
            }

            Console.WriteLine("Result: ");
            foreach (var key in wordsFrequency.Keys)
            {
                Console.WriteLine($"{key}: {wordsFrequency[key]}");
            }
        }
    }
}
