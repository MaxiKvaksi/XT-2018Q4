using System;

namespace Epam.Task2.Rectangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The application calculates the area of the rectangle." + Environment.NewLine + "Input a side \"a\":");
            if (double.TryParse(Console.ReadLine(), out double a) && a > 0)
            {
                Console.WriteLine("Input a side \"b\":");
                if (double.TryParse(Console.ReadLine(), out double b) && b > 0)
                {
                    Console.WriteLine($"Rectangle area with sides a:{a} и b:{b} is {RectArea(a,b)}");
                }
                else
                {
                    IncorrectInput();
                }
            }
            else
            {
                IncorrectInput();
            }
        }

        public static double RectArea(double a, double b)
        {
            return a * b;
        }

        public static void IncorrectInput()
        {
            Console.WriteLine("Incorrect input! Application will be stop.");
        }
    }
}
