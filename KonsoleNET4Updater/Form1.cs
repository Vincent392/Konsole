using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;

namespace KonsoleNET4Updater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string curDir = Directory.GetCurrentDirectory();
            this.webBrowser1.Url = new Uri(String.Format("file:///{0}/konsoleupdate.html", curDir));
            //code yonked from https://www.youtube.com/watch?v=zQDKxMjrX80 with slight edits
            WebClient webClient = new WebClient();
            var client = new WebClient();

            try { 
                Thread.Sleep(5000);
                File.Delete(@".\KonsoleNET4.exe");
                client.DownloadFile("yourhostinglink", @"KonsoleNET4Update.zip");
                string zipPath = @".\KonsoleNET4Update.zip";
                string extractPath = @".\";
                string arguments = "e " + extractPath + " -o" + zipPath;
                Process.Start(@".\updatethings\7z.exe", arguments);
            //ZipFile.ExtractToDirectory(zipPath, extractPath);
            File.Delete(@".\KonsoleNET4Update.zip");
                Process.Start(@".\KonsoleNET4.exe");
                this.Close();
            }
            catch
            {
                //Process.Start("KonsoleNET4.exe");
                //this.Close();
            }
        }
    }
}
