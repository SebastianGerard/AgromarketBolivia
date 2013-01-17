using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using ModeloWCF;
namespace BaseDatos
{
    public static class BaseDatosOferta
    {

        public static void OfrecerOferta(float cantidad, float precio, double idproducto, string nombreUsuario, string tipoMoneda)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("Insert into Oferta (idproducto,nombreusuariosubasta,vencida,cantidad,precio,tomada,fecha,tipomoneda) Values (@idproducto,@nombreusuario,false,@cantidad,@precio,false,@fecha,@tipomoneda)", Conexion.conexion);
                cmd.Parameters.Add("idproducto", idproducto);
                cmd.Parameters.Add("nombreusuario",nombreUsuario);
                cmd.Parameters.Add("cantidad",cantidad);
                cmd.Parameters.Add("precio",precio);
                cmd.Parameters.Add("fecha",DateTime.Now.Date);
                cmd.Parameters.Add("tipomoneda",tipoMoneda);
                Conexion.abrirConexion();
                cmd.ExecuteNonQuery();
                Conexion.cerrarConexion();
            }
            catch (Exception)
            {

                throw new Exception("Hubo un error con la base de datos, intente de nuevo más tarde");
            }
        }
        public static bool YaTieneUnaOferta(double idProducto, string nombreUsuario)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("Select idproducto,nombreusuariosubasta from oferta where idproducto=@idproducto and nombreusuariosubasta=@nombreusuario", Conexion.conexion);
                cmd.Parameters.Add("idproducto",idProducto);
                cmd.Parameters.Add("nombreusuario",nombreUsuario);
                Conexion.abrirConexion();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                Conexion.cerrarConexion();
                if (reader.HasRows)
                    return true;
                return false;
                
            }
            catch (Exception ex)
            {

                throw ex ;
            }
        }
        public static List<ModeloOferta> VerMisOfertas(string nombreUsuario)
        {
            try
            {
                List<ModeloOferta> ofertas = null;
                NpgsqlCommand cmd = new NpgsqlCommand("Select * from oferta where nombreusuariosubasta = @nombreusuario",Conexion.conexion);
                cmd.Parameters.Add("nombreusuario",nombreUsuario);
                Conexion.abrirConexion();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    ofertas = new List<ModeloOferta>();
                    while (reader.Read())
                    {
                        ModeloOferta oferta = new ModeloOferta();
                        oferta.cantidad = float.Parse(reader["cantidad"].ToString());
                        oferta.fecha = DateTime.Parse(reader["fecha"].ToString());
                        oferta.idOferta = double.Parse(reader["idoferta"].ToString());
                        oferta.precio = float.Parse(reader["precio"].ToString());
                        oferta.producto = BaseDatosProducto.ObtenerProducto(double.Parse(reader["idproducto"].ToString()));
                        oferta.tipoMoneda = reader["tipomoneda"].ToString();
                        oferta.usuarioSubasta = BaseDatosUsuario.ObtenerUsuario(reader["nombreusuariosubasta"].ToString());
                        oferta.vencida = (bool)reader["vencida"];
                        ofertas.Add(oferta);
                    }
                }
                return ofertas;
            }
            catch (Exception)
            {
                throw new Exception("Hubo un error con la base de datos, intente de nuevo más tarde");
            }
        }
        public static List<ModeloOferta> VerOfertasDelProducto(double idProducto)
        {
            try
            {
                List<ModeloOferta> ofertas = null;
                NpgsqlCommand cmd = new NpgsqlCommand("Select * from oferta where idproducto = @idproducto",Conexion.conexion);
                cmd.Parameters.Add("idproducto",idProducto);
                Conexion.abrirConexion();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    ofertas = new List<ModeloOferta>();
                    while (reader.Read())
                    {
                        ModeloOferta oferta = new ModeloOferta();
                        oferta.cantidad = float.Parse(reader["cantidad"].ToString());
                        oferta.fecha = DateTime.Parse(reader["fecha"].ToString());
                        oferta.idOferta = double.Parse(reader["idoferta"].ToString());
                        oferta.precio = float.Parse(reader["precio"].ToString());
                        oferta.producto = BaseDatosProducto.ObtenerProducto(double.Parse(reader["idproducto"].ToString()));
                        oferta.tipoMoneda = reader["tipomoneda"].ToString();
                        oferta.usuarioSubasta = BaseDatosUsuario.ObtenerUsuario(reader["nombreusuariosubasta"].ToString());
                        oferta.vencida = (bool)reader["vencida"];
                        ofertas.Add(oferta);
                    }
                }
                return ofertas;
            }
            catch (Exception)
            {
                throw new Exception("Hubo un error con la base de datos, intente de nuevo más tarde");
            }
        }
    }
}
