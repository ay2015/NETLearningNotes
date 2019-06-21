using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ServiceWCFHost
{
    class Program
    {

        static void Main(string[] args)
        {
            using (MyServiceHost host = new MyServiceHost())
            {
                host.Open();
                Console.Read();//等待客户端访问
            }
        }
        //通信方式 
        private Binding GetBinding()
        {
            return new NetNamedPipeBinding();//返回NetNamedPipeBinding对象 
        }
        //服务地址由2部分组成，基地址和可选地址。基地址一般包括通信协议和主机名。可选地址具体定义了服务的位置。

    }
    public class MyServiceHost : IDisposable
    {
        private ServiceHost _myHost;//服务主机
        public static readonly Type ServiceType = typeof(ServiceWCFService.Service); //服务契约实现类型
        public const string BaseAddrrss = "net.pipe://localhost/"; //基地址  
        //服务契约定义类型
        public static readonly Type ContractType = typeof(ServiceWCFService.IService);
        //服务只定义了一个绑定
        public static readonly Binding HelloWCFBinding = new NetNamedPipeBinding();
        public const string HelloWorldServiceAddress = "HelloWCF";//可选地址
        public MyServiceHost()
        {
            ConstructServiceHost();
        }
        protected void ConstructServiceHost()
        {
            //初始化ServiceHost对象
            _myHost = new ServiceHost(ServiceType, new Uri[] { new Uri(BaseAddrrss) });
            //添加终结点
            _myHost.AddServiceEndpoint(ContractType, HelloWCFBinding, HelloWorldServiceAddress);
        }
        //只读
        public ServiceHost Host
        {
            get { return _myHost; }
        }

        //打开服务
        public void Open()
        {
            Console.WriteLine("开始启动服务..");
            _myHost.Open();
            Console.WriteLine("服务已启动..");
           
        }

        public void Dispose()
        {
            //ServiceHost显示实现了IDisposable的Dispose()方法，锁这里要先强制转换成IDisposable类型
            if (_myHost != null)
            {
                (_myHost as IDisposable).Dispose();
            }
        }
    }
}
