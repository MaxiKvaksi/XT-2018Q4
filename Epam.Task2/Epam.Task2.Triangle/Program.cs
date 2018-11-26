using System;

namespace Epam.Task2.Triangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The application draw triangle." + Environment.NewLine + "Input a triangle height:");
            if (int.TryParse(Console.ReadLine(), out int height) && height > 0)
            {
                ShowStarsTriangle(height);
            }
            else
            {
                Console.WriteLine("Incorrect input! Application will be stop.");
            }
        }

        public static void ShowStarsTriangle(int height)
        {
            for (int i = 1; i <= height; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write('*');
                }

                Console.WriteLine();
            }
        }
    }
}
