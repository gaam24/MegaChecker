using System.Collections.Generic;
using System.Linq;
using System.Drawing;

using Colorful;

namespace MegaChecker.messages
{
    public class Message
    {
        private string text;
        private Color color;
        private Formatter[] formatters;

        public Message(string text = "Textn't")
        {
            this.text = text;
            this.color = Color.White;
            formatters = null;
        }

        public string GetText()
        {
            return text;
        }

        public Message SetText(string text)
        {
            this.text = text;
            return this;
        }

        public Color GetColor()
        {
            return color;
        }

        public Message SetColor(Color color)
        {
            this.color = color;
            return this;
        }

        public Formatter[] GetFormatters()
        {
            return formatters;
        }

        public Message SetFormatters(Formatter[] formatters)
        {
            this.formatters = formatters;
            return this;
        }

        public Message AddFormatter(object target, Color color)
        {
            if (formatters == null) formatters = new Formatter[] { };

            List<Formatter> frs = formatters.ToList();
            frs.Add(new Formatter(target, color));

            formatters = frs.ToArray();

            return this;
        }
    }
}
