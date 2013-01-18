using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ModeloWCF;
using BaseDatos;

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
        public bool registraproducto(string idproducto, string nombre, string cantidad, string unidad, string fechaoferta, string fechavencimientooferta, string detalle, string nombreusuariodueno)
        {
            try
            {
                return BaseDatosProducto.registrarProducto(idproducto, nombre, cantidad, unidad, fechaoferta, fechavencimientooferta, detalle, nombreusuariodueno);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public bool eliminarproducto(string idproducto){}
    }
}
