using Hodor.Libraries.CSharpHodor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Hodor.Service
{
    public class HodorService : IHodorService
    {
        BackgroundWorker worker = new BackgroundWorker();
        IntPtr context;
        private static bool _dehodorize = false;
        int device;
        Interception.Stroke stroke = new Interception.Stroke();
        List<ushort> hodorList = new List<ushort>() { ScanCode.H, ScanCode.O, ScanCode.D, ScanCode.O, ScanCode.R, ScanCode.Space };
        List<ushort> passKeysList = new List<ushort>() { ScanCode.Backspace, ScanCode.Enter, ScanCode.Escape, ScanCode.LeftShift, ScanCode.RightShift, ScanCode.Alt, ScanCode.Control };

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public void Hodorize()
        {
            worker.DoWork += worker_DoWork;
            _dehodorize = false;

            context = Interception.CreateContext();

            Interception.SetFilter(context, Interception.IsKeyboard, Interception.Filter.KeyDown);

            worker.RunWorkerAsync();
            
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            while (Interception.Receive(context, device = Interception.Wait(context), ref stroke, 1) > 0)
            {
                if (_dehodorize)
                {
                    Interception.Send(context, device, ref stroke, 1);
                    break;
                }

                if (!passKeysList.Contains(stroke.key.code))
                {
                    stroke.key.code = hodorList[i % 6];                    
                }
                else
                {
                    i = 5;
                }
                
                Interception.Send(context, device, ref stroke, 1);
                i++;
            }
            Interception.DestroyContext(context);
        }

        public void Dehodorize()
        {            
            _dehodorize = true;
        }



    }
}
