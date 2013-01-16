using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModeloWCF;
using Npgsql;

namespace BaseDatos
{
    public static class BaseDatosProducto
    {
        public static List<ModeloProducto> ObtenerTodosProductos()
        {
            try
            {
                List<ModeloProducto> productos = null;
                NpgsqlCommand cmd = new NpgsqlCommand("Select * from producto",Conexion.conexion);
                Conexion.abrirConexion();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    productos = new List<ModeloProducto>();
                    while (reader.Read())
                    {
                        ModeloProducto producto = new ModeloProducto();
                        producto.cantidad = float.Parse(reader["cantidad"].ToString());
                        producto.detalle = reader["detalle"].ToString();
                        producto.fechaOferta = DateTime.Parse(reader["fechaoferta"].ToString());
                        producto.fechaVencimientoOferta = DateTime.Parse(reader["fechavencimientooferta"].ToString());
                        producto.nombre = reader["nombre"].ToString();
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
                
                throw new Exception("Hubo un error con la base de datos, intente de nuevo más tarde");
            }
        }
        public static List<ModeloProducto> ObtenerProductosConElNombre(string nombre)
        {
            try
            {
                List<ModeloProducto> productos = new List<ModeloProducto>();
                NpgsqlCommand cmd = new NpgsqlCommand("Select * from producto where nombre like '%"+nombre+"%'",Conexion.conexion);
                Conexion.abrirConexion();
                NpgsqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    productos = new List<ModeloProducto>();
                    while (reader.Read())
                    {
                        ModeloProducto producto = new ModeloProducto();
                        producto.cantidad = float.Parse(reader["cantidad"].ToString());
                        producto.detalle = reader["detalle"].ToString();
                        producto.fechaOferta = DateTime.Parse(reader["fechaoferta"].ToString());
                        producto.fechaVencimientoOferta = DateTime.Parse(reader["fechavencimientooferta"].ToString());
                        producto.nombre = reader["nombre"].ToString();
                        producto.Usuario = BaseDatosUsuario.ObtenerUsuario(reader["nombreusuariodueno"].ToString());
                        producto.unidad = reader["unidad"].ToString();
                        productos.Add(producto);
                    }
                }
                Conexion.cerrarConexion();
                return productos;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
