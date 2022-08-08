using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaChecker.data.supports
{
    public static class GoogleDrive
    {
        public static string GetRaw(string url)
        {
            List<string> url_list = new List<string>(); // Account list
            string final = url;

            // Google drive
            string gd_url_temp = LinkManager.GoogleDrive;
            string gd_raw_temp = "https://drive.google.com/uc?export=download&id={0}";
            
            string gd_url = url.Replace(gd_url_temp, "");
            string id = gd_url.Split('/')[0];

            return string.Format(gd_raw_temp, id);
        }
    }
}
