/**
 * SEQUENCE
 * Application which demonstrate work of function outputting sequence of positive numbers
 */
using System;
using System.Text;

namespace Epam.Task1.Sequence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Application which demonstrate work of function outputting sequence of positive numbers." +
                "\n\nFor example: 7");
            Console.WriteLine(GetNumbers(7));
        }

        public static string GetNumbers(int n)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                builder.Append(i);
                builder.Append(", ");
            }

            builder.Append(n);
            return builder.ToString();
        }
    }
}
