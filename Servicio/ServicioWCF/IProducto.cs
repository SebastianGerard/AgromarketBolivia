using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ModeloWCF;
using System.Drawing;
namespace ServicioWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProducto" in both code and config file together.
    [ServiceContract]
    public interface IProducto
    {
        [OperationContract]
        List<ModeloProducto> ObtenerTodosProductos();
        [OperationContract]
        List<ModeloProducto> ObtenerProductosConElNombre(string nombre);
        [OperationContract]
        bool registrarproducto(string nombre, string cantidad, string unidad, string detalle, string fechavencimientooferta, string nombreusuariodueno);
        
        [OperationContract]
        List<ModeloProducto> ObtenerProductosNoEvaluados();
        [OperationContract]
        ModeloProducto ObtenerProductoPorId(string id);
    }
}
