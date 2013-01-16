using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BaseDatos;
using ModeloWCF;

namespace ServicioWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Oferta" in code, svc and config file together.
    public class Oferta : IOferta
    {

        public void OfrecerOferta(float cantidad, float precio, double idproducto, string nombreUsuario, string tipoMoneda)
        {
            try
            {
                float a;
                if (!float.TryParse(cantidad.ToString(), out a))
                    throw new Exception("Cantidad inválida");
                if (!float.TryParse(precio.ToString(), out a))
                    throw new Exception("Precio inválido");
                if (cantidad > BaseDatosProducto.ObtenerCantidadProducto(idproducto))
                    throw new Exception("Cantidad excedida de la que se tiene");
                if (cantidad < 0 || cantidad==0)
                    throw new Exception("Cantidad tiene que ser mayor que 0");
                if (precio < 0 || precio == 0)
                    throw new Exception("Precio tiene que ser mayor que 0");
                if (BaseDatosOferta.YaTieneUnaOferta(idproducto, nombreUsuario))
                    throw new Exception("Usted ya tiene una oferta a este producto, espere los resultados");

                BaseDatosOferta.OfrecerOferta(cantidad, precio, idproducto, nombreUsuario, tipoMoneda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ModeloOferta> VerMisOfertas(string nombreUsuario)
        {
            try
            {
                List<ModeloOferta> ofertas = BaseDatosOferta.VerMisOfertas(nombreUsuario);
                if (ofertas == null)
                    throw new Exception("Ud. no tiene ofertas vigentes");
                return ofertas;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
