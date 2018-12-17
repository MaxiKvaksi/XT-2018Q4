using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task6.BackupSystem
{
    public class FileHelper
    {
        private static string backUpPath = @"backup.txt";
        private static StreamReader streamReader;

        public static string BackUpPath { get => backUpPath; set => backUpPath = value; }

        public static bool BackUpFileExists(string fileName)
        {
            var directoryInfo = new FileInfo(backUpPath);
            return directoryInfo.Exists;
        }

        public static bool CreateBackUpFile(string path)
        {
            try
            {
                backUpPath = Path.Combine(path, "backup.txt");
                CreateFile(backUpPath);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static void CreateFile(string filePath)
        {
            File.Create(filePath).Close();
        }

        public static void DeleteFile(string filePath)
        {
            File.Delete(filePath);
        }

        public static void RenameFile(string path, string previewPath)
        {
            File.Move(path, previewPath);
        }

        public static void AppendToFile(Change change)
        {
            using (StreamWriter writer = File.AppendText(backUpPath))
            {
                try
                {
                    writer.WriteLine(change.ToString());
                }
                catch (IOException e)
                {
                    Console.WriteLine($"Backup file write error. {e.Message}");
                }
            }
        }

        public static bool IsBackUpFile(string filePath)
        {
            return filePath.Equals(BackUpPath);
        }

        public static bool ReadStringFromFile(out string readedString)
        {
            readedString = string.Empty;
            if (streamReader.EndOfStream)
            {
                return false;
            }

            try
            {
                readedString = streamReader.ReadLine();
                return true;
            }
            catch (IOException e)
            {
                Console.WriteLine($"Backup file write error. {e.Message}");
                return false;
            }
        }

        public static void OpenReaderStream()
        {
            if (streamReader == null)
            {
                streamReader = new StreamReader(backUpPath);
            }
        }

        public static void CloseReaderStream()
        {
            if (streamReader != null)
            {
                streamReader.Close();
            }
        }
    }
}
