#可视化+远程上传
import os.path
import paramiko
from gooey import Gooey, GooeyParser
@Gooey(language='chinese',richtext_controls=True)
def GUI():#可视化获取输入信息
    parser = GooeyParser(description="Windows->Linux文件传输")
    parser.add_argument('ip', widget="TextField")
    parser.add_argument('port', widget="TextField")
    parser.add_argument('username', widget="TextField")
    parser.add_argument('password', widget="PasswordField")
    parser.add_argument('local_path', widget="DirChooser")
    parser.add_argument('remote_path',help="以/结尾",widget="DirChooser")
    args = parser.parse_args()
    return args.ip,args.port,args.username,args.password,args.local_path,args.remote_path

def window_linux(ip,port,username,password, local_path, remote_path ,filename):#单个文件传输通道
    tran = paramiko.Transport((ip,port))  # 实例化一个transport对象
    tran.connect(username=username, password=password)
    sftp = paramiko.SFTPClient.from_transport(tran)  # 获取SFTP实例
    local_path = os.path.join(local_path,filename) # 本地文件文件
    remote_path = os.path.join(remote_path,filename) # 远程文件路径
    sftp.put(local_path, remote_path)  # 执行上传动作
    tran.close()  # 关闭Transport通道

if __name__=="__main__":
    ip, port, username, password, local_path, remote_path = GUI()
    port=int(port)
    dirs2 = []#用于存放已传输的文件的列表
    while 1:
        dirs1 = os.listdir(local_path)#获取待传输文件夹的文件名
        dirs3 = set(dirs1).difference(set(dirs2))#返回在第一个列表但不在第二个列表的元素
        for file in dirs3:
            window_linux(ip,port,username,password,local_path, remote_path,file)
            dirs2.append(file)