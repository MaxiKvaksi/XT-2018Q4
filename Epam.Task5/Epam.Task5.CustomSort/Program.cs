using System;
using System.Collections.Generic;

namespace Epam.Task5.CustomSort
{
    public class Program
    {
        private static Random random = new Random();

        public static void Main(string[] args)
        {
            Console.WriteLine("The application demostrates a result of work of the custom sort function for array with undefined type.");
           
            IEnumerable<int> elements = GetRandomizedIntList(20);
            Console.WriteLine("Initial array:");
            ShowIEnumerable(elements);
            try
            {
                elements = Sorting.BubbleSort(elements, (a, b) => a > b);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("The application will be stop...");
                Environment.Exit(1);                
            }

            Console.WriteLine("Sorted array:");
            ShowIEnumerable(elements);
        }

        public static List<int> GetRandomizedIntList(int size)
        {
            List<int> array = new List<int>();
            int minLimit = -20;
            int maxLimit = 20;
            for (int i = 0; i < size; i++)
            {
                array.Add(random.Next(minLimit, maxLimit));
            }

            return array;
        }

        public static void ShowIEnumerable<T>(IEnumerable<T> elements)
        {
            Console.WriteLine(string.Join(", ", elements));
        }
    }
}
