using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.CustomSortDemo
{
    public class Program
    {
        private static Random random = new Random();

        private static Func<string, string, bool> func = delegate(string str1, string str2)
        {
            if (str1.Length > str2.Length)
            {
                return true;
            }
            else if (str1.Length == str2.Length)
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    if (str1[i] > str2[i])
                    {
                        return true;
                    }
                }

                return false;
            }
            else
            {
                return false;
            }  
        };

        public static void Main(string[] args)
        {
            string[] stringArray = GetRandomizedStringArray(random.Next(5, 15));
            ShowIEnumerable(stringArray);
            ShowIEnumerable(CustomSort.Sorting.BubbleSort(stringArray, func));
        }

        private static string[] GetRandomizedStringArray(int size)
        {
            string[] array = new string[size];
            int avgStringSize = 5;
            int tolerance = 3;
            for (int i = 0; i < size; i++)
            {
                array[i] = GetRandomizedString(random.Next(avgStringSize - tolerance, avgStringSize + tolerance));
            }

            return array;
        }

        private static string GetRandomizedString(int size)
        {
            StringBuilder stringBuilder = new StringBuilder(new string(' ', size));
            int a = 97;
            int z = 122;
            for (int i = 0; i < size; i++)
            {
                stringBuilder[i] = (char)random.Next(a, z);
            }

            return stringBuilder.ToString();
        }

        private static void ShowIEnumerable<T>(IEnumerable<T> elements)
        {
            Console.WriteLine(string.Join(", ", elements));
        }
    }
}
