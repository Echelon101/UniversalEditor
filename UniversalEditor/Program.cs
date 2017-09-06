using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Windows.Forms;
using RestSharp;
using RestSharp.Authenticators;

namespace UniversalEditor
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());

            
            
        }
        public static void API()
        {
            string path = @"c:\tmp\logger.txt";
            var client = new RestClient();
            client.BaseUrl = new Uri("http://www.addressscout.de");
            client.Authenticator = new HttpBasicAuthenticator("usr_cron", "Wr7wqjKubaCriwCdxXFs22BrtBYYd3");

            var request = new RestRequest();
            request.Resource = "api/articles/1";

            IRestResponse response = client.Execute(request);

            using (FileStream fs = File.Create(path))
            {
                AddText(fs, response.Content);
            }
            
        }
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}
