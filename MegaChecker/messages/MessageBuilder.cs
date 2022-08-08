using System.Collections.Generic;
using System.Linq;
using System.Drawing;

using Console = Colorful.Console;

namespace MegaChecker.messages
{
    public class MessageBuilder
    {
        private List<Message> Messages = new List<Message>();
        private Color DefaultColor = Color.White;

        public MessageBuilder SetDefaultColor(Color color)
        {
            DefaultColor = color;
            return this;
        }

        public Message Add(string text = "Textn't")
        {
            Messages.Add(new Message(text).SetColor(DefaultColor));
            return Messages.Last();
        }

        public void SendOne(string text)
        {
            Console.WriteLine(text, DefaultColor);
        }

        public void Send()
        {
            foreach (Message message in Messages)
            {
                if (message.GetFormatters() != null && message.GetFormatters().Length > 0)
                    Console.WriteLineFormatted(message.GetText(), message.GetColor(), message.GetFormatters());
                else
                    Console.WriteLine(message.GetText(), message.GetColor());
            }

            Messages.Clear();
        }
    }
}
