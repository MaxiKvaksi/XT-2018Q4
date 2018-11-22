/**
 * The application that displays the sum of all numbers less than 1000, multiples of 3 or 5.
 */
using System;

namespace Epam.Task2.SumOfNumbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The application that displays the sum of all numbers less than 1000, multiples of 3 or 5." 
                + Environment.NewLine);
            int sumOfNumbers = 0;
            for (int i = 3; i < 1000; i += 3)
            {
                sumOfNumbers += i;
            }
            int sumOfFives = 0;
            for (int i = 5; i < 1000; i += 5)
            {
                sumOfFives += i % 3 != 0 ? i : 0;
            }
            sumOfNumbers += sumOfFives;
            Console.WriteLine($"Result of app work: {sumOfNumbers}");

        }
    }
}
