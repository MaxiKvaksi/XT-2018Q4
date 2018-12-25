using System;
using System.Collections.Generic;
using System.IO;
<<<<<<< HEAD
using System.Linq;
=======
>>>>>>> parent of e53564f... Task6(ver0.2)

namespace Epam.Task6.BackupSystem
{
    public static class BackupManager
    {
<<<<<<< HEAD
        public const string BackupFileName = "backup.txt";
        public const string BackupFolderName = "backupFolder";
        private static DateTime lastBackupTime;
        private static string backUpPath;
        private static string currentPath;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        private static List<Change> changes = new List<Change>();
        private static Dictionary<string, List<InnerChange>> innerChanges = new Dictionary<string, List<InnerChange>>();

        public static List<Change> Changes { get => changes; set => changes = value; }

        public static string BackupPath { get => backupPath; set => backupPath = value; }

=======
        public const string BackupFileName = "backup.txt";
        private static List<Change> changes = new List<Change>();
        private static Thread watchThread;

        public static List<Change> Changes { get => changes; set => changes = value; }
        public static string BackUpPath { get => backUpPath; set => backUpPath = value; }
>>>>>>> parent of a705b46... Task6(ver2.1)
=======
        public const string BackupFileName = "backup.txt";
        private static List<Change> changes = new List<Change>();
        private static Thread watchThread;

        public static List<Change> Changes { get => changes; set => changes = value; }
        public static string BackUpPath { get => backUpPath; set => backUpPath = value; }
>>>>>>> parent of a705b46... Task6(ver2.1)
=======
        public const string BackupFileName = "backup.txt";
        private static List<Change> changes = new List<Change>();
        private static Thread watchThread;

        public static List<Change> Changes { get => changes; set => changes = value; }
        public static string BackUpPath { get => backUpPath; set => backUpPath = value; }
>>>>>>> parent of a705b46... Task6(ver2.1)
        public static string CurrentPath
        {
            get => currentPath;
            set
            {
                currentPath = value;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
                backupPath = Path.Combine(currentPath, BackupFileName);
                backupFolderPath = Path.Combine(CurrentPath, BackupFolderName);
=======
                backUpPath = Path.Combine(currentPath, BackupManager.BackupFileName);
>>>>>>> parent of a705b46... Task6(ver2.1)
=======
                backUpPath = Path.Combine(currentPath, BackupManager.BackupFileName);
>>>>>>> parent of a705b46... Task6(ver2.1)
=======
                backUpPath = Path.Combine(currentPath, BackupManager.BackupFileName);
>>>>>>> parent of a705b46... Task6(ver2.1)
            }
        }

        public static DateTime LastBackupTime { get => lastBackupTime; set => lastBackupTime = value; }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
        private static DateTime lastRestoreTime;
        private static List<Change> changes = new List<Change>();

        public static List<Change> Changes { get => changes; set => changes = value; }
>>>>>>> parent of e53564f... Task6(ver0.2)

        public static string BackupFolderPath { get => backupFolderPath; set => backupFolderPath = value; }
=======
>>>>>>> parent of a705b46... Task6(ver2.1)

        public static Dictionary<string, List<InnerChange>> InnerChanges { get => innerChanges; set => innerChanges = value; }
=======
>>>>>>> parent of a705b46... Task6(ver2.1)
=======
>>>>>>> parent of a705b46... Task6(ver2.1)

        public static void InitBackUpManager()
        {
            lastRestoreTime = DateTime.Now;
        }

        public static void RestoreFiles(DateTime dateTime)
        {
<<<<<<< HEAD
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
                Change change = Changes[index];
=======
            foreach (var item in Changes)
            {   
                if (item.DateTime < dateTime)
                {
                    return;
                }

>>>>>>> parent of e53564f... Task6(ver0.2)
                switch (item.ChangeType)
                {
                    case ChangeType.Create:
                        FileHelper.DeleteFile(item.FullPath);
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
<<<<<<< HEAD
                        change.ChangeType = ChangeType.Rename;
                        var temp = Changes[index].FullPath;
                        change.FullPath = Changes[index].PreviewFullPath;
                        Changes[index].PreviewFullPath = temp;
=======
>>>>>>> parent of e53564f... Task6(ver0.2)
                        break;
                    case ChangeType.Delete:
                        FileHelper.CreateFile(item.FullPath);
                        break;
                }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            }
<<<<<<< HEAD

=======
            }*/
>>>>>>> parent of a705b46... Task6(ver2.1)
=======
            }*/
>>>>>>> parent of a705b46... Task6(ver2.1)
=======
            }*/
>>>>>>> parent of a705b46... Task6(ver2.1)
            LastBackupTime = dateTime;
        }

        public static void Watch()
        {
            Watcher.Run();
        }
=======
>>>>>>> parent of e53564f... Task6(ver0.2)

            lastRestoreTime = dateTime;
        }

        public static bool ParseChanges()
        {
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
<<<<<<< HEAD

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
=======
    }
>>>>>>> parent of e53564f... Task6(ver0.2)
}