using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDefinition
{
    [ServiceContract(CallbackContract =typeof(ISubtileCallback))]
    public interface IWcfNamedPipeService
    {
        //5个操作契约
        [OperationContract]
        bool test();
        [OperationContract]
        bool test1();
    }
    public interface ISubtileCallback
    {
        [OperationContract(IsOneWay = true)]
        void test2(string str);
    }
}
