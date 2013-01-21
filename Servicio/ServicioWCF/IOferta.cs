using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ModeloWCF;

namespace ServicioWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOferta" in both code and config file together.
    [ServiceContract]
    public interface IOferta
    {
        [OperationContract]
        void OfrecerOferta(string cantidad, string precio, string idproducto, string nombreUsuario, string tipoMoneda);
        [OperationContract]
        List<ModeloOferta> VerMisOfertas(string nombreUsuario);
        [OperationContract]
        List<ModeloOferta> VerOfertasDelProducto(string idProducto);
        [OperationContract]
        void EscogerEstasOfertas(List<ModeloOferta> ofertasGanadoras,List<ModeloOferta> ofertasPerdedoras);
    }
}
