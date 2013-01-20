using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ModeloWCF;

namespace ServicioWCF
{
    [ServiceContract]
    public interface IUsuario
    {
        [OperationContract]
        ModeloUsuario Login(string nombreUsuario, string contrasena);
        [OperationContract]
        List<ModeloUsuario> ObtenerTodosUsuarios();
        [OperationContract]
        List<ModeloUsuario> ObtenerUsuariosConElNombre(string nombre);
        [OperationContract]
        List<ModeloUsuario> ObtenerUsuariosConElApellido(string apellido);
        [OperationContract]
        bool insertarUsuario(string nombre, string apellido, string direccion, string nombreusuario, string contrasena, string nivelacceso, string email);
        [OperationContract]
        bool buscarUsuarioPorNombreUsuario(string nombreUsuario);
    
    }
}
