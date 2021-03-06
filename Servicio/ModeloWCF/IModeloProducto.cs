﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Drawing;

namespace ModeloWCF
{
    [DataContract]
    public class ModeloProducto
    {
        [DataMember]
        public double idProducto { get; set; }
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
        public ModeloUsuario Usuario { get; set; }
        [DataMember]
        public string unidad { get; set; }
        [DataMember]
        public bool evaluado { get; set; }
        [DataMember]
        public byte[] imagen { get; set; }
    }
}
