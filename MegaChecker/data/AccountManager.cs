using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                foreach (string line in lines)
                {
                    if (string.IsNullOrEmpty(line)) continue; // Skip empty line
                    if (line.StartsWith("//")) continue; //Single comment
                    if (line.StartsWith("/*")) // Long comment - Start
                    {
                        long_comment = true;
                        continue;
                    }
                    if (line.EndsWith("*/")) // Long comment - Stop
                    {
                        long_comment = false;
                        continue;
                    }
                    if (long_comment) continue;

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
    }
}
