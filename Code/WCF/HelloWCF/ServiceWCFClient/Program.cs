using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ServiceWCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (HelloWCFProxy proxy = new HelloWCFProxy())
            {
                Console.WriteLine(proxy.HelloWCF("WCF"));//利用代理调用服务
                Console.Read();
            }
        }
    }
    [ServiceContract]
   public interface IService
    {
        [OperationContract]
        string HelloWCF(string name);

    }
    //代理
    class HelloWCFProxy : ClientBase<IService>, IService
    {
        public static readonly Binding HelloWCFBinding = new NetNamedPipeBinding();
        public static readonly EndpointAddress HelloWCFAddress = new EndpointAddress(new Uri("net.pipe://localhost/HelloWCF"));


        public HelloWCFProxy() : base(HelloWCFBinding, HelloWCFAddress)
        { }
        public string HelloWCF(string name)
        {
            return Channel.HelloWCF(name); //使用channel属性对服务进行调用
        }
    }
}
