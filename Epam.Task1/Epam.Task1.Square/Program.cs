/**
 * Square
 * Application which demonstrate work of function showing donut 
 */
using System;

namespace Epam.Task1.Square
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Application which demonstrate work of function showing donut. \nFor example:7x7");
            ShowSquare(7);
        }

        public static void ShowSquare(int size)
        {
            int halfSize = size % 2 == 0 ? size / 2 - 1 : size / 2;

            for (int i = 0; i < halfSize; i++)
            {
                Console.WriteLine(GetStars(size));
            }
            string temp = size % 2 != 0 ? " " : "  ";
            Console.WriteLine(GetStars(halfSize) + temp + GetStars(halfSize));
            for (int i = 0; i < halfSize; i++)
            {
                Console.WriteLine(GetStars(size));
            }
        }

        public static string GetStars(int n)
        {
            return new string('*', n);
        }
    }
}
