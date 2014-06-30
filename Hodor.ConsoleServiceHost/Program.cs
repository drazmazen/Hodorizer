using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hodor.Service;
using System.ServiceModel;
using System.Windows.Forms;
using System.Threading;


namespace Hodor.ConsoleServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost svcHost = new ServiceHost(typeof(HodorService)))
            {
                svcHost.Open();                
                while (svcHost.State == CommunicationState.Opened)
                {
                    Thread.Sleep(60000);
                }
            }
        }
    }
}
