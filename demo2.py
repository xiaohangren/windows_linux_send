#window远程操作Linux读取文件内容
import paramiko
hostname = "192.168.192.129"
port = 22
username = "finn"
password = "Wzz258258"

client = paramiko.SSHClient()#创建一个SSH客户端client对象
client.set_missing_host_key_policy(paramiko.AutoAddPolicy())#自动添加添加公钥策略
client.connect(hostname, port, username, password, compress=True)#通过用户名和密码方式登录主机

sftp_client = client.open_sftp()#创建一个sft会话并返回一个SFTPClient对象
remote_file = sftp_client.open("/home/finn/桌面/picture/sample.txt") #文件路径
try:
  for line in remote_file:
    print(line.strip())
finally:
  remote_file.close()