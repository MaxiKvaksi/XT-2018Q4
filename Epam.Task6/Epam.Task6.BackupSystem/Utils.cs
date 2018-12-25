using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Linq;
using System.Security.Cryptography;
=======
using System.IO;
using System.Linq;
>>>>>>> parent of e53564f... Task6(ver0.2)
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task6.BackupSystem
{
<<<<<<< HEAD
    public static class Utils
    {
        public static string GetHash(string raw)
        {
            using (var md5 = MD5.Create())
            {
                md5.Initialize();
                return BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(raw)));
            }
=======
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
>>>>>>> parent of e53564f... Task6(ver0.2)
        }
    }
}
