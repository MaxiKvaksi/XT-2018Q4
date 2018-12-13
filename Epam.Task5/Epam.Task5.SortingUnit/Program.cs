using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Epam.Task5.SortingUnit
{
    public class Program
    {
        private static Random random = new Random();
        private static bool sortingWaiting = true;
        private static int counter = 0;

        public static void Main(string[] args)
        {
            Console.WriteLine($"The application demonstrates a calculating in another thread.{Environment.NewLine}");
            SortingUnit.OnSort += () => sortingWaiting = false;
            
            IEnumerable<int> elements = CustomSort.Program.GetRandomizedIntList(75000);
            Console.WriteLine("The array was created. Press any button to start sorting...");
            Console.ReadKey();
            SortingUnit.SortingInOwnThread(elements, (a, b) => a > b);
            counter = 0;
            Console.WriteLine("Press any button to change the counter while the array is sorted...");
            while (sortingWaiting)
            {
                Console.ReadKey();
                Console.Write($"\rCounter: {counter}"); 
                counter++;
            }

            Console.WriteLine($"{Environment.NewLine}Sorting was end!");
        }
    }
}
