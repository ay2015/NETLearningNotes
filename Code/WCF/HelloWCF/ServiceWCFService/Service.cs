using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceWCFService
{
    public class Service : IService
    {
        public string HelloWCF(string name)
        {
            return $"{name},你好!";
        }
    }
}
