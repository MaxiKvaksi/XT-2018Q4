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

        public static void AppendChangeToFile(Change change)
        {
            AppendToFile(BackupManager.BackupPath, change.ToString());
        }

        public static void AppendToFile(string path, string info)
        {
            try
            { 
                using (StreamWriter writer = File.AppendText(path))
                {
                    writer.WriteLine(info);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"File write error. {e.Message}");
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

        public static void OpenReaderStream(string path)
        {
            if (streamReader == null)
            {
                streamReader = new StreamReader(path);
            }
        }

        public static void CloseReaderStream()
        {
            if (streamReader != null)
            {
                streamReader.Close();
            }
        }
        public static string GenerateDateTimeFileName(string file, DateTime dateTime)
        {
            string filename = $"{BackupManager.BackupFolderName}\\{dateTime.ToFileTime()}#{Path.GetFileName(file)}";
            return Path.Combine(Path.GetDirectoryName(file), filename);
        }

        public static void CopyFile(string from, string to)
        {
            try
            {
                File.Copy(from, to, true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ScanDirectory()
        {
            ClearFolder(BackupManager.BackupFolderPath);
            foreach (var file in Directory.EnumerateFiles(BackupManager.CurrentPath, "*.txt", SearchOption.AllDirectories))
            {
                if (IsBackUpFile(file) || Path.GetDirectoryName(file) == BackupManager.BackupFolderPath)
                {
                    continue;
                }

                BackupManager.AddInnerChange(file);
            }
        }

        private static void CreateChangeContentDependincies()
        {
            Directory.CreateDirectory(BackupManager.BackupFolderPath);
            ScanDirectory();
        }

        private static void ClearFolder(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();
            }
        }

        private static string GetFileContent(string file)
        {
            return File.ReadAllText(file);
        }
    }
}
