using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Epam.Task5.SortingUnit
{
    public class SortingUnit : CustomSort.Sorting
    {
        public delegate void SortingHandler();

        public static event SortingHandler OnSort;

        public static void SortingInOwnThread<T>(IEnumerable<T> array, Func<T, T, bool> func)
        {
            Thread sortingThread = new Thread(() => Sorting(array, func));
            sortingThread.Start();
        }

        private static void Sorting<T>(IEnumerable<T> array, Func<T, T, bool> func)
        {
            SortingUnit.BubbleSort(array, func);
            OnSort();
        }
    }
}
