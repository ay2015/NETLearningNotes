using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Output
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //建立自定义通道栈
                BindingElement[] bindingElements = new BindingElement[3];
                bindingElements[0] = new TextMessageEncodingBindingElement();//文本编码
                //OneWayBindingElement 可以使得传输通道支持数据报模式
                bindingElements[1] = new OneWayBindingElement();
                //http传输
                //  bindingElements[2] = new HttpTransportBindingElement();
                //命名管道传输
                bindingElements[2] = new NamedPipeTransportBindingElement();
                CustomBinding binding = new CustomBinding(bindingElements);
                using (Message message = Message.CreateMessage(binding.MessageVersion, "sendMessage", "Message Body"))
                //创建消息
                {
                    //创建ChannelFactory
                    IChannelFactory<IOutputChannel> factory = binding.BuildChannelFactory<IOutputChannel>(new BindingParameterCollection());
                    factory.Open();//打开ChannelFactory
                    //创建IoutputChannel
                    IOutputChannel outputChannel = factory.CreateChannel(new System.ServiceModel.EndpointAddress("net.pipe://localhost/InputService"));
                    outputChannel.Open();//打开通道
                    outputChannel.Send(message);//发送消息
                    Console.WriteLine("已经成功发送消息!");
                    outputChannel.Close();//关闭通道
                    factory.Close();//关闭工厂
                }

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
