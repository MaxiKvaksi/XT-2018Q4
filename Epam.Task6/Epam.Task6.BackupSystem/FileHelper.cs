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
        private static StreamReader streamReader;

        public static bool BackUpFileExists()
        {
            var directoryInfo = new FileInfo(BackupManager.BackupPath);
            return directoryInfo.Exists;
        }

        public static bool CreateBackUpFile()
        {
            try
            {
                CreateFile(BackupManager.BackupPath);
                CreateDirectory(BackupManager.BackupFolderPath);
                ScanDirectory();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        private static void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
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
            using (StreamWriter writer = File.AppendText(BackupManager.BackupPath))
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
            return filePath.Equals(BackupManager.BackupPath);
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
                streamReader = new StreamReader(BackupManager.BackupPath);
            }
        }

        public static void CloseReaderStream()
        {
            if (streamReader != null)
            {
                streamReader.Close();
            }
        }

        private static void ScanDirectory()
        {
            var rootDir = Data.RootDirectory;
            GetSubdirectories(ref rootDir);
            /*string[] directories = Directory.GetDirectories(BackupManager.CurrentPath);
            foreach (string directory in directories)
            {
                Data.Directories[index].AddDirectory(directory);
            }
            foreach (var file in Directory.EnumerateFiles(BackupManager.CurrentPath, "*.txt", SearchOption.AllDirectories))
            {
                if(IsBackUpFile(file))
                {
                    continue;
                }
                Change change = new Change(DateTime.Now, ChangeType.Change, file);
                AppendToFile(change);
            }*/
        }

        private static void GetSubdirectories(ref MyDirectory myDirectory)
        {
            string[] directories = Directory.GetDirectories(myDirectory.Path);

            foreach (string directory in directories)
            {
                myDirectory.AddDirectory(directory);
                var dir = myDirectory.Directories[myDirectory.Directories.Keys.Max()] as MyDirectory;
                GetSubdirectories(ref dir);
                GetFiles(ref dir);
            }
        }

        private static void GetFiles(ref MyDirectory myDirectory)
        {
            foreach (var file in Directory.EnumerateFiles(myDirectory.Path, "*.txt", SearchOption.TopDirectoryOnly))
            {
                if (IsBackUpFile(file))
                {
                    continue;
                }
                myDirectory.AddFile(file, GetFileContent(file));
            }
        }

        private static string GetFileContent(string file)
        {
            return File.ReadAllText(file);
        }
    }
}
