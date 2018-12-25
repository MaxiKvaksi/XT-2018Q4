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
<<<<<<< HEAD
<<<<<<< HEAD
            var directoryInfo = new FileInfo(BackupManager.BackupPath);
=======
            var directoryInfo = new FileInfo(backUpPath);
>>>>>>> parent of e53564f... Task6(ver0.2)
=======
            var directoryInfo = new FileInfo(BackupManager.BackUpPath);
>>>>>>> parent of a705b46... Task6(ver2.1)
            return directoryInfo.Exists;
        }

        public static bool CreateBackUpFile(string path)
        {
            try
            {
<<<<<<< HEAD
<<<<<<< HEAD
                CreateFile(BackupManager.BackupPath);
                CreateChangeContentDependincies();
=======
                backUpPath = Path.Combine(path, "backup.txt");
                CreateFile(backUpPath);
>>>>>>> parent of e53564f... Task6(ver0.2)
=======
                CreateFile(BackupManager.BackUpPath);
>>>>>>> parent of a705b46... Task6(ver2.1)
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
<<<<<<< HEAD
<<<<<<< HEAD
            AppendToFile(BackupManager.BackupPath, change.ToString());
        }

        public static void AppendToFile(string path, string info)
        {
            try
=======
            using (StreamWriter writer = File.AppendText(backUpPath))
>>>>>>> parent of e53564f... Task6(ver0.2)
=======
            using (StreamWriter writer = File.AppendText(BackupManager.BackUpPath))
>>>>>>> parent of a705b46... Task6(ver2.1)
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
<<<<<<< HEAD
<<<<<<< HEAD
            return filePath.Equals(BackupManager.BackupPath);
=======
            return filePath.Equals(BackUpPath);
>>>>>>> parent of e53564f... Task6(ver0.2)
=======
            return filePath.Equals(BackupManager.BackUpPath);
>>>>>>> parent of a705b46... Task6(ver2.1)
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
<<<<<<< HEAD
<<<<<<< HEAD
                streamReader = new StreamReader(path);
=======
                streamReader = new StreamReader(backUpPath);
>>>>>>> parent of e53564f... Task6(ver0.2)
=======
                streamReader = new StreamReader(BackupManager.BackUpPath);
>>>>>>> parent of a705b46... Task6(ver2.1)
            }
        }

        public static void CloseReaderStream()
        {
            if (streamReader != null)
            {
                streamReader.Close();
            }
        }
<<<<<<< HEAD

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
=======
>>>>>>> parent of a705b46... Task6(ver2.1)
    }
}
