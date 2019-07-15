using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace 模拟按键
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Dm.dmsoft dm = new Dm.dmsoft();
        KeyboardHook k_hook = new KeyboardHook();
        int hwnd = -1;
        public MainWindow()
        {
            InitializeComponent();
            AutoRegCom("regsvr32 -s dm.dll");
            //2.安装Hook，在程序入口中写上下面的代码（本例中用了WinForm，在Form的构造方法中安装Hook即可） 
            //安装键盘钩子 

            k_hook.KeyDownEvent += new KeyEventHandler(hook_KeyDown);//钩住键按下 
            hwnd = dm.GetMousePointWindow();
            dm.BindWindow(hwnd, "dx", "一笑倾城 - 扛不住怪我咯","",0);
            k_hook.Start();//安装键盘钩子
        }

        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            //判断按下的键（Alt + A） 
            if (e.KeyValue == (int)Keys.F11)
            {
                start();
            }
            if (e.KeyValue == (int)Keys.F12)
            {
                stop();
            }
        }

        private void stop()
        {

        }

        static string AutoRegCom(string strCmd)
        {
            string rInfo;
            try
            {
                Process myProcess = new Process();
                ProcessStartInfo myProcessStartInfo = new ProcessStartInfo("cmd.exe");
                myProcessStartInfo.UseShellExecute = false;
                myProcessStartInfo.CreateNoWindow = true;
                myProcessStartInfo.RedirectStandardOutput = true;
                myProcess.StartInfo = myProcessStartInfo;
                myProcessStartInfo.Arguments = "/c " + strCmd;
                myProcess.Start();
                StreamReader myStreamReader = myProcess.StandardOutput;
                rInfo = myStreamReader.ReadToEnd();
                myProcess.Close();
                rInfo = strCmd + "\r\n" + rInfo;
                return rInfo;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void start()
        {
            Task.Factory.StartNew(() =>
            {

                object X = 0, Y = 0;

                dm.SetPath("d:\\path");
                dm.SetDict(0, "test.txt");

                dm.FindPic(0, 0, 400, 400, "xiaoyao.bmp", "000000", 0.9, 0, out X, out Y);
                dm.FindStr(900, 600, 1183, 750, "购买", "f3eadc-777777", 1.0, out X, out Y);
                dm.MoveTo((int)X, (int)Y);

                Debug.WriteLine($"{X},{Y}");

                Thread.Sleep(1011);
                int result = dm.LeftDoubleClick();

            });

        }
    }

}
