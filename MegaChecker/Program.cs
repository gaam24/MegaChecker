using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using MegaChecker.messages;
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

            //Chek folders
            builder.SendOne(" - Sprawdzanie plików...");
            ProgramData.CheckFolders();

            //ConsoleMenu.MainMenu();

            Console.ReadLine();
        }
    }
}
