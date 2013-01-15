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
        static NpgsqlConnection conexion = new NpgsqlConnection("Server = 127.0.0.1 ; Port=5432; User Id = postgres; Password = Gerard66. ; Database =Agromarket");

            
        public static void abrirConexion()
        {
           if(conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();
        }
        public static void cerrarConexion()
        {
           

            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
        public static ModeloUsuario ObtenerUsuario(string nombreUsuario)
        {
            try
            {
                ModeloUsuario usuario = new ModeloUsuario();
                NpgsqlCommand cmd = new NpgsqlCommand("Select * from usuario where nombreusuario = @nombre", conexion);
                cmd.Parameters.Add("nombre", nombreUsuario);
                abrirConexion();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    usuario.nombreUsuario = reader["nombreusuario"].ToString();
                    usuario.contrasena = reader["contrasena"].ToString();
                }
                cerrarConexion();
                return usuario;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }
    }
}