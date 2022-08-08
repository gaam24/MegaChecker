using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using MegaChecker.data.supports;
using MegaChecker.utils;

namespace MegaChecker.data
{
    public static class AccountManager
    {
        // List with all accounts
        public static Dictionary<string, List<Account>> Accounts = new Dictionary<string, List<Account>>();

        public static void LoadFromFiles()
        {
            IEnumerable<string> files = Directory
                            .EnumerateFiles(ProgramData.AccountsFolderPath, "*.*", SearchOption.AllDirectories)
                            .Where(file => file.EndsWith(".txt", StringComparison.OrdinalIgnoreCase));

            foreach (string file in files)
            {
                List<string> lines = new List<string>(File.ReadAllLines(file));
                string file_name = file.Split('\\')[1];
                bool long_comment = false;

                for (int i = 0; i < lines.Count; i++)
                {
                    string line = lines[i];

                    if (string.IsNullOrEmpty(line)) continue; // Skip empty line
                    if (line.StartsWith("//")) continue; //Single comment
                    if (line.StartsWith("/*")) // Long comment - Start
                    {
                        long_comment = true;
                        continue;
                    }
                    if (line.StartsWith("*/") || line.EndsWith("*/")) // Long comment - Stop
                    {
                        long_comment = false;
                        continue;
                    }
                    if (long_comment) continue;

                    // Link support
                    if (line.StartsWith("link:"))
                    {
                        List<string> url_list = LoadFromURL(line.Replace("link:", ""));
                        if (url_list.Count > 0) lines.AddRange(url_list);

                        continue;
                    }

                    // Parse line
                    string[] split = line.Split(':');

                    string email = split[0];
                    string password = split[1];

                    if (email.Contains('@'))
                    {
                        if (!Accounts.ContainsKey(file_name)) Accounts.Add(file_name, new List<Account>());
                        Accounts[file_name].Add(new Account(email, password));
                    }
                }
            }
        }

        public static int LoadedAccounts()
        {
            int count = 0;
            foreach (List<Account> file in Accounts.Values)
            {
                count += file.Count;
            }

            return count;
        }

        //TODO: Contains Ignore Case
        private static List<string> LoadFromURL(string url)
        {
            if (url.Contains(LinkManager.GoogleDrive)) url = GoogleDrive.GetRaw(url); //GoogleDrive

            return NetworkUtils.ReadFromURL(url);
        }
    }
}
