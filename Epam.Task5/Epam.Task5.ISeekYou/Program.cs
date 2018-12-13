using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.ISeekYou
{
    public class Program
    {
        private static int arraySize = 1000;
        private static int iterations = 1000;
        private static int accuracy = 10;
        private static int[] array;
        private static Stopwatch stopwatch = new Stopwatch();
        public delegate bool SearchingDelegate(int value);

        private static IEnumerable<int> queryLinq;

        private static SearchingDelegate searchingDelegateInstance = new SearchingDelegate(IsPositive);
        private static SearchingDelegate searchingDelegateAnonymous = delegate (int value)
        {
            return value > 0;
        };
        private static SearchingDelegate searchingDelegateLambda = value =>
        {
            return value > 0;
        };

        public static void Main(string[] args)
        {
            Console.WriteLine("The application demonstrates of difference between search methods with various methods of compare.");
            array = CustomSort.Program.GetRandomizedIntList(arraySize).ToArray();
            queryLinq = from element in array
                         where element > 0
                         select element;
            bool validInput = false;
            Console.WriteLine("Input an array size (recommend > 100000): ");
            if(int.TryParse(Console.ReadLine(), out arraySize) && arraySize > 0)
            {
                Console.WriteLine("Input a count of operation (recommend > 10000): ");
                if (int.TryParse(Console.ReadLine(), out iterations) && iterations > 0)
                {
                    Console.WriteLine("Input an accuracy (recommend > 10): ");
                    if (int.TryParse(Console.ReadLine(), out accuracy) && accuracy > 0)
                    {
                        validInput = true;
                        Console.WriteLine("Calculating...");
                        Console.WriteLine($"Simple method: {CalculateSimpleMethod(MethodType.Simple)} msec.");
                        Console.WriteLine($"Delegate instance: {CalculateSimpleMethod(MethodType.Instance)} msec.");
                        Console.WriteLine($"Anonumous method: {CalculateSimpleMethod(MethodType.Anonymous)} msec.");
                        Console.WriteLine($"Lambda expressions: {CalculateSimpleMethod(MethodType.Lambda)} msec.");
                        Console.WriteLine($"LINQ: {CalculateSimpleMethod(MethodType.Linq)}  msec.");
                    }
                }
            }
            if(!validInput)
            {
                Console.WriteLine("Invalid input! Application will be stop...");
            }
           
        }

        private static bool IsPositive(int value)
        {
            return value > 0;
        }

        public static long CalculateSimpleMethod(MethodType methodType)
        {
            if(array == null)
            {
                throw new NullReferenceException("Array is null");
            }
            long[] measurements = new long[accuracy];
            for (int i = 0; i < accuracy; i++)
            {
                stopwatch.Reset();
                stopwatch.Start();
                for (int j = 0; j < iterations; j++)
                {
                    switch (methodType)
                    {
                        case MethodType.Simple:
                            array.SearchPositiveElements();
                            break;
                        case MethodType.Instance:
                            array.SearchPositiveElements(searchingDelegateInstance);
                            break;
                        case MethodType.Anonymous:
                            array.SearchPositiveElements(searchingDelegateAnonymous);
                            break;
                        case MethodType.Lambda:
                            array.SearchPositiveElements(searchingDelegateLambda);
                            break;
                        case MethodType.Linq:
                            array.SearchPositiveElements(queryLinq);
                            break;
                        default:
                            break;
                    }
                }
                stopwatch.Stop();
                measurements[i] = stopwatch.ElapsedMilliseconds;
            }
            Array.Sort(measurements);
            return measurements[accuracy/2];
        }
    }
}
