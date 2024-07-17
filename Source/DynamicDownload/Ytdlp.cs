﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DynamicDownload
{
    public class Ytdlp
    {
        readonly string executableAddress = "yt-dlp";
        readonly string parameters = "--check-formats -f \"bestvideo[height<=1440]+bestaudio/best[height<=1440]\" -o \"%(title)s.%(ext)s\" ";

        public bool Download(string videoAddress)
        {
            Console.Clear();
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = executableAddress;
            startInfo.WorkingDirectory = @"D:\Videos\Youtube Temp\";
            startInfo.Arguments = parameters + videoAddress;
            process.StartInfo = startInfo;
            process.Start();

            return true;
        }
    }
}
