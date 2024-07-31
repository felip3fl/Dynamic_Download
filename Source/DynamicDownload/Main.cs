﻿using Core;

namespace DynamicDownload
{
    class TestClass
    {
        [STAThread]
        static void Main(string[] args)
        {
            DownloadService ytdlp = new DownloadService();
            var linkToDownload = "";

            if (validLinkFromParameters(args))
            {
                linkToDownload = getLinkFromParameters(args);
            }
            else
            {
                linkToDownload = getClipboardText();
            };

            var urlWithoutParameters = RemoveAdditionalParameters(linkToDownload);
            var oi = ytdlp.Download(urlWithoutParameters);
            Console.WriteLine(oi);
        }

        public static string getClipboardText()
        {
            string returnAudioStream = null;
            if (Clipboard.ContainsText())
            {
                returnAudioStream = Clipboard.GetText();
            }
            return returnAudioStream;
        }

        public static string getLinkFromParameters(string[] args)
        {
            return args.FirstOrDefault();
        }

        public static bool validLinkFromParameters(string[] args)
        {
            if (args.FirstOrDefault() == null)
            {
                return false;
            }

            return true;
        }

        private static string RemoveAdditionalParameters(string url)
        {
            string urlWithNoParameters = "";
            int index = url.IndexOf("&");
            if (index >= 0)
                urlWithNoParameters = url.Substring(0, index);
            else
                return url;

            return urlWithNoParameters;
        }
    }


}
