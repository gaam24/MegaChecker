using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using MegaChecker.messages;
using MegaChecker.data;

namespace MegaChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console title
            Console.Title = ProgramData.ConsoleTitle;

            //Console message builder
            MessageBuilder builder = new MessageBuilder();
            builder.SetDefaultColor(Color.Orange);

            //Check folders
            builder.SendOne(" - Sprawdzanie plików...");
            ProgramData.CheckFolders();

            //Load accounts from file
            builder.SendOne(" - Ładowanie kont...");
            AccountManager.LoadFromFiles();

            //ConsoleMenu.MainMenu();
            //Check newest version
            builder.SendOne(" - Sprawdzanie wersji...");
            ProgramData.CheckVersion();

            Console.ReadLine();
        }
    }
}
