using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task6.BackupSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = "#";
            Console.WriteLine("The application demonstrates work of simple backup system.");
            do
            {
                Console.WriteLine("Type 'e' to exit");
                Console.WriteLine("Choose a work mode:");
                Console.WriteLine($"1. Listen file system{Environment.NewLine}2. Restore backup");
                input = Console.ReadLine();
                if(input == "1")
                {
                    Console.WriteLine("Input a folder path to listen:");
                    string path = Console.ReadLine();
                    //string path = @"c:\test";
                    while(!Utils.ValidPath(path) && input != "m")
                    {
                        Console.WriteLine("Path is invalid. Try again or type 'm' to return to menu");
                        path = Console.ReadLine();
                    }
                    if (input != "m")
                    {
                        FileHelper.CreateBackUpFile(path);
                        Watcher.Run(path);
                    }
                }
                if(input == "2")
                {
                    FileHelper.BackUpPath = @"c:\test\backup.txt";
                    Console.Write("Reading backup file...");
                    BackupManager.ParseChanges();
                    Console.WriteLine("\rBackup file has read!");
                    Console.WriteLine("Input date for restore (format: 'yyyy/MM/dd HH:mm')");
                    if(DateTime.TryParse(Console.ReadLine(), out DateTime dateTime))
                    {
                        BackupManager.RestoreFiles(dateTime);
                    }
                    BackupManager.RestoreFiles(new DateTime(2017, 10, 5, 14, 15, 10));
                    Console.WriteLine("Type 'e' to exit");
                }
            } while (Console.ReadLine() != "e");
        }
    }
}
