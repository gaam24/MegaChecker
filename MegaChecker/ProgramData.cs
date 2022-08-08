using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MegaChecker.utils;

namespace MegaChecker
{
    public static class ProgramData
    {
        public static readonly string Version = "beta 1.0";
        public static readonly string Author = "gam24";

        public static string NewestVersion = Version;
        public static readonly string VersionURL = "https://raw.githubusercontent.com/gaam24/MegaChecker/main/version.txt";

        public static readonly string ConsoleTitle = string.Format("MegaChecker by {0} - {1}", Author, Version);

        public static readonly string AccountsFolderPath = "./Accounts";
        //public static readonly string BackupFolderPath = "./Backup";

        public static void CheckVersion()
        {
            NewestVersion = NetworkUtils.ReadFromURL(VersionURL).First();
        }

        public static void CheckFolders()
        {
            // Accounts folder
            if (!Directory.Exists(AccountsFolderPath))
            {
                Directory.CreateDirectory(AccountsFolderPath);
            }

            // Backup folder
            /*if (!Directory.Exists(BackupFolderPath))
            {
                Directory.CreateDirectory(BackupFolderPath);
            }*/
        }
    }
}
