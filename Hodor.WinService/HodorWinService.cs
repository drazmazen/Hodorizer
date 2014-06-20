using Hodor.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Hodor.WinService
{
    public partial class HodorWinService : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public HodorWinService()
        {
            ServiceName = "HodorWinService";
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            serviceHost = new ServiceHost(typeof(HodorService));

            serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
}
