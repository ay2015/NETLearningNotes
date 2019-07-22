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
    /// IChannelFactoryPage.xaml 的交互逻辑
    /// </summary>
    public partial class IChannelFactoryPage : Window
    {
        NetTcpBinding binding = null;
        public IChannelFactoryPage()
        {
            InitializeComponent();
            //匿名管道是单项的。
            //命名管道是双向的。
            //IChannelFactory<T>接口一般负责创建并管理通道栈。大家会使用ClientBase<T>来代替IChannelFactory<T>.
            //IChannelFactory需要负责关闭通道栈，IChannelListner不需要关闭通道栈。。可以独立于它的通道栈而关闭，
            binding = new NetTcpBinding();//创建绑定
            IChannelFactory<IRequestChannel> factory = binding.BuildChannelFactory<IRequestChannel>(new BindingParameterCollection());
            factory.Open();//打开ChannelFactory
            //这里创建IRequestChannel
            IRequestChannel requestChannel = factory.CreateChannel(new EndpointAddress("http://localhost:9090/RequestReplyService"));
            requestChannel.Open();//打开IRequestChannel //请求通道
            //通道工厂。用于连接Listner。

        }
    }
}
