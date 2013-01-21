using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BaseDatos;
using ModeloWCF;
using Utilidades;

namespace ServicioWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Oferta" in code, svc and config file together.
    public class Oferta : IOferta
    {
        //Este método se lo utiliza cuando un usuario que este interesado en un producto, pueda realizar una oferta del mismo.
        public void OfrecerOferta(string cantidad, string precio, string idproducto, string nombreUsuario, string tipoMoneda)
        {
            try
            {
                float a;
                float outCantidad;
                float outPrecio;
                double outIdProducto;
                if (!float.TryParse(cantidad, out outCantidad)) //Si se pasa un dato que no es numérico o sale de los límites de float el servicio le informa al usuario
                    throw new Exception("Cantidad inválida");
                if (!float.TryParse(precio, out outPrecio))
                    throw new Exception("Precio inválido");
                if (!double.TryParse(idproducto, out outIdProducto))
                    throw new Exception("Id no válido");
                if (outCantidad > BaseDatosProducto.ObtenerCantidadProducto(outIdProducto)) // Si la cantidad que pide es mayor que la cantidad que se ofrece.
                    throw new Exception("Cantidad excedida de la que se tiene");
                if (outCantidad < 0 || outCantidad==0)
                    throw new Exception("Cantidad tiene que ser mayor que 0");
                if (outPrecio < 0 || outPrecio == 0)
                    throw new Exception("Precio tiene que ser mayor que 0");
                if (BaseDatosOferta.YaTieneUnaOferta(outIdProducto, nombreUsuario)) //si el usuario ya cuenta con una oferta hacia este producto. No se le permite hacer otra.
                    throw new Exception("Usted ya tiene una oferta a este producto, espere los resultados");
                BaseDatosOferta.OfrecerOferta(outCantidad, outPrecio, outIdProducto, nombreUsuario, tipoMoneda); //la oferta finalmente si es que está limpia de errores se la registra.
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Este método sirve para ver las ofertas que ya realizó un usuario específico.
        public List<ModeloOferta> VerMisOfertas(string nombreUsuario)
        {
            try
            {
                List<ModeloOferta> ofertas = BaseDatosOferta.VerMisOfertas(nombreUsuario); // 
                if (ofertas == null)
                    throw new Exception("Ud. no tiene ofertas vigentes");
                return ofertas;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        //Este método permite ver las diferentes ofertas para un determinado producto
        public List<ModeloOferta> VerOfertasDelProducto(string idProducto)
        {
            try
            {
                double id;
                if (!double.TryParse(idProducto, out id))
                    throw new Exception("id invalido");
                List<ModeloOferta> ofertas = BaseDatosOferta.VerOfertasDelProducto(id);
                if (ofertas == null)
                    throw new Exception("No se tiene ofertas para el producto especificado");
                return ofertas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Este método no está disponible para un cliente, es de uso interno, por eso lleva el acceso private
        // Habilita la opción de mandar un correo electrónico automáticamente comunicando al usuario
        //de que ha ganado la oferta, es decir, que su oferta fue seleccionada por el usuario administrador.

        private void InformarGanadores(List<ModeloOferta> ofertas)
        {
            foreach (ModeloOferta oferta in ofertas)
            {
                if (oferta == null)
                    break;
                CorreoElectronico.enviar("agro.market.bolivia@gmail.com", oferta.usuarioSubasta.email, "GANADOR OFERTA AGROMARKET", "Agromarket Bolivia", "agromarketbolivia", "Le comunicamos que usted ganó la oferta que hizo al producto " + oferta.producto.nombre + " en fecha: " + oferta.fecha + ". Felicidades!!", 587, "smtp.gmail.com"); //Envia el correo electrónico.
                BaseDatosOferta.CambiarOfertaATomada(oferta);// Cambia la oferta a un estado de 'seleccionada'
                BaseDatosOferta.CambiarOfertaAVencida(oferta);//Cambia la oferta a un estado de 'no disponible', es decir, 'que ya fue evaluada'

            }
        }
        //Este método no está disponible para un cliente, es de uso interno, por eso lleva el acceso private.
        // Habilita la opción de mandar un correo electrónico automáticamente comunicando al usuario
        //de que ha perdido la oferta, es decir, que su oferta no fue seleccionada por el usuario administrador.

        public void InformarPerdedores(List<ModeloOferta> ofertas)
        {
            foreach (ModeloOferta oferta in ofertas)
            {
                if (oferta == null)
                    break;
                CorreoElectronico.enviar("agro.market.bolivia@gmail.com",oferta.usuarioSubasta.email,"OFERTA PERDIDA AGROMARKET","Agromarket Bolivia","agromarketbolivia","Le comunicamos que usted perdió la oferta que hizo al producto "+oferta.producto.nombre+" en fecha: "+oferta.fecha+". Siga intentando, mejor suerte para la próxima.",587,"smtp.gmail.com");
                BaseDatosOferta.CambiarOfertaAVencida(oferta);
            }
            
        }
        //Este método no está disponible para un cliente, es de uso interno, por eso lleva el acceso private.
        // Habilita la opción de mandar un correo electrónico automáticamente comunicando al usuario dueño del producto
        //de que ha vendido su producto, es decir, que usuario administrador ya escogió ofertantes.

        private void InformarAlProductor(ModeloUsuario usuario, float totalUnidades)
        {
            CorreoElectronico.enviar("agro.market.bolivia@gmail.com", usuario.email, "SU PRODUCTO TIENE DUEÑO", "Agromarket Bolivia", "agromarketbolivia", "Su producto fue vendido exitosamente. Total de unidades vendidas: " + totalUnidades + " comuníquese con nosotros para mayor información.", 587, "smtp.gmail.com");
        }
        //Este es un método que permite registrar las ofertas ganadoras y perdedoras para un determinado producto.
        public void EscogerEstasOfertas(List<ModeloOferta> ofertasGanadoras,List<ModeloOferta> ofertasPerdedoras)
        {
            
            float totalCantidad = 0;
            if (ofertasGanadoras ==null || ofertasGanadoras[0] == null)
                throw new Exception("Debe escoger por lo menos una oferta");
            BaseDatosProducto.CambiarEstadoAEvaluado(ofertasGanadoras[0].producto.idProducto); // Cambia el estado del producto a evaluada, este ya no estará disponible para realizar ofertas posteriores
            foreach (ModeloOferta oferta in ofertasGanadoras) // Permite calcular el total de unidades de todas las ofertas.
            {
                if (oferta == null)
                    break;
                totalCantidad += oferta.cantidad;
            }
            if (totalCantidad > ofertasGanadoras[0].producto.cantidad)//Si el total de unidades sobrepasa el total de unidades del producto, el mercado no se abastecería
                throw new Exception("Imposible escoger estas ofertas, ya que la cantidad del producto es insuficiente para satisfacer la demanda");

            InformarGanadores(ofertasGanadoras);
            if(ofertasPerdedoras!=null || ofertasPerdedoras[0]!=null)
            InformarPerdedores(ofertasPerdedoras);
            InformarAlProductor(ofertasGanadoras[0].producto.Usuario,totalCantidad);//Correo electrónico al productor informando que su producto ya tiene dueño(s)
        }
        
    }
}
