using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaChecker.data
{
    public class Account
    {
        public string Login { get; }
        public string Password { get; }

        public long Used;
        public long Total;

        public Account() { }

        public Account(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
