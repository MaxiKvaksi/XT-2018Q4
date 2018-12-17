using System;
using System.Collections.Generic;
using System.IO;

namespace Epam.Task6.BackupSystem
{
    public static class BackupManager
    {
        private static DateTime lastRestoreTime;
        private static List<Change> changes = new List<Change>();

        public static List<Change> Changes { get => changes; set => changes = value; }

        public static void InitBackUpManager()
        {
            lastRestoreTime = DateTime.Now;
        }

        public static void RestoreFiles(DateTime dateTime)
        {
            foreach (var item in Changes)
            {   
                if (item.DateTime < dateTime)
                {
                    return;
                }

                switch (item.ChangeType)
                {
                    case ChangeType.Create:
                        FileHelper.DeleteFile(item.FullPath);
                        break;
                    case ChangeType.Change:
                        break;
                    case ChangeType.Rename:
                        FileHelper.RenameFile(item.FullPath, item.PreviewFullPath);
                        break;
                    case ChangeType.Delete:
                        FileHelper.CreateFile(item.FullPath);
                        break;
                }
            }

            lastRestoreTime = dateTime;
        }

        public static bool ParseChanges()
        {
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
    }
}