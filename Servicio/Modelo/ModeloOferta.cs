﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class ModeloOferta
    {
        public ModeloProducto producto { get; set; }
        public ModeloUsuario usuarioSubasta { get; set; }
        public bool vencida { get; set; }
        public float cantidad { get; set; }
        public float precio { get; set; }
        public bool tomada { get; set; }
        public DateTime fecha { get; set; }
        public string tipoMoneda { get; set; }
    }
}
