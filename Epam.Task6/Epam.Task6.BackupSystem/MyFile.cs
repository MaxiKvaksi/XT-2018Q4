using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task6.BackupSystem
{
    class MyFile : FSObject
    {
        private List<Change> changes;
        public List<Change> Changes { get => Changes ?? (changes = new List<Change>()); set => Changes = value; }
        public string Content { get; set; }

        public MyFile(int id, string path, string content) : base(id, path)
        {
            this.Content = content;
        }
    }
}
