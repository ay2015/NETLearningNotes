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

namespace DuplexSenderOne
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        IChannelFactory<IDuplexChannel> factory;
        IDuplexChannel duplexChannel;
        NetTcpBinding binding;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                binding = new NetTcpBinding();//创建绑定
                factory = binding.BuildChannelFactory<IDuplexChannel>(new BindingParameterCollection());
                factory.Open(); //打开通道工厂
                                //再这里创建IRequestChannel
                duplexChannel = factory.CreateChannel(new EndpointAddress("net.tcp://localhost:9090/DuplexService/Pouint2"));
                duplexChannel.Open();//打开通道

            }
            catch (Exception ex)
            { }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (Message message = Message.CreateMessage(binding.MessageVersion, "sendMessage", "Message Body"))
            {
                //创建ChannelFactory 
                duplexChannel.Send(message);//发送消息 
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            duplexChannel.Close();//关闭通道
            factory.Close();//关闭通道工厂
        }
    }
}
