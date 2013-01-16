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

    }
}