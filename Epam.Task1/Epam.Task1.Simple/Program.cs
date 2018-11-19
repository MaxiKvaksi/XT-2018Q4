/**
 * SIMPLE
 * Application which demonstrate work of function of determining simplicity of number 
 */
using System;

namespace Epam.Task1.Simple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Application which demonstrate work of function of determining simplicity of number." +
               "\n\nFor example: 2, 4, 7, 13");
            Console.WriteLine("2 is simple: " + IsSimple(2));
            Console.WriteLine("4 is simple: " + IsSimple(4));
            Console.WriteLine("7 is simple: " + IsSimple(7));
            Console.WriteLine("13 is simple: " + IsSimple(13));
        }

        public static bool IsSimple(long n)
        {
            for (long i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }

            return true;
        }
    }
}
