using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Epam.Task5.ISeekYou.Program;

namespace Epam.Task5.ISeekYou
{
    public static class Extensions
    {
        public static int[] SearchPositiveElements(this int[] array)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    list.Add(array[i]);
                }
            }

            return list.ToArray();
        }

        public static int[] SearchPositiveElements(this int[] array, SearchingDelegate func)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (func(array[i]))
                {
                    list.Add(array[i]);
                }
            }

            return list.ToArray();
        }

        public static int[] SearchPositiveElements(this int[] array, IEnumerable<int> collection)
        {
            return collection.ToArray();
        }
    }
}
