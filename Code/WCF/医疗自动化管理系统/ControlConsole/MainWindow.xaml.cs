using ServiceDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace ControlConsole
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceHost host;
        WcfNamedPipeService pipe = new WcfNamedPipeService();
        public MainWindow()
        {
            InitializeComponent();
            host = new ServiceHost(pipe);

            host.Open();
            tb_status.Text = "已打开";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (pipe.callback != null)
            {
                pipe.callback.test2(tb_content.Text);
            }
        }
    }
}
