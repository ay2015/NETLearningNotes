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
                //使用说明先启动input，然后在启动启动output。
                //记得使用管理员启动VS，我在程序清单中添加了管理员权限。
                //建立和发送端相同的通道栈
                BindingElement[] bindingElements = new BindingElement[2];
                bindingElements[0] = new TextMessageEncodingBindingElement();//文本编码
                bindingElements[1] = new HttpTransportBindingElement();//HTTP传输
                CustomBinding binding = new CustomBinding(bindingElements);
                //建立ChannelListner
                IChannelListener<IReplyChannel> listener = binding.BuildChannelListener<IReplyChannel>(new Uri("http://localhost:9090/RequestReplyService"), new BindingParameterCollection());
                listener.Open();//打开监听
                //创建IRepllyChannel
                IReplyChannel replyChannel = listener.AcceptChannel();
                replyChannel.Open();//打开通道
                Console.WriteLine("开始接受消息..");
                //接收打印
                RequestContext requestContext = replyChannel.ReceiveRequest();
                Console.WriteLine($"接收到一条消息,action为:{requestContext.RequestMessage.Headers.Action},body为{requestContext.RequestMessage.GetBody<string>()}");
                //创建返回消息
                Message response = Message.CreateMessage(binding.MessageVersion, "response", "reponse body");
                //发送返回消息
                requestContext.Reply(response);
                //关闭
                requestContext.Close();//关闭通道
                listener.Close();//关闭监听
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
