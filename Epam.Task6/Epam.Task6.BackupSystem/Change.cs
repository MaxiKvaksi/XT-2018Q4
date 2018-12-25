using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task6.BackupSystem
{
    public class Change
    {
        private ChangeType changeType;
        private DateTime dateTime;
        private string fullPath;
        private string previewFullPath;
        private string changedFilePath;
        private string hash;

        public Change(DateTime dateTime, ChangeType changeType, string fullPath)
        {
            this.dateTime = dateTime;
            this.changeType = changeType;
            this.fullPath = fullPath;
            this.hash = Utils.GetHash(fullPath + dateTime);
        }

        public Change(DateTime dateTime, ChangeType changeType, string fullPath, string previewFullPath) 
            : this(dateTime, changeType, fullPath)
        {
            this.PreviewFullPath = previewFullPath;
        }

        public DateTime DateTime { get => this.dateTime; set => this.dateTime = value; }

        public string FullPath { get => this.fullPath; set => this.fullPath = value; }

        public ChangeType ChangeType { get => this.changeType; set => this.changeType = value; }

        public string PreviewFullPath { get => this.previewFullPath; set => this.previewFullPath = value; }

        public string ChangedFilePath { get => this.changedFilePath; set => this.changedFilePath = value; }

        public string Hash { get => this.hash; set => this.hash = value; }

        public override string ToString()
        {
            string result = $"{hash}#{DateTime.Now.ToString("yyyy.MM.dd HH:mm")}#{(int)ChangeType}#{fullPath}";
            switch (this.changeType)
            {
                case ChangeType.Create:
                    break;
                case ChangeType.Delete:
                    break;
                case ChangeType.Rename:
                    result = string.Concat(result, $"#{PreviewFullPath}");
                    break;
                case ChangeType.Change:
                    result = string.Concat(result, $"#{ChangedFilePath}");
                    break;
            }

            return result;
        }
    }
}
