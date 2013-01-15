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
	    
        public static void abrirConexion()
        {
           NpgsqlConnection conexion = new NpgsqlConnection( "Server = 127.0.0.1 ; Port=5432; User Id = postgres; Password = Gerard66. ; Database =Agromarket");

            if(conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();
        }
        public static void cerrarConexion()
        {
           NpgsqlConnection conexion = new NpgsqlConnection( "Server = 127.0.0.1 ; Port=5432; User Id = postgres; Password = Gerard66. ; Database =Agromarket");

            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
        public static ModeloUsuario ObtenerUsuario(string nombreUsuario)
        {
            try
            {
               NpgsqlConnection conexion = new NpgsqlConnection( "Server = 127.0.0.1 ; Port=5432; User Id = postgres; Password = Gerard66. ; Database =Agromarket");

                ModeloUsuario usuario = new ModeloUsuario();
                NpgsqlCommand cmd = new NpgsqlCommand("Select * from Usuario where NombreUsuario = @nombre", conexion);
                cmd.Parameters.Add("nombre", nombreUsuario);
                if (conexion.State == System.Data.ConnectionState.Closed)
                    conexion.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    usuario.nombreUsuario = reader["NombreUsuario"].ToString();
                    usuario.contrasena = reader["Contrasena"].ToString();
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