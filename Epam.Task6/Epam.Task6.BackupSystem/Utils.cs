using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task6.BackupSystem
{
    public static class Utils
    {
        public static string GetHash(string raw)
        {
            using (var md5 = MD5.Create())
            {
                md5.Initialize();
                return BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(raw)));
            }
        }
    }
}
