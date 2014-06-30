using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Hodor.Service
{    
    [ServiceContract]
    public interface IHodorService
    {

        [OperationContract]
        void Hodorize();

        [OperationContract]
        void Dehodorize();

    }
}
