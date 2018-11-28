using System;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The application demonstrates protype of 'Vector Graphics Editor'." + Environment.NewLine);

            Line line = new Line(x: 0.18, y: 2, x2: 1, y2: 3, borderColor: new Color("red"));
            Round round = new Round(x: 0.18, y: 2, radius: 0.33, borderColor: new Color("red"));
            Rectangle rectangle = new Rectangle(x: 0.18, y: 2, a: 1, b: 3, borderColor: new Color("red"), fiilColor: new Color("red"));
            Circle circle = new Circle(x: 0.18, y: 2, radius: 0.33, borderColor: new Color("red"), fiilColor: new Color("red"));
            Ring ring = new Ring(x: 0.18, y: 2, outerRadius: 0.23, innerRadius: 0.33, borderColor: new Color("red"), fiilColor: new Color("red"));

            Console.WriteLine($"1: {line.GetType().ToString()} {line}{Environment.NewLine}");
            Console.WriteLine($"2: {round.GetType().ToString()} {round}{Environment.NewLine}");
            Console.WriteLine($"3: {rectangle.GetType().ToString()} {rectangle}{Environment.NewLine}");
            Console.WriteLine($"4: {circle.GetType().ToString()} {circle}{Environment.NewLine}");
            Console.WriteLine($"5: {ring.GetType().ToString()} {ring}{Environment.NewLine}");
        }
    }
}
