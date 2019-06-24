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

namespace Injector
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceProxy proxy;
        public MainWindow()
        {
            InitializeComponent();
            CallbackHandler call = new CallbackHandler(this);
            proxy = new ServiceProxy(
               new InstanceContext(call),
               new NetNamedPipeBinding(),
               new EndpointAddress("net.pipe://localhost/WcfNamedPipeService"));

            //打开代理
            proxy.Open();



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tb_response.Text = proxy.test().ToString();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tb_response.Text = proxy.test1().ToString();

        }
    }
}
