using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hodor.Libraries;
using System.Windows.Forms;
using System.ComponentModel;

namespace Hodor.Console
{
    class Program
    {        
        private static IntPtr hook = IntPtr.Zero;
        private static WinApiInputIntercept _interceptor = new WinApiInputIntercept();
        static void Main(string[] args)
        {
            hook = _interceptor.SetHook();
            Application.Run();
            _interceptor.Unhook(hook);
        }
    }
}
