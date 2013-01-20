using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModeloWCF;
using Npgsql;
using System.Drawing;
using Utilidad;

namespace BaseDatos
{
    public static class BaseDatosProducto
    {
        public static List<ModeloProducto> ObtenerTodosProductos()
        {
            try
            {
                List<ModeloProducto> productos = null;
                NpgsqlCommand cmd = new NpgsqlCommand("Select * from producto where fechavencimientooferta>=@date and evaluado='false'",Conexion.conexion);
                cmd.Parameters.Add("date",DateTime.Now.Date);
                Conexion.abrirConexion();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    productos = new List<ModeloProducto>();
                    while (reader.Read())
                    {
                        ModeloProducto producto = new ModeloProducto();
                        producto.idProducto = double.Parse(reader["idproducto"].ToString());
                        producto.cantidad = float.Parse(reader["cantidad"].ToString());
                        producto.detalle = reader["detalle"].ToString();
                        producto.fechaOferta = DateTime.Parse(reader["fechaoferta"].ToString());
                        producto.fechaVencimientoOferta = DateTime.Parse(reader["fechavencimientooferta"].ToString());
                        producto.nombre = reader["nombre"].ToString();
                        producto.unidad = reader["unidad"].ToString();
                        producto.Usuario = BaseDatosUsuario.ObtenerUsuario(reader["nombreusuariodueno"].ToString());
                        producto.evaluado = (bool)reader["evaluado"];
                        
                        productos.Add(producto);
                    }
                }
                Conexion.cerrarConexion();
                return productos;
            }
            catch (Exception ex)
            {
                
                throw new Exception("Hubo un error con la base de datos, intente de nuevo más tarde");
            }
        }
        public static float ObtenerCantidadProducto(double idProducto)
        {
            try
            {
                float cantidad = -1;
                NpgsqlCommand cmd = new NpgsqlCommand("Select cantidad from producto where idproducto=@idproducto",Conexion.conexion);
                cmd.Parameters.Add("idproducto",idProducto);
                Conexion.abrirConexion();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    cantidad = float.Parse(reader["cantidad"].ToString());
                }
                return cantidad;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public static ModeloProducto ObtenerProducto(double idProducto)
        {
            try
            {
                ModeloProducto producto = null;
                NpgsqlCommand cmd = new NpgsqlCommand("Select * from producto where idproducto=@idproducto", Conexion.conexion);
                cmd.Parameters.Add("idproducto", idProducto);
                Conexion.abrirConexion();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    producto = new ModeloProducto();
                    producto.cantidad = float.Parse(reader["cantidad"].ToString());
                    producto.detalle = reader["detalle"].ToString();
                    producto.fechaOferta = DateTime.Parse(reader["fechaoferta"].ToString());
                    producto.fechaVencimientoOferta = DateTime.Parse(reader["fechavencimientooferta"].ToString());
                    producto.idProducto = double.Parse(reader["idproducto"].ToString());
                    producto.nombre = reader["nombre"].ToString();
                    producto.unidad = reader["unidad"].ToString();
                    producto.Usuario = BaseDatosUsuario.ObtenerUsuario(reader["nombreusuariodueno"].ToString());
                    producto.evaluado = (bool)reader["evaluado"];
                    
                }
                return producto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<ModeloProducto> ObtenerProductosConElNombre(string nombre)
        {
            try
            {
                List<ModeloProducto> productos = new List<ModeloProducto>();
                NpgsqlCommand cmd = new NpgsqlCommand("Select * from producto where fechavencimientooferta>=@date and evaluado='false' and nombre like '%"+nombre+"%'", Conexion.conexion);
                cmd.Parameters.Add("date",DateTime.Now.Date);
                Conexion.abrirConexion();
                NpgsqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    productos = new List<ModeloProducto>();
                    while (reader.Read())
                    {
                        ModeloProducto producto = new ModeloProducto();
                        producto.idProducto = double.Parse(reader["idproducto"].ToString());
                        producto.cantidad = float.Parse(reader["cantidad"].ToString());
                        producto.detalle = reader["detalle"].ToString();
                        producto.fechaOferta = DateTime.Parse(reader["fechaoferta"].ToString());
                        producto.fechaVencimientoOferta = DateTime.Parse(reader["fechavencimientooferta"].ToString());
                        producto.nombre = reader["nombre"].ToString();
                        producto.Usuario = BaseDatosUsuario.ObtenerUsuario(reader["nombreusuariodueno"].ToString());
                        producto.unidad = reader["unidad"].ToString();
                        producto.evaluado = (bool)reader["evaluado"];
                        
                        productos.Add(producto);
                    }
                }
                Conexion.cerrarConexion();
                return productos;
            }
            catch (Exception)
            {
                
                throw new Exception("Hubo un error con la base de datos, intente de nuevo más tarde");
            }
        }
        public static bool registrarProducto(string nombre, string cantidad, string unidad, string fechavencimientooferta, string detalle, string nombreusuariodueno)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("Insert into producto (nombre,detalle,cantidad,fechaoferta,fechavencimientooferta,nombreusuariodueno,unidad,evaluado) values(@nombre, @detalle,@cantidad,  @fechaoferta, @fechavencimientooferta, @nombreusuariodueno,@unidad,'false')", Conexion.conexion);
                //NO SE INSERTA IDPRODUCTO, PORQ ES AUTOGENERADO DE TIPO'SERIAL'
                cmd.Parameters.Add("nombre", nombre);
                cmd.Parameters.Add("cantidad", cantidad);
                cmd.Parameters.Add("unidad", unidad);
                cmd.Parameters.Add("fechaoferta", DateTime.Now.Date.ToShortDateString()); // Fecha de oferta siempre es la de hoy
                cmd.Parameters.Add("fechavencimientooferta", fechavencimientooferta);
                cmd.Parameters.Add("detalle", detalle);
                cmd.Parameters.Add("nombreusuariodueno", nombreusuariodueno);
                Conexion.abrirConexion();
                if (cmd.ExecuteNonQuery() != -1)
                {
                    Conexion.cerrarConexion();
                    return true;
                }
                else
                {
                    Conexion.cerrarConexion();
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error con la base de datos, intente de nuevo más tarde");
            }
        }
        //public static bool eliminarproducto()
        public static List<ModeloProducto> ProductosNoEvaluados()
        {
            try
            {
                List<ModeloProducto> productos = null;
                NpgsqlCommand cmd = new NpgsqlCommand("Select * from producto where evaluado='false'", Conexion.conexion);
                Conexion.abrirConexion();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    productos = new List<ModeloProducto>();
                    while (reader.Read())
                    {
                        ModeloProducto producto = new ModeloProducto();
                        producto.cantidad = float.Parse(reader["cantidad"].ToString());
                        producto.detalle = reader["cantidad"].ToString();
                        producto.evaluado = (bool)reader["evaluado"];
                        producto.fechaOferta = DateTime.Parse(reader["fechaoferta"].ToString());
                        producto.fechaVencimientoOferta = DateTime.Parse(reader["fechavencimientooferta"].ToString());
                        producto.idProducto = Double.Parse(reader["idproducto"].ToString());
                        producto.unidad = reader["unidad"].ToString();
                        producto.Usuario = BaseDatosUsuario.ObtenerUsuario(reader["nombreusuariodueno"].ToString());
                        
                        productos.Add(producto);
                    }
                }
                Conexion.cerrarConexion();
                return productos;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public static void CambiarEstadoAEvaluado(double idProducto)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("Update producto set evaluado='true' where idproducto=@id",Conexion.conexion);
                cmd.Parameters.Add("id",idProducto);
                Conexion.abrirConexion();
                cmd.ExecuteNonQuery();
                Conexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
