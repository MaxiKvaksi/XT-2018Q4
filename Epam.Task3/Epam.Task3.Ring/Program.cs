using System;

namespace Epam.Task3.Ring
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The application demonstrates the class 'Ring' using.");
            Ring ring = new Ring(x: 5.3, y: 1.4, outerRadius: 15, innerRadius: 2);
            Console.WriteLine(ring);
            ring.OuterRadius = 25;
            ring.InnerRadius = 7;
            ring.X = 0;
            ring.Y = 1.12;
            Console.WriteLine($"{Environment.NewLine}Updated ring:");
            Console.WriteLine(ring);
        }
    }
}
