﻿using System;
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
        public List<ModeloOferta> VerOfertasDelProducto(double idProducto)
        {
            try
            {
                List<ModeloOferta> ofertas = BaseDatosOferta.VerOfertasDelProducto(idProducto);
                if (ofertas == null)
                    throw new Exception("No se tiene ofertas para el producto especificado");
                return ofertas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void InformarGanadores(List<ModeloOferta> ofertas)
        {
            foreach (ModeloOferta oferta in ofertas)
            {
                CorreoElectronico.enviar("agro.market.bolivia@gmail.com", oferta.usuarioSubasta.email, "GANADOR OFERTA AGROMARKET", "Agromarket Bolivia", "agromarketbolivia", "Le comunicamos que usted ganó la oferta que hizo al producto " + oferta.producto.nombre + " en fecha: " + oferta.fecha + ". Felicidades!!", 587, "smtp.gmail.com");
                BaseDatosOferta.CambiarOfertaATomada(oferta);
            }
        }
        public void InformarPerdedores(List<ModeloOferta> ofertas)
        {
            foreach (ModeloOferta oferta in ofertas)
            {
                CorreoElectronico.enviar("agro.market.bolivia@gmail.com",oferta.usuarioSubasta.email,"OFERTA PERDIDA AGROMARKET","Agromarket Bolivia","agromarketbolivia","Le comunicamos que usted perdió la oferta que hizo al producto "+oferta.producto.nombre+" en fecha: "+oferta.fecha+". Siga intentando, mejor suerte para la próxima.",587,"smtp.gmail.com");
            }
            
        }
        public void EscogerEstasOfertas(List<ModeloOferta> ofertasGanadoras,List<ModeloOferta> ofertasPerdedoras)
        {
            float totalCantidad = 0;
            if (ofertasGanadoras == null)
                throw new Exception("Debe escoger por lo menos una oferta");

            foreach (ModeloOferta oferta in ofertasGanadoras)
            {
                totalCantidad += oferta.cantidad;
            }
            if (totalCantidad > ofertasGanadoras[0].producto.cantidad)
                throw new Exception("Imposible escoger estas ofertas, ya que la cantidad del producto es insuficiente para satisfacer la demanda");

            InformarGanadores(ofertasGanadoras);
            InformarPerdedores(ofertasPerdedoras);
            InformarAlProductor(ofertasGanadoras[0].producto.Usuario,totalCantidad);
        }

        private void InformarAlProductor(ModeloUsuario usuario,float totalUnidades)
        {
            CorreoElectronico.enviar("agro.market.bolivia@gmail.com", usuario.email, "SU PRODUCTO TIENE DUEÑO", "Agromarket Bolivia", "agromarketbolivia", "Su producto fue vendido exitosamente. Total de unidades vendidas: " + totalUnidades + " comuníquese con nosotros para mayor información.", 587, "smtp.gmail.com");
        }
    }
}
