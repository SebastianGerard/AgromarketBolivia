
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ModeloWCF;
using BaseDatos;

namespace ServicioWCF
{
    public class Usuario : IUsuario
    {

        //Metodo que permite el acceso al sistema, devolviendo un usuario en caso de que los datos recibidos coincidan
        //con los de la base de datos del sistema.
        public ModeloUsuario Login(string nombreUsuario, string contrasena)
        {
            try
            {
                ModeloUsuario modeloUsuario = BaseDatosUsuario.ObtenerUsuario(nombreUsuario);
                if (modeloUsuario == null)
                    throw new Exception("Nombre de usuario o contraseña inválidas");
                return modeloUsuario;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }
        //Busca un usuario que contenga el nombre recibido
        public ModeloUsuario buscarPorNombreusuario(string nombreUsuario)
        {
            try
            {
                //TODO acceso a BaseDatos Consultando si es correcto o no.
                ModeloUsuario modeloUsuario = BaseDatosUsuario.ObtenerUsuario(nombreUsuario);
                if (modeloUsuario == null)
                    throw new Exception("Nombre de usuario o contraseña inválidas");
                return modeloUsuario;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //Método que permite ver si el usuario está en el sistema.
        public bool buscarUsuarioPorNombreUsuario(string nombreUsuario)
        {
            try
            {
                    //TODO acceso a BaseDatos Consultando si es correcto o no.
                    ModeloUsuario modeloUsuario = BaseDatosUsuario.ObtenerUsuario(nombreUsuario);
                    if (modeloUsuario == null)
                        throw new Exception("No se encontró ningún usuario");
                    return (modeloUsuario.nombreUsuario == nombreUsuario);
                
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //Método usado internamente
        private bool buscarUsuarioPorNombreUsuario1(string nombreUsuario)
        {
            try
            {
                //TODO acceso a BaseDatos Consultando si es correcto o no.
                ModeloUsuario modeloUsuario = BaseDatosUsuario.ObtenerUsuario(nombreUsuario);
                if (modeloUsuario == null)
                    return false;
                else
                    return true;                

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //Método para obtener todos los usuarios
        public List<ModeloUsuario> ObtenerTodosUsuarios()
        {
            try
            {
                List<ModeloUsuario> usuarios = BaseDatosUsuario.ObtenerTodosUsuarios();
                if (usuarios == null)
                    throw new Exception("No se encontró ningún usuario");
                return usuarios;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //Método para buscar usuarios cuyos nombres coincidan con el recibido
        public List<ModeloUsuario> ObtenerUsuariosConElNombre(string nombre)
        {
            try
            {
                List<ModeloUsuario> usuarios = BaseDatosUsuario.obtenerUsuariosConElNombre(nombre);
                if (usuarios == null)
                    throw new Exception("No se encontró ningún usuario");
                return usuarios;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //Metodo para buscar usuario cuyos apellidos coincidan con el recibido
        public List<ModeloUsuario> ObtenerUsuariosConElApellido(string apellido)
        {
            try
            {
                List<ModeloUsuario> usuarios = BaseDatosUsuario.obtenerUsuariosConElApellido(apellido);
                if (usuarios == null)
                    throw new Exception("No se encontró ningún usuario");
                return usuarios;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //Metodo para registrar un usuario.
        public bool insertarUsuario(string nombre, string apellido, string direccion, string nombreusuario, string contrasena, string nivelacceso, string email)
        {
            
                try
                {
                    if (this.buscarUsuarioPorNombreUsuario1(nombreusuario))
                        throw new Exception("El nombre de usuario ya existe");                  
                    return BaseDatosUsuario.registrarUsuario(nombre, apellido, direccion, nombreusuario, contrasena, nivelacceso, email);

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            

        }

        //Médoto para modificar un usuario.
        public bool ModificarUsuario(string nombre, string apellido, string direccion, string nombreusuario, string email)
        {
            try
            {
               
                return BaseDatosUsuario.ModificarUsuario(nombre, apellido, direccion, nombreusuario, email);

            }
            catch (Exception ex)
            {

                throw ex;
            } 
        }
       

    }
}

