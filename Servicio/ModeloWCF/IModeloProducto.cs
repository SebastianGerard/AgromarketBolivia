using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ModeloWCF
{
    [DataContract]
    public class ModeloProducto
    {
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string detalle { get; set; }
        [DataMember]
        public float cantidad { get; set; }
        [DataMember]
        public DateTime fechaOferta { get; set; }
        [DataMember]
        public DateTime fechaVencimientoOferta { get; set; }
        [DataMember]
        public ModeloUsuario NombreUsuarioDueno { get; set; }
        [DataMember]
        public string unidad { get; set; }
    }
}
