using System;
using System.IO;
using System.Security.Permissions;

namespace Epam.Task6.BackupSystem
{
    class Watcher
    {
        private static int changesCounter = 0;
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Run(string path)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.IncludeSubdirectories = true;
            watcher.Path = path;
            watcher.NotifyFilter = NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "*.txt";

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.EnableRaisingEvents = true;
            changesCounter = 0;
            Console.WriteLine("Type 'q' to stop listen");
            while (Console.Read() != 'q');
            watcher.Changed -= OnChanged;
            watcher.Created -= OnChanged;
            watcher.Deleted -= OnChanged;
            watcher.Renamed -= OnRenamed;
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            if (!FileHelper.IsBackUpFile(e.FullPath))
            {
                UpdateChangesCounter();
                FileHelper.AppendToFile(new Change(DateTime.Now, (ChangeType)(int)e.ChangeType, e.FullPath));
            }
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            if (!FileHelper.IsBackUpFile(e.FullPath))
            {
                UpdateChangesCounter();
                FileHelper.AppendToFile(new Change(DateTime.Now, (ChangeType)(int)e.ChangeType, e.FullPath, e.OldFullPath));
            }
        }

        private static void UpdateChangesCounter()
        {
            changesCounter++;
            Console.Write($"\rChanges:{changesCounter}");
        }
    }
}
