using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
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
                }
                Conexion.cerrarConexion();
                return usuario;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }
    }
}