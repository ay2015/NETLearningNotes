using IChannelListenerAndIChannelFacoty.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
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

namespace IChannelListenerAndIChannelFacoty
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        NetTcpBinding binding;
        public MainWindow()
        {
            InitializeComponent();
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IChannelListenerPage listenerPage = new IChannelListenerPage();
            listenerPage.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IChannelFactoryPage factoryPage = new IChannelFactoryPage();
            factoryPage.Show();
        }
    }
}
