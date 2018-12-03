using System;
using System.Text;

namespace Epam.Task2._2DArray
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The application show sum of elements on even positions in array." + Environment.NewLine + "Input an array size(n):");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                int[,] array = GetArray(n);
                Console.WriteLine("Generated array:");
                ShowArray(array);
                Console.WriteLine("Sum of elements on even positions:");
                Console.WriteLine(EvenPositionItemsSum(array));
            }
            else
            {
                Console.WriteLine("Incorrect input! Application will be stop.");
            }
        }

        public static int EvenPositionItemsSum(int[,] array)
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = i % 2; j < array.GetLength(1); j += 2)
                {
                    sum += array[i, j];
                }   
            }

            return sum;
        }

        public static void ShowArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    Console.Write(string.Format(" {0}", array[i, j]));
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public static int[,] GetArray(int n)
        {
            int[,] array = new int[n, n];
            Random random = new Random();
            int limit = 10;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    array[i, j] = random.Next(-limit, limit);
                }
            }

            return array;
        }
    }
}
