using System;
using Epam.Task4.DynamicArrayHardcoreMode;

namespace Epam.Task4.DynamicArrayHardcoreMode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The application demonstrates a hardmode of dynamic array.");
            DynamicArrayHM<int> dynamicArrayHM = new DynamicArrayHM<int>(new int[] { 1, 2, 3, 4, 5 });
            Console.WriteLine("Using negative index(-3):");
            Console.WriteLine($"'-3' element is: {dynamicArrayHM[-3]}");
            Console.WriteLine("Dynamicly capacity changing:");
            dynamicArrayHM.SetCapacity(2);
            Console.WriteLine(dynamicArrayHM);
            dynamicArrayHM.SetCapacity(10);
            Console.WriteLine(dynamicArrayHM);
            CycledDynamicArray<int> cycledDynamicArray = new CycledDynamicArray<int>(new int[] { 1, 2, 3, 4, 5 });
            int counter = 0;
            Console.WriteLine("Endless array (limiter 1000):");
            foreach (var item in cycledDynamicArray)
            {
                counter++;
                Console.Write(item);
                if (counter == 1000)
                {
                    break;
                }
            }
            Console.WriteLine();
            Console.WriteLine("ReferenceEquals between dynamic array and its clone. They is equal:");
            Console.WriteLine(ReferenceEquals(dynamicArrayHM, dynamicArrayHM.Clone()));
        }
    }
}
