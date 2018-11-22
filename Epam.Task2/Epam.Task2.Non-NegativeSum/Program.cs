/**
 * The application show sum of non negative numbers in array.
 */
using System;

namespace Epam.Task2.Non_NegativeSum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The application show sum of non negative numbers in array." + Environment.NewLine + "Input an array length:");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                int[] array = GetArray(n);
                Console.WriteLine("Generated array:");
                ShowArray(array);
                SortArray(ref array);
                Console.WriteLine("Sum of non negative numbers in array:");
                Console.WriteLine(NonNegativeItemsSum(array));
            }
            else
            {
                Console.WriteLine("Incorrect input! Application will be stop.");
            }
        }

        public static void ShowArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }

        public static int NonNegativeItemsSum(int[] array)
        {
            int sum = 0;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] <= 0)
                {
                    break;

                }
                sum += array[i];
            }

            return sum;
        }

        public static int[] GetArray(int n)
        {
            int[] array = new int[n];
            Random random = new Random();
            int limit = 10;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-limit, limit);
            }

            return array;
        }

        public static void SortArray(ref int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
}
