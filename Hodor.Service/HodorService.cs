using Hodor.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hodor.Service
{
    public class HodorService : IHodorService
    {
        private static IntPtr _hook = IntPtr.Zero;
        private static WinApiInputIntercept _interceptor = new WinApiInputIntercept();       

        public void Hodorize()
        {
            Task.Run(() =>
                {
                    _hook = _interceptor.SetHook();
                    Application.Run();
                    _interceptor.Unhook(_hook);
                }
                );            
        }

        public void Dehodorize()
        {            
            Application.Exit();
        }



    }
}
