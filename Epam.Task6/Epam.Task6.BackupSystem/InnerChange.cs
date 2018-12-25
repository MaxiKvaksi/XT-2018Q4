using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task6.BackupSystem
{
    public class InnerChange
    {
        private DateTime dateTime;
        private string currentVerFilePath;

        public InnerChange(DateTime dateTime, string curentVerFilePath)
        {
            this.dateTime = dateTime;
            this.currentVerFilePath = curentVerFilePath;
        }

        public string CurrentVerFilePath { get => this.currentVerFilePath; set => this.currentVerFilePath = value; }

        public DateTime DateTime { get => this.dateTime; set => this.dateTime = value; }
    }
}
