using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.NumberArraySum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The application demonstrates extensions for number arrays.");
            Console.WriteLine("For example:");
            Console.WriteLine("'Sum of int array' extension.");
            int[] array = CustomSort.Program.GetRandomizedIntList(20).ToArray();
            CustomSort.Program.ShowIEnumerable(array);
            Console.WriteLine($"Sum of array elements: {array.SumOfElements()}");
        }
    }
}
