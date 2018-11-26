using System;

namespace Epam.Task2.FontAdjustment
{
    public class Program
    {
        [Flags]
        public enum TextStyle
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4
        }

        public static void Main(string[] args)
        {
            TextStyle currentStyle = TextStyle.None;
            while (true)
            {
                Console.WriteLine($"The application is for changing text style.{Environment.NewLine + Environment.NewLine}" +
                    $"Input a menu item or another character to exit.{Environment.NewLine}" +
                    $"Style parameters: {currentStyle}{Environment.NewLine}\t1.Bold" +
                    $"{Environment.NewLine}\t2.Italic{Environment.NewLine}\t3.Underline");

                if (int.TryParse(Console.ReadLine(), out int n) && n <= 3 && n > 0)
                {
                    if (n == 3)
                    {
                        n = 4;
                    }

                    currentStyle ^= (TextStyle)n;
                    Console.WriteLine(currentStyle);
                }
                else
                {
                    Console.WriteLine("Incorrect input or exit. Application will be stop.");
                    break;
                }

                Console.Clear();
            }
        }
    }
}
