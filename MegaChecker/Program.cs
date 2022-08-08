using System;
using System.Drawing;

using MegaChecker.messages;
using MegaChecker.data;
using MegaChecker.utils;

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

            //Check newest version
            builder.SendOne(" - Sprawdzanie wersji...");
            ProgramData.CheckVersion();

            ConsoleMenu.MainMenu();

            Console.ReadLine();
        }
    }
}
