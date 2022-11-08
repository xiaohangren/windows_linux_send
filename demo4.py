#可视化节界面
from gooey import Gooey, GooeyParser
@Gooey(language='chinese',richtext_controls=True)#装饰器
def GUI():
    parser = GooeyParser(description="Windows->Linux文件传输")
    parser.add_argument('ip', widget="TextField")
    parser.add_argument('port', widget="TextField")
    parser.add_argument('username', widget="TextField")
    parser.add_argument('password', widget="PasswordField")
    parser.add_argument('local_path', widget="DirChooser")
    parser.add_argument('remote_path',widget="DirChooser")
    args = parser.parse_args()#将输入参数收集
    return args.ip,args.port,args.username,args.password,args.local_path,args.remote_path
if   __name__ == '__main__':
    ip,port,username,password,local_path,remote_path=GUI()
    print(ip,port,username,password,local_path,remote_path)