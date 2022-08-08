using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MegaChecker.utils;

namespace MegaChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = ProgramData.console_title;

            ConsoleMenu.MainMenu();

            Console.ReadLine();
        }
    }
}
