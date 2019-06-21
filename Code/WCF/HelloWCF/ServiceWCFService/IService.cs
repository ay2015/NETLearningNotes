using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceWCFService
{
    [ServiceContract]
   public interface IService
    {
        [OperationContract]
        string HelloWCF(string name);//服务操作
    }
}
