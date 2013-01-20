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
                ModeloUsuario usuario = null;
                NpgsqlCommand cmd = new NpgsqlCommand("Select * from usuario where nombreusuario = @nombre", Conexion.conexion);
                cmd.Parameters.Add("nombre",nombreUsuario);
                Conexion.abrirConexion();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    usuario = new ModeloUsuario();
                    usuario.nombreUsuario = reader["nombreusuario"].ToString();
                    usuario.contrasena = reader["contrasena"].ToString();
                    usuario.apellido = reader["apellido"].ToString();
                    usuario.direccion = reader["direccion"].ToString();
                    usuario.nivelAcceso = reader["nivelacceso"].ToString();
                    usuario.nombre = reader["nombre"].ToString();
                    usuario.email = reader["email"].ToString();
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
                NpgsqlCommand cmd = new NpgsqlCommand("select nombre,apellido,direccion,nombreusuario,email from usuario", Conexion.conexion);
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
                        //usuario.contrasena = reader["contrasena"].ToString();
                       // usuario.nivelAcceso = reader["nivelacceso"].ToString();
                        usuario.email = reader["email"].ToString();
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
                NpgsqlCommand cmd = new NpgsqlCommand("select nombre,apellido,direccion,nombreusuario,email from usuario where nombre like '%" + nombre + "%'", Conexion.conexion);
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
                        //usuario.contrasena = reader["contrasena"].ToString();
                        //usuario.nivelAcceso = reader["nivelacceso"].ToString();
                        usuario.email = reader["email"].ToString();
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
                        usuario.email = reader["email"].ToString();
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

        public static bool registrarUsuario(string nombre, string apellido, string direccion, string nombreusuario, string contrasena, string nivelacceso, string email)
        {
            try 
            {
                NpgsqlCommand cmd = new NpgsqlCommand("Insert into usuario values(@nombre,@apellido,@direccion,@nombreusuario,@contrasena,@nivelacceso,@email)", Conexion.conexion);
                cmd.Parameters.Add("nombre", nombre);
                cmd.Parameters.Add("apellido", apellido);
                cmd.Parameters.Add("direccion", direccion);
                cmd.Parameters.Add("nombreusuario", nombreusuario);
                cmd.Parameters.Add("contrasena", contrasena);
                cmd.Parameters.Add("nivelacceso", nivelacceso);
                cmd.Parameters.Add("email", email);
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

    }
}