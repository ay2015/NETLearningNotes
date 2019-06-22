using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Output
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //创建自定义通道
                BindingElement[] bindingElements = new BindingElement[2];
                bindingElements[0] = new TextMessageEncodingBindingElement();//文本编码
                bindingElements[1] = new HttpTransportBindingElement();//Htp传输
                CustomBinding binding = new CustomBinding(bindingElements);
                using (Message message = Message.CreateMessage(binding.MessageVersion, "sendMessage", "Message Body"))
                {
                    //创建ChannelFactory request 请求 reply回复
                    IChannelFactory<IRequestChannel> factory = binding.BuildChannelFactory<IRequestChannel>(new BindingParameterCollection());
                    factory.Open();//打开ChannelFactory
                                   //这里创建IRequestChannel
                    IRequestChannel requestChannel = factory.CreateChannel(new System.ServiceModel.EndpointAddress("http://localhost:9090/RequestReplyService"));
                    requestChannel.Open();//打开通道
                    Message response = requestChannel.Request(message);
                    //发送消息
                    Console.WriteLine("已经成功发送消息!");
                    //查看返回消息
                    Console.WriteLine($"接收到一条返回消息，action为:{response.Headers.Action},body为{response.GetBody<String>()}");
                    requestChannel.Close(); //关闭通道
                    factory.Close();//关闭工厂
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }
            finally
            {
                Console.Read();
            }
        }
    }
}
