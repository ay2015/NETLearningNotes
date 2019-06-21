using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Input
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //建立和发送端相同的通道栈
                BindingElement[] bindingElements = new BindingElement[3];
                bindingElements[0] = new TextMessageEncodingBindingElement();//文本编码
                //oneWayBindingElement() 传输通道支持数据报模式
                bindingElements[1] = new OneWayBindingElement();
                bindingElements[2] = new NamedPipeTransportBindingElement();//命名管道
                CustomBinding binding = new CustomBinding(bindingElements);
                //建立ChannelListner倾听者，接收数据
                IChannelListener<IInputChannel> listener = binding.BuildChannelListener<IInputChannel>(new Uri("net.pipe://localhost/InputService"), new BindingParameterCollection()); 
                listener.Open();//打开ChannelListner
                IInputChannel inputChannel = listener.AcceptChannel();
                //创建IInputChannel
                inputChannel.Open();//打开IInputChannel
                Console.WriteLine("开始接受消息..");
                Message message = inputChannel.Receive();//接受并打印
                Console.WriteLine($"接收一条消息,action为{message.Headers.Action},Body为{message.GetBody<string>()}");
                message.Close();//关闭消息
                inputChannel.Close();//关闭通道
                listener.Close();//关闭监听器
                Console.Read();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.Read();
            }
        }
    }
}
