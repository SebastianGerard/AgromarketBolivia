
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
        public ModeloUsuario Login(string nombreUsuario, string contrasena)
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

        public bool insertarUsuario(string nombre, string apellido, string direccion, string nombreusuario, string contrasena, string nivelacceso, string email)
        {
            
                try
                {
                    if (this.buscarUsuarioPorNombreUsuario(nombreusuario))
                        throw new Exception("El nombre de usuario ya existe");                    
                    return BaseDatosUsuario.registrarUsuario(nombre, apellido, direccion, nombreusuario, contrasena, nivelacceso, email);

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            

        }
       

    }
}

