using System;

namespace Epam.Task2.NoPositive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The application which change positive numbers to zeros in 3D array.");
            Get3DArray(out int[,,] array);
            Console.WriteLine("Generated array:");
            Show3dArray(array);
            Console.WriteLine("Processed array:");
            PositiveIt(ref array);
            Show3dArray(array);
        }

        public static int[,,] Get3DArray(out int[,,] array3d)
        {
            Random random = new Random();
            const int Size = 2;
            array3d = new int[Size, Size, Size];
            for (int i = 0; i < array3d.GetLength(0); i++)
            {
                for (int j = 0; j < array3d.GetLength(1); j++)
                {
                    for (int k = 0; k < array3d.GetLength(2); k++)
                    {
                        array3d[i, j, k] = random.Next(-10, 10);
                    }
                }
            }

            return array3d;
        }

        public static void PositiveIt(ref int[,,] array3d)
        {
            for (int i = 0; i < array3d.GetLength(0); i++)
            {
                for (int j = 0; j < array3d.GetLength(1); j++)
                {
                    for (int k = 0; k < array3d.GetLength(2); k++)
                    {
                        if (array3d[i, j, k] > 0)
                        {
                            array3d[i, j, k] = 0;
                        }
                    }
                }
            }
        }

        public static void Show3dArray(int[,,] array3d)
        {
            for (int i = 0; i < array3d.GetLength(0); i++)
            {
                Console.WriteLine($" {i})");
                for (int j = 0; j < array3d.GetLength(1); j++)
                {
                    for (int k = 0; k < array3d.GetLength(2); k++)
                    {
                        Console.Write(array3d[i, j, k] + " ");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }
    }
}
