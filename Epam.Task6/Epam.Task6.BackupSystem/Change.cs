﻿using System;
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

        public Change(DateTime dateTime, ChangeType changeType, string fullPath)
        {
            this.dateTime = dateTime;
            this.changeType = changeType;
            this.fullPath = fullPath;
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

        public override string ToString()
        {
            string result = $"{DateTime.Now.ToString("yyyy.MM.dd HH:mm")}#{(int)ChangeType}#{fullPath}";
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
                    break;
            }

            return result;
        }
    }
}
