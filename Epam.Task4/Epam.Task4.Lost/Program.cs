using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.Lost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The application demonstrates the circle game process.");
            Console.WriteLine("Input the count of participants(2 and more):");
            int countOfParticipants = 0;
            if (int.TryParse(Console.ReadLine(), out countOfParticipants) && countOfParticipants > 1)
            {
                List<Person> dangerousCircle = new List<Person>(countOfParticipants);
                for (int i = 0; i < countOfParticipants; i++)
                {
                    dangerousCircle.Add(new Person(i + 1));
                }

                Console.WriteLine("The initiate group:");
                ShowList(dangerousCircle);
                Console.WriteLine($"{Environment.NewLine}The game started!");
                RemoveEvenItems(ref dangerousCircle);
            }
            else
            {
                Console.WriteLine("Invalid input! The application will be stop...");
            }
        }

        private static void RemoveEvenItems<T>(ref List<T> list)
        {
            int iterator = 1;
            while (list.Count > 1)
            {
                int initCount = list.Count;
                for (int i = iterator; i < list.Count; i += 2)
                {
                    Console.WriteLine($"Removed: {list[i]}");
                    list.RemoveAt(i);
                    i--;
                    iterator += 2;
                }

                iterator = iterator - initCount;
                Console.WriteLine(iterator);
            }
        }

        private static void ShowList<T>(List<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
