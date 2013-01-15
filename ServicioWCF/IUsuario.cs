using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ServicioWCF
{
    [ServiceContract]
    public interface IUsuario
    {
        [OperationContract]
        bool Login(string nombreUsuario, string contrasena);
    }
}
