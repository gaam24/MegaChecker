using System.Drawing;
using MegaChecker.data;
using MegaChecker.messages;

namespace MegaChecker.utils
{
    public static class ConsoleMenu
    {
        public static void MainMenu(bool clear_console = true)
        {
            MessageBuilder builder = new MessageBuilder();
            builder.SetDefaultColor(Color.Orange);
            builder.ClearConsole();

            // Data
            builder.Add(" ");
            builder.Add("Załadowane konta: {0} ({1})").AddFormatter(AccountManager.LoadedAccounts(), Color.Purple).AddFormatter(AccountManager.Accounts.Count, Color.Purple);
            builder.Add("Wersja: {0}").AddFormatter(ProgramData.Version, Color.Purple);
            if (!ProgramData.Version.Equals(ProgramData.NewestVersion))
            {
                builder.Add("Dostepna aktualizacja! {0}").SetColor(Color.Green).AddFormatter(string.Format("(Nowa wersja - {0})", ProgramData.NewestVersion), Color.Aqua);
            }
            builder.Add(" ");
            
            // Options
            builder.Add("Wybierz, co chcesz zrobić:");
            builder.Add(" - 1. {0}").AddFormatter("Pokaż załadowane konta", Color.Green);
            builder.Add(" ");
            builder.Add(" - s. {0}").AddFormatter("Ustawienia", Color.Green);

            builder.Send();
        }
    }
}
