using ServiceDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Injector
{
    [CallbackBehavior(UseSynchronizationContext = false)]
    public class CallbackHandler : ISubtileCallback
    {
        MainWindow _main;
        public CallbackHandler(MainWindow main)
        {
            _main = main;
        }
        public void test2(string str)
        {
            _main.Dispatcher.BeginInvoke((Action)delegate
            {
                _main.tb_response.Text = str;
            });
           
        }
    }
}
