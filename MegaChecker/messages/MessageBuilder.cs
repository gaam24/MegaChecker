using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Colorful;
using Console = Colorful.Console;

//TODO: Change?
namespace MegaChecker.messages
{
    public class MessageBuilder
    {
        private List<Message> messages = new List<Message>();
        private Color default_color;

        public MessageBuilder SetDefaultColor(Color color)
        {
            default_color = color;
            return this;
        }

        public Message Add(string text = "Textn't")
        {
            Message message = new Message(text);
            if (default_color != null) message.SetColor(default_color);

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
        }
    }
}
