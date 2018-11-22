/**
 * The application draw isosceles triangle.
 */
using System;

namespace Epam.Task2.AnotherTriangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The application draw isosceles triangle." + Environment.NewLine + "Input a triangle height:");
            if (int.TryParse(Console.ReadLine(), out int height) && height > 0)
            {
                ShowIsoscelesStarsTriangle(height);
            }
            else
            {
                Console.WriteLine("Incorrect input! Application will be stop.");
            }
        }

        public static void ShowIsoscelesStarsTriangle(int height)
        {
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < height - i; k++)
                {
                    Console.Write(' ');
                }

                for (int j = 0; j <= i * 2; j++)
                {
                    Console.Write('*');
                }

                Console.WriteLine();
            }
        }
    }
}
