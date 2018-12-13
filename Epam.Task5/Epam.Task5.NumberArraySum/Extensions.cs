using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.NumberArraySum
{
    public static class Extensions
    {
        public static int SumOfElements(this int[] array)
        {
            int sum = default(int);
            for (int i = 0; i < array.Count(); i++)
            {
                sum += array.ElementAt(i);
            }

            return sum;
        }

        public static int? SumOfElements(this int?[] array)
        {
            int? sum = default(int?);
            for (int i = 0; i < array.Count(); i++)
            {
                sum += array.ElementAt(i);
            }

            return sum;
        }

        public static long SumOfElements(this long[] array)
        {
            long sum = default(long);
            for (int i = 0; i < array.Count(); i++)
            {
                sum += array.ElementAt(i);
            }

            return sum;
        }

        public static long? SumOfElements(this long?[] array)
        {
            long? sum = default(long?);
            for (int i = 0; i < array.Count(); i++)
            {
                sum += array.ElementAt(i);
            }

            return sum;
        }

        public static float SumOfElements(this float[] array)
        {
            float sum = default(float);
            for (int i = 0; i < array.Count(); i++)
            {
                sum += array.ElementAt(i);
            }

            return sum;
        }

        public static float? SumOfElements(this float?[] array)
        {
            float? sum = default(float?);
            for (int i = 0; i < array.Count(); i++)
            {
                sum += array.ElementAt(i);
            }

            return sum;
        }

        public static double SumOfElements(this double[] array)
        {
            double sum = default(double);
            for (int i = 0; i < array.Count(); i++)
            {
                sum += array.ElementAt(i);
            }

            return sum;
        }

        public static double? SumOfElements(this double?[] array)
        {
            double? sum = default(double?);
            for (int i = 0; i < array.Count(); i++)
            {
                sum += array.ElementAt(i);
            }

            return sum;
        }

        public static decimal SumOfElements(this decimal[] array)
        {
            decimal sum = default(decimal);
            for (int i = 0; i < array.Count(); i++)
            {
                sum += array.ElementAt(i);
            }

            return sum;
        }

        public static decimal? SumOfElements(this decimal?[] array)
        {
            decimal? sum = default(decimal?);
            for (int i = 0; i < array.Count(); i++)
            {
                sum += array.ElementAt(i);
            }

            return sum;
        }
    }
}
