using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;

using MegaChecker.messages;

namespace MegaChecker.utils
{
    public static class NetworkUtils
    {
        public static List<string> ReadFromURL(string url)
        {
            WebClient client = new WebClient();
            List<string> result = new List<string>();

            try
            {
                string text = client.DownloadString(url);
                string[] split = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                result = new List<string>(split);
            }
            catch (WebException ex)
            {
                MessageBuilder builder = new MessageBuilder().SetDefaultColor(Color.Red);
               
                builder.Add("Nie udało się wczytać kont z linku! (Link: {0}, Powód: {1})")
                    .AddFormatter(url).AddFormatter(ex.Message);

                builder.Send();
            }

            return result;
        }
    }
}
