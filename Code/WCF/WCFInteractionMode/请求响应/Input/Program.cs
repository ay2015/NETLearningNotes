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
                BindingElement[] bindingElements = new BindingElement[2];
                bindingElements[0] = new TextMessageEncodingBindingElement();//文本编码
                bindingElements[1] = new HttpTransportBindingElement();//HTTP传输
                CustomBinding binding = new CustomBinding(bindingElements);
                //建立ChannelListner


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
