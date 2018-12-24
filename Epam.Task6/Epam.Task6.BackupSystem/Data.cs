using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task6.BackupSystem
{
    public static class Data
    {
        static Dictionary<int, FSObject> fSObjects;
        private static MyDirectory rootDirectory;

        public static MyDirectory RootDirectory
        {
            get => rootDirectory ?? (rootDirectory = new MyDirectory(0, BackupManager.CurrentPath));
            set => rootDirectory = value; }


        /*public static Dictionary<int, FSObject> FSObjects { get => fSObjects ?? (fSObjects = new Dictionary<int, FSObject>()); set => FSObjects = value; }

         public static int AddDirectory(string path)
         {
             int index = FSObjects.Any() ? FSObjects.Keys.Max() + 1 : 0;
             FSObjects.Add(index, new MyDirectory(index, path));
             return index;
         }   */
    }
}
