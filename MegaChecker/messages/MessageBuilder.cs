using System.Collections.Generic;
using System.Linq;
using System.Drawing;

using Console = Colorful.Console;

namespace MegaChecker.messages
{
    public class MessageBuilder
    {
        private List<Message> messages = new List<Message>();
        private Color default_color = Color.White;

        public MessageBuilder SetDefaultColor(Color color)
        {
            default_color = color;
            return this;
        }

        public Message Add(string text = "Textn't")
        {
            Message message = new Message(text);
            message.SetColor(default_color);

            messages.Add(message);
            return messages.Last();
        }

        public void send()
        {
            foreach (Message message in messages)
            {
                if (message.GetFormatters() != null && message.GetFormatters().Length > 0)
                {
                    Console.WriteLineFormatted(message.GetText(), message.GetColor(), message.GetFormatters());
                }
                else
                {
                    Console.WriteLine(message.GetText(), message.GetColor());
                }
            }

            messages.Clear();
            default_color = Color.White;
        }
    }
}
