using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ChannelShapeChange
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //建立通道栈
            BindingElement[] bindingElements = new BindingElement[3];
            bindingElements[0] = new TextMessageEncodingBindingElement();
            ///数据报模式，再使用http进行消息传输时，收到协议的限制数据报模式和双工模式并不能被使用。
            ///这个问题的解决办法是通道形状改变。。
            //再WCF中，一共有2中协议通道类型。OneWayBindingElement是吧通道形状改变为数据报模式
            //CompositeDuplexBindingElement是吧通道形状改变为双工模式。
            bindingElements[1] = new OneWayBindingElement();//数据报
            bindingElements[1] = new CompositeDuplexBindingElement();//双工
            bindingElements[2] = new HttpTransportBindingElement();//http协议
            
            CustomBinding binding = new CustomBinding(bindingElements);
            //通道形状和上层服务协议
            //举例来说，基于UDP的传输通道会实现IInputChannel和IOutputChannel。因为其原生的数据报交互模式。
            //有些通道TCP协议通道，则会实现多种通道形状。WCF 会根据上层服务协议来自动选取需要的通道形状。
            //不是苏哦有通道都会实现苏哦有通道形状，有时WC会被迫使用其他的通道形状。
            //如果通道没有实现IInputChannel和IOutputChannel。WCF会尝试使用IDuplexChannel或者IRequestChannel/IReplyChannel来代替。
            //通道管理器
        }
    }
}
