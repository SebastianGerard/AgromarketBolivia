using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ModeloWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IModeloUsuario" in both code and config file together.
    [DataContract]
    public class ModeloUsuario
    {
        [DataMember]
        public string nombreUsuario { get; set; }
        [DataMember]
        public string contrasena { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string apellido { get; set; }
        [DataMember]
        public string direccion { get; set; }
        [DataMember]
        public string nivelAcceso { get; set; }
    }
}
