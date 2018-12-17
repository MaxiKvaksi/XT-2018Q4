using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task6.BackupSystem
{
    public enum ChangeType
    {
        Create = 1,
        Delete = 2,
        Rename = 8,
        Change = 4
    }
}
