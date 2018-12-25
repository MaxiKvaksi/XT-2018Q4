using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Epam.Task6.BackupSystem
{
    public static class BackupManager
    {
        public const string BackupFileName = "backup.txt";
        public const string BackupFolderName = "backupFolder";
        private static DateTime lastBackupTime;
        private static string backupPath;
        private static string backupFolderPath;
        private static string currentPath;
        private static List<Change> changes = new List<Change>();
        private static Dictionary<string, List<InnerChange>> innerChanges = new Dictionary<string, List<InnerChange>>();

        public static List<Change> Changes { get => changes; set => changes = value; }

        public static string BackupPath { get => backupPath; set => backupPath = value; }

        public static string CurrentPath
        {
            get => currentPath;
            set
            {
                currentPath = value;
                backupPath = Path.Combine(currentPath, BackupFileName);
                backupFolderPath = Path.Combine(CurrentPath, BackupFolderName);
            }
        }

        public static DateTime LastBackupTime { get => lastBackupTime; set => lastBackupTime = value; }

        public static string BackupFolderPath { get => backupFolderPath; set => backupFolderPath = value; }

        public static Dictionary<string, List<InnerChange>> InnerChanges { get => innerChanges; set => innerChanges = value; }

        public static void InitBackUpManager()
        {
            LastBackupTime = DateTime.Now;
        }

        public static void RestoreFiles(DateTime dateTime)
        {
            bool toFuture = dateTime < lastBackupTime;
            var changesSet = toFuture
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
            if (changes.Count == 0)
            {
                return;
            }

            int index;
            Change[] array = changesSet.ToArray();
            foreach (var item in changesSet)
            {   
                index = Changes.IndexOf(item);
                Change change = Changes[index];
                switch (item.ChangeType)
                {
                    case ChangeType.Create:
                        FileHelper.DeleteFile(item.FullPath);
                        Changes[index].ChangeType = ChangeType.Delete;
                        break;
                    case ChangeType.Change:
                        try
                        {
                            int indexInnerChanges = innerChanges[change.Hash].IndexOf(innerChanges[change.Hash].Find(x => x.DateTime == change.DateTime));
                            if (indexInnerChanges - 1 > 0 || indexInnerChanges + 1 < innerChanges[change.Hash].Count)
                            {
                                indexInnerChanges += toFuture ? 1 : -1;
                            }

                            InnerChange innerChange = innerChanges[change.Hash][indexInnerChanges];
                            FileHelper.CopyFile(innerChange.CurrentVerFilePath, change.FullPath);
                        }
                        catch (Exception)
                        {
                            throw;
                        }

                        break;
                    case ChangeType.Rename:
                        FileHelper.RenameFile(item.FullPath, item.PreviewFullPath);
                        change.ChangeType = ChangeType.Rename;
                        var temp = Changes[index].FullPath;
                        change.FullPath = Changes[index].PreviewFullPath;
                        Changes[index].PreviewFullPath = temp;
                        break;
                    case ChangeType.Delete:
                        FileHelper.CreateFile(item.FullPath);
                        Changes[index].ChangeType = ChangeType.Create;
                        break;
                }
            }

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

            FileHelper.OpenReaderStream(backupPath);
            try
            {
                while (FileHelper.ReadStringFromFile(out string readedString))
                {
                    List<string> parameters = new List<string>(readedString.Split('#'));
                    Change change = new Change(Convert.ToDateTime(parameters[1]), (ChangeType)Convert.ToInt32(parameters[2]), parameters[3])
                    {
                        Hash = parameters[0]
                    };
                    if (change.ChangeType == ChangeType.Rename)
                    {
                        change.PreviewFullPath = parameters[4];
                    }

                    if (change.ChangeType == ChangeType.Change)
                    {
                        try
                        {
                            change.ChangedFilePath = parameters[4] + '#' + parameters[5];
                        }
                        catch (Exception)
                        {
                            continue;
                        }

                        if (InnerChanges.ContainsKey(change.Hash))
                        {
                            InnerChanges[change.Hash].Add(new InnerChange(change.DateTime, change.ChangedFilePath));
                        }
                        else
                        {
                            InnerChanges.Add(change.Hash, new List<InnerChange>() { new InnerChange(change.DateTime, change.ChangedFilePath) });
                        }
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

            foreach (var item in InnerChanges)
            {
                item.Value.OrderByDescending(i => i.DateTime);
            }

            return true;
        }

        public static void AddInnerChange(string filename)
        {
            DateTime dateTime = DateTime.Now;
            string fileCopyName = FileHelper.GenerateDateTimeFileName(filename, dateTime);
            Change change = new Change(dateTime, ChangeType.Change, filename)
            {
                ChangedFilePath = fileCopyName
            };
            FileHelper.AppendChangeToFile(change);
            FileHelper.CopyFile(change.FullPath, Path.Combine(BackupManager.backupFolderPath, Path.GetFileName(fileCopyName)));
        }

        private static string PrepareFileName(string raw)
        {
            string[] splited = raw.Split('#');
            int i = splited[0].LastIndexOf(@"\", splited[0].Length);
            return splited[0].Substring(0, i) + "\\" + splited[1];
        }
    } 
}