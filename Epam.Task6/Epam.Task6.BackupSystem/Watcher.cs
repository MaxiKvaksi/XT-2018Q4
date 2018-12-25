using System;
using System.IO;
using System.Security.Permissions;

namespace Epam.Task6.BackupSystem
{
    public class Watcher
    {
        private static int changesCounter = 0;
<<<<<<< HEAD
        private static FileSystemWatcher watcher;
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Run()
=======
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Run(string path)
>>>>>>> parent of e53564f... Task6(ver0.2)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.IncludeSubdirectories = true;
<<<<<<< HEAD
            watcher.Path = BackupManager.CurrentPath;
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
=======
            watcher.Path = path;
            watcher.NotifyFilter = NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
>>>>>>> parent of e53564f... Task6(ver0.2)
            watcher.Filter = "*.txt";

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.EnableRaisingEvents = true;
            changesCounter = 0;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
            Console.WriteLine("Type 'q' to stop listen");
=======
            /*Console.WriteLine("Type 'q' to stop listen");
>>>>>>> parent of a705b46... Task6(ver2.1)
=======
            /*Console.WriteLine("Type 'q' to stop listen");
>>>>>>> parent of a705b46... Task6(ver2.1)
            while (Console.Read() != 'q');
            watcher.Changed -= OnChanged;
            watcher.Created -= OnChanged;
            watcher.Deleted -= OnChanged;
<<<<<<< HEAD
<<<<<<< HEAD
            watcher.Renamed -= OnRenamed;
>>>>>>> parent of e53564f... Task6(ver0.2)
=======
            watcher.Renamed -= OnRenamed;*/
>>>>>>> parent of a705b46... Task6(ver2.1)
=======
            watcher.Renamed -= OnRenamed;*/
>>>>>>> parent of a705b46... Task6(ver2.1)
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            if (!FileHelper.IsBackUpFile(e.FullPath) && Path.GetDirectoryName(e.FullPath)
                != BackupManager.BackupFolderPath)
            {
                Change change = new Change(DateTime.Now, (ChangeType)(int)e.ChangeType, e.FullPath);
                if (change.ChangeType == ChangeType.Change)
                {
                    BackupManager.AddInnerChange(e.FullPath);
                }

                FileHelper.AppendChangeToFile(change);
            }
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            if (!FileHelper.IsBackUpFile(e.FullPath))
            {
                FileHelper.AppendChangeToFile(new Change(DateTime.Now, (ChangeType)(int)e.ChangeType, e.FullPath, e.OldFullPath));
            }
        }

<<<<<<< HEAD
        internal static void Stop()
        {
            if (watcher != null)
            {
                watcher.Changed -= OnChanged;
                watcher.Created -= OnChanged;
                watcher.Deleted -= OnChanged;
                watcher.Renamed -= OnRenamed;
            }
=======
        private static void UpdateChangesCounter()
        {
            changesCounter++;
            Console.Write($"\rChanges:{changesCounter}");
>>>>>>> parent of e53564f... Task6(ver0.2)
        }
    }
}
