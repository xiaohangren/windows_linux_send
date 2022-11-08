##window远程操作Linux文件上传下载
import paramiko
def window_linux():
    tran = paramiko.Transport(('192.168.192.129', 22))  # 实例化一个transport对象
    tran.connect(username="finn", password='Wzz258258')
    sftp = paramiko.SFTPClient.from_transport(tran)  # 获取SFTP实例
    local_path = "C:/Users/lenovo/Desktop/Linux/Macao.jpg"  # 本地文件文件
    remote_path = "/home/finn/桌面/picture/Macao1"  # 远程文件路径
    # sftp.get(remote_path, local_path)# 执行下载动作
    sftp.put(local_path, remote_path)  # 执行上传动作
    tran.close()  # 关闭Transport通道

if __name__=="__main__":
    window_linux()