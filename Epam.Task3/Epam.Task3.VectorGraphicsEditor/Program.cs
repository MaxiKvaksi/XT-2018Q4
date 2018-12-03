using System;
using System.Collections.Generic;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Figure> figures = new List<Figure>();
            Figure figure;

            while (true)
            {
                figure = null;
                UpdateMenu(figure);
                ChooseFigureType(out figure);
                UpdateMenu(figure);
                ChangeX(figure);
                UpdateMenu(figure);
                ChangeY(figure);
                UpdateMenu(figure);
                ChangeBorderColor(figure);
                UpdateMenu(figure);
                if (figure is Line)
                {
                    ChangeLineX2(figure);
                    UpdateMenu(figure);
                    ChangeLineY2(figure);
                    UpdateMenu(figure);
                }

                if (figure is Rectangle)
                {
                    ChangeRectangleASide(figure);
                    UpdateMenu(figure);
                    ChangeRectangleBSide(figure);
                    UpdateMenu(figure);
                }

                if (figure is Ring)
                {
                    ChangeRingInnerRadius(figure);
                    ChangeRingOuterRadius(figure);
                    UpdateMenu(figure);
                }

                if (figure is Circle)
                {
                    ChangeCircleRadius(figure);
                    UpdateMenu(figure);
                }

                if (figure is Round)
                {
                    ChangeRoundRadius(figure);
                    UpdateMenu(figure);
                }

                if (figure is FilledFigure)
                {
                    ChangeFillColor(figure);
                    UpdateMenu(figure);
                }

                Console.WriteLine($"Figure is: {figure}");
                Pause();
                ClearMenu();
                figures.Add(figure);
                Console.WriteLine("Your figures:");
                foreach (var item in figures)
                {
                    Console.WriteLine(item);
                }

                Pause();
            }
        }

        private static void ChooseFigureType(out Figure figure)
        {
            int inputMenuItem;
            do
            {
                Console.WriteLine("Choose figure type or type 'exit' to exit from the application:");
                Console.WriteLine($"1.Line{Environment.NewLine}2.Rectangle{Environment.NewLine}3.Circle" +
                    $"{Environment.NewLine}4.Ring{Environment.NewLine}5.Round{Environment.NewLine}");
            }
            while ((inputMenuItem = CheckMenuInput(Console.ReadLine(), 5)) == -1);
            switch (inputMenuItem)
            {
                case 1:
                    figure = new Line();
                    break;
                case 2:
                    figure = new Rectangle();
                    break;
                case 3:
                    figure = new Circle();
                    break;
                case 4:
                    figure = new Ring();
                    break;
                case 5:
                    figure = new Round();
                    break;
                default:
                    figure = null;
                    break;
            }
        }

        private static void ChangeX(Figure figure)
        {
            double inputVariable;
            do
            {
                Console.WriteLine("X:");
            }
            while (!double.TryParse(Console.ReadLine(), out inputVariable));
            figure.X = inputVariable;
        }

        private static void ChangeY(Figure figure)
        {
            double inputVariable;
            do
            {
                Console.WriteLine("Y:");
            }
            while (!double.TryParse(Console.ReadLine(), out inputVariable));
            figure.Y = inputVariable;
        }

        private static void ChangeLineX2(Figure figure)
        {
            double inputVariable;
            do
            {
                Console.WriteLine("X2:");
            }
            while (!double.TryParse(Console.ReadLine(), out inputVariable));
            (figure as Line).X2 = inputVariable;
        }

        private static void ChangeLineY2(Figure figure)
        {
            double inputVariable;
            do
            {
                Console.WriteLine("Y2:");
            }
            while (!double.TryParse(Console.ReadLine(), out inputVariable));
            (figure as Line).Y2 = inputVariable;
        }

        private static void ChangeRectangleASide(Figure figure)
        {
            bool ok = false;
            do
            {
                Console.WriteLine("A:");
                if (double.TryParse(Console.ReadLine(), out double inputVariable) && inputVariable >= 0)
                {
                    try
                    {
                        (figure as Rectangle).A = inputVariable;
                        ok = true;
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid 'a' parameter");
                }
            }
            while (!ok);
        }

        private static void ChangeRectangleBSide(Figure figure)
        {
            bool ok = false;
            do
            {
                Console.WriteLine("B:");
                if (double.TryParse(Console.ReadLine(), out double inputVariable) && inputVariable >= 0)
                {
                    try
                    {
                        (figure as Rectangle).B = inputVariable;
                        ok = true;
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid 'b' parameter");
                }
            }
            while (!ok);
        }

        private static void ChangeRingInnerRadius(Figure figure)
        {
            bool ok = false;
            do
            {
                Console.WriteLine("Inner radius:");
                if (double.TryParse(Console.ReadLine(), out double inputVariable) && inputVariable >= 0)
                {
                    try
                    {
                        (figure as Ring).InnerRadius = inputVariable;
                        ok = true;
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid 'inner radius' parameter");
                }
            }
            while (!ok);
        }

        private static void ChangeRingOuterRadius(Figure figure)
        {
            bool ok = false;
            do
            {
                Console.WriteLine("Outer radius:");
                if (double.TryParse(Console.ReadLine(), out double inputVariable) && inputVariable >= 0)
                {
                    try
                    {
                        (figure as Ring).OuterRadius = inputVariable;
                        ok = true;
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid 'outer radius' parameter");
                }
            }
            while (!ok);
        }

        private static void ChangeCircleRadius(Figure figure)
        {
            double inputVariable;
            do
            {
                Console.WriteLine("Radius:");
            }
            while (!double.TryParse(Console.ReadLine(), out inputVariable) && inputVariable >= 0);
            (figure as Circle).Radius = inputVariable;
        }

        private static void ChangeRoundRadius(Figure figure)
        {
            double inputVariable;
            do
            {
                Console.WriteLine("Radius:");
            }
            while (!double.TryParse(Console.ReadLine(), out inputVariable) && inputVariable >= 0);
            (figure as Round).Radius = inputVariable;
        }

        private static void ChangeBorderColor(Figure figure)
        {
            int inputMenuItem;
            do
            {
                Console.WriteLine("Choose border color:");
                Console.WriteLine($"1.Green{Environment.NewLine}2.Red{Environment.NewLine}3.Blue" +
                    $"{Environment.NewLine}4.Yellow{Environment.NewLine}5.White{Environment.NewLine}" +
                    $"6.Black{Environment.NewLine}");
            }
            while ((inputMenuItem = CheckMenuInput(Console.ReadLine(), 6)) == -1);
            switch (inputMenuItem)
            {
                case 1:
                    figure.BorderColor = Color.Green;
                    break;
                case 2:
                    figure.BorderColor = Color.Red;
                    break;
                case 3:
                    figure.BorderColor = Color.Blue;
                    break;
                case 4:
                    figure.BorderColor = Color.Yellow;
                    break;
                case 5:
                    figure.BorderColor = Color.White;
                    break;
                case 6:
                    figure.BorderColor = Color.Black;
                    break;
            }
        }

        private static void ChangeFillColor(Figure figure)
        {
            int inputMenuItem;
            do
            {
                Console.WriteLine("Choose filled color:");
                Console.WriteLine($"1.Green{Environment.NewLine}2.Red{Environment.NewLine}3.Blue" +
                    $"{Environment.NewLine}4.Yellow{Environment.NewLine}5.White{Environment.NewLine}" +
                    $"6.Black{Environment.NewLine}");
            }
            while ((inputMenuItem = CheckMenuInput(Console.ReadLine(), 6)) == -1);
            switch (inputMenuItem)
            {
                case 1:
                    (figure as FilledFigure).FiilColor = Color.Green;
                    break;
                case 2:
                    (figure as FilledFigure).FiilColor = Color.Red;
                    break;
                case 3:
                    (figure as FilledFigure).FiilColor = Color.Blue;
                    break;
                case 4:
                    (figure as FilledFigure).FiilColor = Color.Yellow;
                    break;
                case 5:
                    (figure as FilledFigure).FiilColor = Color.White;
                    break;
                case 6:
                    (figure as FilledFigure).FiilColor = Color.Black;
                    break;
            }
        }

        private static int CheckMenuInput(string value, int maxLimit)
        {
            if (value == "exit")
            {
                Console.WriteLine("The application will be stop.");
                Environment.Exit(0);   
            }

            if (int.TryParse(value, out int n) && n > 0 && n <= maxLimit)
            {
                return n;
            }
            else
            {
                Console.WriteLine("Incorrect input.");
                return -1;
            }
        }

        private static double CheckCoordinatesInput(string value)
        {
            if (double.TryParse(value, out double n))
            {
                return n;
            }
            else
            {
                throw new FormatException("Invalid coordinate input!");
            }
        }

        private static void UpdateMenu(Figure figure)
        {
            ClearMenu();
            Console.WriteLine("The application demonstrates demo ver. of 'Vector Graphics Editor'." + Environment.NewLine);
            Console.WriteLine("Current figure is:");
            if (figure != null)
            {
                figure.Draw();
                Console.WriteLine();
            }
        }

        private static void ClearMenu()
        {
            Console.Clear();
        }

        private static void Pause()
        {
            Console.WriteLine("Input anything to continue...");
            Console.ReadKey();
        }
    }
}
