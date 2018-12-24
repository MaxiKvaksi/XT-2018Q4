using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task6.BackupSystem
{
    public class MyDirectory : FSObject
    {
        Dictionary<int, FSObject> directories;
        public Dictionary<int, FSObject> Directories { get => directories ??(directories = new Dictionary<int, FSObject>()); set => Directories = value; }

        public MyDirectory(int id, string path) : base(id, path)
        {
        }

        public void AddFile(string path, string content)
        {
            int index = Directories.Any() ? Directories.Keys.Max() + 1 : 0;
            Directories.Add(index, new MyFile(index, path, content));
        }

        public void AddDirectory(string path)
        {
            int index = Directories.Any() ? Directories.Keys.Max() + 1 : 0;
            Directories.Add(index, new MyDirectory(index, path));
        }
    }
}
