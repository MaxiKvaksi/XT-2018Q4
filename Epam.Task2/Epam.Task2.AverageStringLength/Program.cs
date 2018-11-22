/*
 * The application define average words length in sentence.
 * */
using System;

namespace Epam.Task2.AverageStringLength
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The application define average words length in sentence." + Environment.NewLine + "Input the string:");
            string inputString = string.Empty;
            inputString = Console.ReadLine();
            if (inputString.Length != 0)
            {
                Console.WriteLine("Average words length: " + GetAverageStringLength(inputString));
            }
            else
            {
                Console.WriteLine("Empty string! Application will be stop.");
            }
        }

        public static float GetAverageStringLength(string str)
        {
            int sumWordLength = 0;
            int wordsCounter = 0;
            bool isWord = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsSeparator(str[i]))
                {
                    if (!isWord)
                    {
                        continue;
                    }

                    isWord = false;
                    continue;
                }

                if (!isWord)
                {
                    wordsCounter++;
                    isWord = true;
                }

                sumWordLength++;
            }

            return (float)sumWordLength / wordsCounter;
        }
    }
}
