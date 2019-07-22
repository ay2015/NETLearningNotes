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
using System.Windows.Shapes;

namespace IChannelListenerAndIChannelFacoty.Views
{
    /// <summary>
    /// IChannelListenerPage.xaml 的交互逻辑
    /// </summary>
    public partial class IChannelListenerPage : Window
    {
        NetTcpBinding binding = null;
        public IChannelListenerPage()
        {
            InitializeComponent();
            ///监听者
            IChannelListener<IReplyChannel> listener = binding.BuildChannelListener<IReplyChannel>(new Uri("http://localhost:9090/RequestReplyService"), new BindingParameterCollection());
            listener.Open();//打开
            //创建IReplyChannel
            IReplyChannel replyChannel = listener.AcceptChannel();
            replyChannel.Open();//打开IReplyChannel应答通道
        }
    }
}
