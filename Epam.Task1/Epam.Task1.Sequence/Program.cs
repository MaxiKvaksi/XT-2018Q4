/**
 * SEQUENCE
 * Application which demonstrate work of function outputting sequence of positive numbers
 */
using System;

namespace Epam.Task1.Sequence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Application which demonstrate work of function outputting sequence of positive numbers." +
                "\n\nInput the quantity of numbers:");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                ShowNumbers(n);
            }
            else
            {
                Console.WriteLine("Uncorrect input!");
            }
        }

        private static void ShowNumbers(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{i}, ");
            }

            Console.WriteLine(n);
        }
    }
}
