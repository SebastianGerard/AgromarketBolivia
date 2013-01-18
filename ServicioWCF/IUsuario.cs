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
        bool Login(string nombreUsuario, string contrasena);
        [OperationContract]
        List<ModeloUsuario> ObtenerTodosUsuarios();
        [OperationContract]
        List<ModeloUsuario> ObtenerUsuariosConElNombre(string nombre);
        [OperationContract]
        List<ModeloUsuario> ObtenerUsuariosConElApellido(string apellido);
        [OperationContract]
        bool registrarUsuario(string nombre, string apellido, string direccion, string nombreusuario, string contrasena, string nivelacceso, string email);
    
    }
}
