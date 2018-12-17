using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task6.BackupSystem
{
    public class Utils
    {
        public static bool ValidPath(string path)
        {
            if ((path == null) || (path.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                || path.Length < 2)
            {
                return false;
            }

            var directoryInfo = new DirectoryInfo(path);
            return directoryInfo.Exists;
        }

        public static string GetElementHash()
        {
            string hash = string.Empty;
            return hash;
        }
    }
}
