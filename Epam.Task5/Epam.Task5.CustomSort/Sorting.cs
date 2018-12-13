using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.CustomSort
{
    public class Sorting
    {
        public static IEnumerable<T> BubbleSort<T>(IEnumerable<T> array, Func<T, T, bool> func)
        {
            if (func == null)
            {
                throw new NullReferenceException("No function.");
            }

            T temp;
            T[] processingArray = array.ToArray();
            for (int i = 0; i < processingArray.Length; i++)
            {
                for (int j = i + 1; j < processingArray.Length; j++)
                {
                    if (func(processingArray[i], processingArray[j]))
                    {
                        temp = processingArray[i];
                        processingArray[i] = processingArray[j];
                        processingArray[j] = temp;
                    }
                }
            }

            return processingArray;
        }
    }
}
