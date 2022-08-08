using System.Drawing;

using MegaChecker.messages;

namespace MegaChecker.utils
{
    public static class ConsoleMenu
    {
        public static void MainMenu()
        {
            MessageBuilder builder = new MessageBuilder();
            builder.SetDefaultColor(Color.Orange);

            builder.Add("Wybierz, co chcesz zrobić:");
            builder.Add(" - 1. {0}").AddFormatter("Pokaż załadowane konta", Color.Blue);

            builder.send();
        }
    }
}
