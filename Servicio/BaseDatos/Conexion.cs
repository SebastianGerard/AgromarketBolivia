using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace BaseDatos
{
    public static class Conexion
    {
        public static NpgsqlConnection conexion = new NpgsqlConnection("Server = 127.0.0.1 ; Port=5432; User Id = postgres; Password = 1234 ; Database =Agromarket");


        public static void abrirConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();
        }
        public static void cerrarConexion()
        {


            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
    }
}
