using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 系统锁屏合盖事件监听
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //https://docs.microsoft.com/zh-cn/sysinternals/learn/troubleshooting-book
            InitializeComponent();
            Microsoft.Win32.SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
            Microsoft.Win32.SystemEvents.SessionEnding += SystemEvents_SessionEnding;
            Microsoft.Win32.SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
            Microsoft.Win32.SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;

        }

        private void SystemEvents_UserPreferenceChanged(object sender, Microsoft.Win32.UserPreferenceChangedEventArgs e)
        {
            tb_main.Text += $"SystemEvents_UserPreferenceChanged:{e.Category}\r\n";
        }

        private void SystemEvents_SessionSwitch(object sender, Microsoft.Win32.SessionSwitchEventArgs e)
        {
            tb_main.Text += $"SystemEvents_SessionSwitch:{e.Reason}\r\n";
        }

        private void SystemEvents_SessionEnding(object sender, Microsoft.Win32.SessionEndingEventArgs e)
        {
            tb_main.Text += $"SystemEvents_SessionEnding:{e.Reason}\r\n";
        }

        private void SystemEvents_PowerModeChanged(object sender, Microsoft.Win32.PowerModeChangedEventArgs e)
        {
            tb_main.Text += $"SystemEvents_PowerModeChanged:{e.Mode}\r\n";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tb_main.Text = "";
        }
    }
}
