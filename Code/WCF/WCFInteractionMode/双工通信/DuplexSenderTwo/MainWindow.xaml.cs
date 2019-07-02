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

namespace DuplexSenderTwo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                NetTcpBinding binding = new NetTcpBinding();//创建绑定
                                                            //创建ChannelFactory
                IChannelFactory<IDuplexChannel> factory = binding.BuildChannelFactory<IDuplexChannel>(new BindingParameterCollection());
                factory.Open();//打开通道工厂
                               //创建IrequestChannel
                IDuplexChannel duplexChannel = factory.CreateChannel(new EndpointAddress("net.tcp://localhost:9090/DuplexService/Point2"));
                duplexChannel.Open();//打开通道
              
            }
            catch (Exception ex)
            { }
        }
    }
}
