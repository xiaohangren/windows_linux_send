//远程同步window_Linux文件夹
using System;
using System.IO;
using Renci.SshNet;
using System.Linq;
using System.Collections.Generic;
namespace demo1
{
    class Program1
    {
        static void Main(string[] args)
        {
            
            windows_linux_send();

        }
        public static void windows_linux_send()
        {
            string host = "192.168.192.130";//linux IP
            int port = 22;//SSH 端口
            string username = "finn";//linux 用户名
            string password = "Wzz258258";//linux 密码
            string remoteDirectory = "/home/finn/桌面/picture/";//linux 文件夹路径
            string localDirectory = "C:/Users/lenovo/Desktop/picture";//windows 文件夹路径
          
            while (true)
            {
                List<string> remoteList = new List<string>();//linux 文件夹下文件名列表
                List<string> localList = new List<string>();//windows 文件夹下文件名列表
                using (SftpClient sftp = new SftpClient(host, port, username, password))
                {
                    try
                    {
                        sftp.Connect();
                        var remoteFiles = sftp.ListDirectory(remoteDirectory);//获取linux文件夹下文件名列表
                        foreach (var file in remoteFiles)
                            remoteList.Add(file.Name);

                        //Console.WriteLine("..........remoteList............");
                        //for (int i = 0; i < remoteList.Count; i++)
                        //{
                        //    Console.WriteLine(remoteList[i]);
                        //}


                        DirectoryInfo root = new DirectoryInfo(localDirectory);//获取windows文件夹下文件名列表
                        foreach (FileInfo file in root.GetFiles())
                            localList.Add(file.Name);

                        //Console.WriteLine("..........localList............");
                        //for (int i = 0; i < localList.Count; i++)
                        //{
                        //    Console.WriteLine(localList[i]);
                        //}


                        List<string> sendList = localList.Except(remoteList).ToList();//取in_windows_not_linux 的文件名列表

                        //Console.WriteLine("..........sendList............");
                        //for (int i = 0; i < sendList.Count; i++)
                        //{
                        //    Console.WriteLine(sendList[i]);
                        //}

                        for (int i = 0; i < sendList.Count; i++)//循环单个传输文件
                        {
                            string pathLocalFile = Path.Combine(localDirectory, sendList[i]);//Windows上待上传文件完整路径
                            string pathRemoteFile = Path.Combine(remoteDirectory, sendList[i]);//Linux上待接受文件完整路径
                            Stream fileStream = File.OpenRead(pathLocalFile);
                            sftp.UploadFile(fileStream, pathRemoteFile);
                            Console.WriteLine($"{sendList[i]}was successfully sent!");

                        }

                        sftp.Disconnect();//断开SSH连接
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("An exception has been caught " + e.ToString());
                    }
                }
            }
        }           
    }
}