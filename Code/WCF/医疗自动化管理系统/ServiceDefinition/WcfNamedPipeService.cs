using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDefinition
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
      ConcurrencyMode = ConcurrencyMode.Multiple)]
    public sealed class WcfNamedPipeService : IWcfNamedPipeService
    {
        public ISubtileCallback callback
        {
            get; set;
        }
        public bool test()
        {
            callback = OperationContext.Current.GetCallbackChannel<ISubtileCallback>();
            return true;
        }

        public bool test1()
        {
            return false;
        }
    }
}
