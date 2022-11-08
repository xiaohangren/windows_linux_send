#写死一个文件上传
import os.path
import paramiko
def window_linux(ip, port, username, password, local_path, remote_path, filename):  # 单个文件传输通道
    tran = paramiko.Transport((ip, port))  # 实例化一个transport对象
    tran.connect(username=username, password=password)
    sftp = paramiko.SFTPClient.from_transport(tran)  # 获取SFTP实例
    local_path = os.path.join(local_path, filename)  # 本地文件文件
    remote_path = os.path.join(remote_path, filename)  # 远程文件路径
    sftp.put(local_path, remote_path)  # 执行上传动作
    tran.close()  # 关闭Transport通道
if __name__=="__main__":
    dirs2 = []#用于存放已传输的文件的列表
    while 1:
        local_path1 = 'C:/Users/lenovo/Desktop/Linux/file1'
        dirs1 = os.listdir(local_path1)#获取待传输文件夹的文件名
        dirs3 = set(dirs1).difference(set(dirs2))#返回在第一个列表但不在第二个列表的元素
        for file in dirs3:
            window_linux('192.168.192.129', 22,"finn",'Wzz258258','C:/Users/lenovo/Desktop/Linux/file1','/home/finn/桌面/picture/',file)
            dirs2.append(file)












