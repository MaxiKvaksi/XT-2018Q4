using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task6.BackupSystem
{
    abstract public class FSObject
    {
        public int Id { get; set; }
        public string Path { get; set; }

        protected FSObject(int id, string path)
        {
            this.Id = id;
            this.Path = path;
        }
    }
}
