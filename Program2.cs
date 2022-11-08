//远程下载单个文件
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System.IO;
using System;
namespace demo2
{
    class Program2
    {
        
        static void Main(string[] args)
        {
            string host = "192.168.192.129";
            int port = 22;
            string username = "finn";
            string password = "Wzz258258";

            // Path to file on SFTP server
            string pathRemoteFile = "/home/finn/桌面/picture/IMG_0797.JPG";
            // Path where the file should be saved once downloaded (locally)
            //string pathLocalFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "IMG_0798.JPG");
            string pathLocalFile = "C:/Users/lenovo/Desktop/picture/IMG_0797.JPG";
            using (SftpClient sftp = new SftpClient (host,port,username, password))
            {
                try
                {
                    sftp.Connect();
                    Console.WriteLine("Downloading {0}", pathRemoteFile);
                    using (Stream fileStream = File.OpenWrite(pathLocalFile))
                    {
                        sftp.DownloadFile(pathRemoteFile, fileStream);
                    }

                    sftp.Disconnect();
                }
                catch (Exception er)
                {
                    Console.WriteLine("An exception has been caught " + er.ToString());
                }
            }
        }

    
    }
}
