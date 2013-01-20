using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ModeloWCF;
using BaseDatos;
using System.Drawing;

namespace ServicioWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Producto" in code, svc and config file together.
    public class Producto : IProducto
    {
        public List<ModeloProducto> ObtenerTodosProductos()
        { 
            try 
	        {
                List<ModeloProducto> productos = BaseDatosProducto.ObtenerTodosProductos();
                if (productos == null)
                    throw new Exception("No se encontró ningún producto");
                return productos;
	        }
	        catch (Exception)
	        {
		
		        throw;
	        }
           
        }

        public List<ModeloProducto> ObtenerProductosConElNombre(string nombre)
        {
            try
            {
                List<ModeloProducto> productos = BaseDatosProducto.ObtenerProductosConElNombre(nombre);
                if (productos == null)
                    throw new Exception("No se encontró ningún producto");
                return productos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool registrarproducto(string nombre, string cantidad, string unidad, string detalle, string fechavencimientooferta, string nombreusuariodueno)
        {
            try
            {
                //FALTAN VALIDACIONES. EJ:
                if (nombre == null)
                    throw new Exception("El producto tiene que tener un nombre que refleje lo que quiere vender");
                float outCantidad = 0;
                if (!float.TryParse(cantidad, out outCantidad))
                    throw new Exception("Formato de 'cantidad' no válido");

                if (outCantidad <= 0)
                    throw new Exception("La cantidad tiene que ser mayor que 0");

                DateTime date = new DateTime();
                if (!DateTime.TryParse(fechavencimientooferta, out date))
                    throw new Exception("Formato de 'Fecha de vencimiento' no válido");

                if (date < DateTime.Now.Date)
                    throw new Exception("Fecha de vencimiento inválida, introduzca una fecha posterior a hoy");
                

                return BaseDatosProducto.registrarProducto(nombre, cantidad, unidad, fechavencimientooferta, detalle, nombreusuariodueno);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public bool eliminarproducto(string idproducto){}
        public bool eliminarproducto(string idproducto)
        {
            return true;
        }//Puse esto para que me compile

        public List<ModeloProducto> ObtenerProductosNoEvaluados()
        {
            try
            {
                List<ModeloProducto> productos = BaseDatosProducto.ProductosNoEvaluados();
                if (productos == null)
                    throw new Exception("Todos los productos fueron evaluados");
                return productos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
