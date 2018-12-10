using System;

namespace Epam.Task4.DynamicArray
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The application demonstrates the 'DynamicArray' class.");
            Console.WriteLine("Creating dynamic array:");
            DynamicArray<int> emptyDynamicArray = new DynamicArray<int>();

            try
            {
                DynamicArray<int> emptydynamicArrayWithUndefCapacity = new DynamicArray<int>(10);
                Console.WriteLine("Constructor with capacity parameter:");
                Console.WriteLine($"{emptydynamicArrayWithUndefCapacity}{Environment.NewLine}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                Environment.Exit(1);
            }

            try
            {
                DynamicArray<int> dynamicArray = new DynamicArray<int>(new int[] { 1, 2, 3, 4, 5 });
                Console.WriteLine("Default constructor:");
                Console.WriteLine($"{emptyDynamicArray}{Environment.NewLine}");

                Console.WriteLine("Constructor with collection parameter:");
                Console.WriteLine($"{dynamicArray}{Environment.NewLine}");

                Console.WriteLine("Add method(adding '2'):");
                dynamicArray.Add(2);
                Console.WriteLine($"{dynamicArray}{Environment.NewLine}");

                Console.WriteLine("AddRange method(adding { 55, 34, 22, 55, 34, 22, 55, 34, 22, 55, 34, 22 }):");
                int[] ar = new int[] { 55, 34, 22, 55, 34, 22, 55, 34, 22, 55, 34, 22 };
                dynamicArray.AddRange(ar);
                Console.WriteLine($"{dynamicArray}{Environment.NewLine}");

                Console.WriteLine("Change array to:");
                dynamicArray = new DynamicArray<int>(new int[] { 1, 2, 3, 4, 5 });
                Console.WriteLine($"{dynamicArray}{Environment.NewLine}");

                Console.WriteLine("Remove method(removing third element):");
                dynamicArray.MyRemove(3);
                Console.WriteLine($"{dynamicArray}{Environment.NewLine}");

                Console.WriteLine("Insert method(inserting to third position):");
                dynamicArray.MyInsert(3, 4);
                Console.WriteLine($"{dynamicArray}{Environment.NewLine}");

                Console.WriteLine("Access to array element bu index (index:4)");
                Console.WriteLine($"Fourth element is: {dynamicArray[4]}{Environment.NewLine}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                Environment.Exit(1);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                Environment.Exit(1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Environment.Exit(1);
            }
        }
    }
}
