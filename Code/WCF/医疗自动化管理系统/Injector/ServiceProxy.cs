using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Injector
{
    public class ServiceProxy : System.ServiceModel.DuplexClientBase<ServiceDefinition.IWcfNamedPipeService>, ServiceDefinition.IWcfNamedPipeService
    {
        public ServiceProxy(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
           base(callbackInstance, binding, remoteAddress)
        {

        }

        public bool test()
        {
            return base.Channel.test();
        }

        public bool test1()
        {
         
            System.Diagnostics.Debug.WriteLine(State);
            return base.Channel.test1();

        }
    }
}
