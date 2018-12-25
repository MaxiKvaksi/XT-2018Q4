using System;
using System.IO;
using System.Security.Permissions;

namespace Epam.Task6.BackupSystem
{
    public class Watcher
    {
        private static int changesCounter = 0;
        private static FileSystemWatcher watcher;
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Run()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.IncludeSubdirectories = true;
            watcher.Path = BackupManager.CurrentPath;
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "*.txt";

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.EnableRaisingEvents = true;
            changesCounter = 0;
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
        internal static void Stop()
        {
            if (watcher != null)
            {
                watcher.Changed -= OnChanged;
                watcher.Created -= OnChanged;
                watcher.Deleted -= OnChanged;
                watcher.Renamed -= OnRenamed;
            }

        }
    }
}
