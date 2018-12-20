using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Linq;

namespace Epam.Task6.BackupSystem
{
    public static class BackupManager
    {
        private static DateTime lastBackupTime;
        private static string backUpPath;
        private static string currentPath;
        public const string BackupFileName = "backup.txt";
        private static List<Change> changes = new List<Change>();
        private static Thread watchThread;

        public static List<Change> Changes { get => changes; set => changes = value; }
        public static string BackUpPath { get => backUpPath; set => backUpPath = value; }
        public static string CurrentPath
        {
            get => currentPath;
            set
            {
                currentPath = value;
                backUpPath = Path.Combine(currentPath, BackupManager.BackupFileName);
            }
        }

        public static DateTime LastBackupTime { get => lastBackupTime; set => lastBackupTime = value; }

        public static void InitBackUpManager()
        {
            LastBackupTime = DateTime.Now;
        }

        public static void RestoreFiles(DateTime dateTime)
        {
            var changesSet = dateTime < lastBackupTime
                ?
                from change in changes
                where change.DateTime >= dateTime
                && change.DateTime <= lastBackupTime
                select change
                :
                from change in changes
                where change.DateTime <= dateTime
                && change.DateTime >= lastBackupTime
                orderby change.DateTime descending
                select change;
            if(changes.Count == 0)
            {
                return;
            }
            int index;
            Change[] array = changesSet.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                index = Changes.IndexOf(array[i]);
                switch (array[i].ChangeType)
                {
                    case ChangeType.Create:
                        FileHelper.DeleteFile(array[i].FullPath);
                        Changes[index].ChangeType = ChangeType.Delete;
                        break;
                    case ChangeType.Change:
                        break;
                    case ChangeType.Rename:
                        FileHelper.RenameFile(array[i].FullPath, array[i].PreviewFullPath);
                        Changes[index].ChangeType = ChangeType.Rename;
                        var temp = Changes[index].FullPath;
                        Changes[index].FullPath = Changes[index].PreviewFullPath;
                        Changes[index].PreviewFullPath = temp;
                        break;
                    case ChangeType.Delete:
                        FileHelper.CreateFile(array[i].FullPath);
                        Changes[index].ChangeType = ChangeType.Create;
                        break;
                }
            }
            /*foreach (var item in changesSet)
            {   
                index = Changes.IndexOf(item);
                switch (item.ChangeType)
                {
                    case ChangeType.Create:
                        FileHelper.DeleteFile(item.FullPath);
                        Changes[index].ChangeType = ChangeType.Delete;
                        break;
                    case ChangeType.Change:
                        break;
                    case ChangeType.Rename:
                        FileHelper.RenameFile(item.FullPath, item.PreviewFullPath);
                        Changes[index].ChangeType = ChangeType.Rename;
                        var temp = Changes[index].FullPath;
                        Changes[index].FullPath = Changes[index].PreviewFullPath;
                        Changes[index].PreviewFullPath = temp;
                        break;
                    case ChangeType.Delete:
                        FileHelper.CreateFile(item.FullPath);
                        Changes[index].ChangeType = ChangeType.Create;
                        break;
                }
            }*/
            LastBackupTime = dateTime;
        }

        public static void Watch()
        {
            Watcher.Run();
        }

        public static void StopWatch()
        {
            Watcher.Stop();
        }

        public static bool ParseChanges()
        {
            lastBackupTime = DateTime.Now;
            if (changes == null)
            {
                changes = new List<Change>();
            }

            FileHelper.OpenReaderStream();
            try
            {
                while (FileHelper.ReadStringFromFile(out string readedString))
                {
                    List<string> parameters = new List<string>(readedString.Split('#'));
                    Change change = new Change(Convert.ToDateTime(parameters[0]), (ChangeType)Convert.ToInt32(parameters[1]), parameters[2]);
                    if (change.ChangeType == ChangeType.Rename)
                    {
                        change.PreviewFullPath = parameters[3];
                    }

                    Changes.Add(change);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                FileHelper.CloseReaderStream();
            }

            return true;
        }

        internal static void SaveChanges()
        {
            FileHelper.CreateBackUpFile();
            foreach (var item in changes)
            {
                FileHelper.AppendToFile(item);
            }
        }
    }
}