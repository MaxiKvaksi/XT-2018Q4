/**
 * The application generate array and sort its, also the application show the max and min elements of array.
 * */
using System;

namespace Epam.Task2.ArrayProcessing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The application generate array and sort its, also the application show the max and min elements of array." 
                + Environment.NewLine + "Input an array size:");
            if (int.TryParse(Console.ReadLine(), out int arrayLength) && arrayLength > 0)
            {
                int[] numbers = new int[arrayLength];
                GenerateArray(ref numbers);
                Console.WriteLine(Environment.NewLine + "Generated array:");
                ShowArray(numbers);
                Console.WriteLine(Environment.NewLine + $"Min of array: {GetArrayMinValue(numbers)}");//also we can use the 0 item in sorted array by ASC
                Console.WriteLine(Environment.NewLine + $"Max of array: {GetArrayMaxValue(numbers)}");//also we can use the last item in sorted array by ASC
                SortArray(ref numbers);
                Console.WriteLine(Environment.NewLine + "Sorted array:");
                ShowArray(numbers);
            }
            else
            {
                Console.WriteLine("Incorrect input! Application will be stop.");
            }
        }

        public static void GenerateArray(ref int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-10, 10);
            }
        }

        public static void SortArray(ref int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if(array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        public static void ShowArray(int[] array)
        {
            foreach (int item in array)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }

        public static int GetArrayMaxValue(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max) max = array[i];
            }

            return max;
        }

        public static int GetArrayMinValue(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min) min = array[i];
            }

            return min;
        }
    }
}
