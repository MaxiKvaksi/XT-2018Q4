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
            Console.WriteLine("Application which demonstrate work of function showing donut(square).");
            Console.WriteLine("\nInput donut(square) size:");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine($"Your donut({n}x{n}):");
                ShowSquare(n);
            }
            else
            {
                Console.WriteLine("Uncorrect input!");
            }
        }

        public static void ShowSquare(int size)
        {
            int halfSize = size % 2 == 0 ? size / 2 - 1 : size / 2;

            for (int i = 0; i < halfSize; i++)
            {
                ShowStars(size);
                Console.WriteLine();
            }

            ShowStars(halfSize);
            Console.Write(size % 2 != 0 
                ? " " 
                : "  ");
            ShowStars(halfSize);
            Console.WriteLine();
            for (int i = 0; i < halfSize; i++)
            {
                ShowStars(size);
                Console.WriteLine();
            }

        }

        public static void ShowStars(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write('*');
            }
        }
    }
}
