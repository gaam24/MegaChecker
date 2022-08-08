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
        public static string version = "beta 0.1";
        public static string author = "gam24";

        public static string console_title = string.Format("MegaChecker by {0} - {1}", author, version);

        public static readonly string accounts_folder_path = "./Accounts";
        public static readonly string backup_folder_path = "./Accounts";

        public static void CheckFolders()
        {
            // Accounts folder
            if (!Directory.Exists(accounts_folder_path))
            {
                Directory.CreateDirectory(accounts_folder_path);
            }

            // Backup folder
            if (!Directory.Exists(backup_folder_path))
            {
                Directory.CreateDirectory(backup_folder_path);
            }
        }
    }
}
