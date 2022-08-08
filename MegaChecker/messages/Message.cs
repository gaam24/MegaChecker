using System.Collections.Generic;
using System.Linq;
using System.Drawing;

using Colorful;

namespace MegaChecker.messages
{
    public class Message
    {
        private string Text;
        private Color Color;
        private Formatter[] Formatters;

        public Message(string text = "Textn't")
        {
            Text = text;
            Color = Color.White;
            Formatters = null;
        }

        public string GetText()
        {
            return Text;
        }

        public Message SetText(string text)
        {
            this.Text = text;
            return this;
        }

        public Color GetColor()
        {
            return Color;
        }

        public Message SetColor(Color color)
        {
            this.Color = color;
            return this;
        }

        public Formatter[] GetFormatters()
        {
            return Formatters;
        }

        public Message SetFormatters(Formatter[] formatters)
        {
            this.Formatters = formatters;
            return this;
        }

        public Message AddFormatter(object target)
        {
            return AddFormatter(target, Color);
        }

        public Message AddFormatter(object target, Color color)
        {
            if (Formatters == null) Formatters = new Formatter[] { };

            List<Formatter> frs = Formatters.ToList();
            frs.Add(new Formatter(target, color));

            Formatters = frs.ToArray();

            return this;
        }
    }
}
