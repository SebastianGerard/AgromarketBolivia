using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModeloWCF;
using Npgsql;
using Mono.Security;
namespace BaseDatos
{
    public static class BaseDatosUsuario
    {
       
       public static ModeloUsuario ObtenerUsuario(string nombreUsuario)
        {
            try
            {
                ModeloUsuario usuario = new ModeloUsuario();
                NpgsqlCommand cmd = new NpgsqlCommand("Select * from usuario where nombreusuario = @nombre", Conexion.conexion);
                cmd.Parameters.Add("nombre",nombreUsuario);
                Conexion.abrirConexion();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    usuario.nombreUsuario = reader["nombreusuario"].ToString();
                    usuario.contrasena = reader["contrasena"].ToString();
                    usuario.apellido = reader["apellido"].ToString();
                    usuario.direccion = reader["direccion"].ToString();
                    usuario.nivelAcceso = reader["nivelacceso"].ToString();
                    usuario.nombre = reader["nombre"].ToString();
                }
                Conexion.cerrarConexion();
                return usuario;
            }
            catch (Exception ex)
            {
                
                throw new Exception("Hubo un error con la base de datos");
            }
            
        }

        public static List<ModeloUsuario> ObtenerTodosUsuarios()
        {
            try 
            {
                List<ModeloUsuario> usuarios = null;
                NpgsqlCommand cmd = new NpgsqlCommand("select * from usuario", Conexion.conexion);
                Conexion.abrirConexion();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    usuarios = new List<ModeloUsuario>();
                    while (reader.Read())
                    {
                        ModeloUsuario usuario = new ModeloUsuario();
                        usuario.nombre = reader["nombre"].ToString();
                        usuario.apellido = reader["apellido"].ToString();
                        usuario.direccion = reader["direccion"].ToString();
                        usuario.nombreUsuario = reader["nombreusuario"].ToString();
                        usuario.contrasena = reader["contrasena"].ToString();
                        usuario.nivelAcceso = reader["nivelacceso"].ToString();
                        usuarios.Add(usuario);
                    }
                }
                Conexion.cerrarConexion();
                return usuarios;

            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error con la base de datos, intente de nuevo más tarde"); 
            }
        }

        public static List<ModeloUsuario> obtenerUsuariosConElNombre(string nombre)
        {
            try
            {
                List<ModeloUsuario> usuarios = null;
                NpgsqlCommand cmd = new NpgsqlCommand("select * from usuario where nombre like '%" + nombre + "%'", Conexion.conexion);
                Conexion.abrirConexion();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    usuarios = new List<ModeloUsuario>();
                    while (reader.Read())
                    {
                        ModeloUsuario usuario = new ModeloUsuario();
                        usuario.nombre = reader["nombre"].ToString();
                        usuario.apellido = reader["apellido"].ToString();
                        usuario.direccion = reader["direccion"].ToString();
                        usuario.nombreUsuario = reader["nombreusuario"].ToString();
                        usuario.contrasena = reader["contrasena"].ToString();
                        usuario.nivelAcceso = reader["nivelacceso"].ToString();
                        usuarios.Add(usuario);
                    }
                }
                Conexion.cerrarConexion();
                return usuarios;

            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error con la base de datos, intente de nuevo más tarde");
            } 
        }

        public static List<ModeloUsuario> obtenerUsuariosConElApellido(string apellido)
        {
            try
            {
                List<ModeloUsuario> usuarios = null;
                NpgsqlCommand cmd = new NpgsqlCommand("select * from usuario where apellido like '%" + apellido + "%'", Conexion.conexion);
                Conexion.abrirConexion();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    usuarios = new List<ModeloUsuario>();
                    while (reader.Read())
                    {
                        ModeloUsuario usuario = new ModeloUsuario();
                        usuario.nombre = reader["nombre"].ToString();
                        usuario.apellido = reader["apellido"].ToString();
                        usuario.direccion = reader["direccion"].ToString();
                        usuario.nombreUsuario = reader["nombreusuario"].ToString();
                        usuario.contrasena = reader["contrasena"].ToString();
                        usuario.nivelAcceso = reader["nivelacceso"].ToString();
                        usuarios.Add(usuario);
                    }
                }
                Conexion.cerrarConexion();
                return usuarios;

            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error con la base de datos, intente de nuevo más tarde");
            }
        }    

    }
}