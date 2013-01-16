using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ModeloWCF
{
    [DataContract]
    public class ModeloOferta
    {
        [DataMember]
        public ModeloProducto producto { get; set; }
        [DataMember]
        public ModeloUsuario usuarioSubasta { get; set; }
        [DataMember]
        public bool vencida { get; set; }
        [DataMember]
        public float cantidad { get; set; }
        [DataMember]
        public float precio { get; set; }
        [DataMember]
        public bool tomada { get; set; }
        [DataMember]
        public DateTime fecha { get; set; }
        [DataMember]
        public string tipoMoneda { get; set; }
    }
}
