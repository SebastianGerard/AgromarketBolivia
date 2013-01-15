
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Modelo;
using BaseDatos;

namespace ServicioWCF
{
    public class Usuario : IUsuario
    {
        public bool Login(string nombreUsuario, string contrasena)
        {
            try
            {
                //TODO acceso a BaseDatos Consultando si es correcto o no.
                ModeloUsuario modeloUsuario = BaseDatosUsuario.ObtenerUsuario(nombreUsuario);
                return (modeloUsuario.contrasena == contrasena) && (modeloUsuario.nombreUsuario == nombreUsuario);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }
    }
}

