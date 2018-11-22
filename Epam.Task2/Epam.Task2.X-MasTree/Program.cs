/**
 * The application draw x-mas tree.
 */
using System;

namespace Epam.Task2.X_MasTree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The application draw x-mas tree." + Environment.NewLine + "Input a tree height:");
            if (int.TryParse(Console.ReadLine(), out int height) && height > 0)
            {
                ShowXMasTree(height);
            }
            else
            {
                Console.WriteLine("Incorrect input! Application will be stop.");
            }
        }

        public static void ShowXMasTree(int height)
        {
            for (int i = 0; i <= height; i++)
            {
                ShowIsoscelesStarsTriangle(i, height - i);
            }
        }

        public static void ShowIsoscelesStarsTriangle(int height, int indent)
        {
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < height - i + indent; k++)
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
