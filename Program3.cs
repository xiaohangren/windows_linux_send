//远程上传单个文件
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System.IO;
using System;
namespace demo3
{
    class Program3
    {
        static void Main(string[] args)
        {
            string host = "192.168.192.129";
            int port = 22;
            string username = "finn";
            string password = "Wzz258258";
            string pathRemoteFile = "/home/finn/桌面/picture/IMG_0798.JPG";
            string pathLocalFile = "C:/Users/lenovo/Desktop/picture/IMG_0798.JPG";
            using (SftpClient sftp = new SftpClient(host, port, username, password))
            {
                try
                {
                    sftp.Connect();
                    Console.WriteLine("Uploading {0}", pathLocalFile);
                    using (Stream fileStream = File.OpenRead(pathLocalFile))
                    {
                        sftp.UploadFile(fileStream, pathRemoteFile);
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
