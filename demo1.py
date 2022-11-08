#window远程操作Linux执行终端命令
import paramiko
hostname = "192.168.192.130"
port = 22
username = "finn"
password = "Wzz258258"#服务器信息，主机名（IP地址）、端口号、用户名及密码
client = paramiko.SSHClient()#创建一个SSH客户端client对象
client.set_missing_host_key_policy(paramiko.AutoAddPolicy())#自动添加添加公钥策略
client.connect(hostname, port, username, password, compress=True)#通过用户名和密码方式登录主机
stdin, stdout, stderr = client.exec_command('ls /')#执行Linux终端命令
print(stdout.read())
