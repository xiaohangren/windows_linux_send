
//读远程文件夹
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System.IO;
using System;
namespace demo1
{
    class Program1
    {
        static void Main(string[] args)
        {
            string host = "192.168.192.130";
            int port = 22;
            string username = "finn";
            string password = "Wzz258258";
            string remoteDirectory = "/home/finn/桌面/picture/";

            using (SftpClient sftp = new SftpClient(host, port, username, password))
            {
                try
                {
                    sftp.Connect();

                    var files = sftp.ListDirectory(remoteDirectory);

                    foreach (var file in files)
                    {
                        Console.WriteLine(file.Name);
                    }

                    sftp.Disconnect();
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception has been caught " + e.ToString());
                }
            }
        }
    }
}
