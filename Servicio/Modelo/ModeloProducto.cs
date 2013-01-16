﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class ModeloProducto
    {
        public string nombre { get; set; }
        public string detalle { get; set; }
        public float cantidad { get; set; }
        public DateTime fechaOferta { get; set; }
        public DateTime fechaVencimientoOferta { get; set; }
        public ModeloUsuario Usuario { get; set; }
        public string unidad { get; set; }
    }
}