using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClienteASP.Usuario;
using System.Web.Security;

namespace ClienteASP.usuario
{
    public partial class VerPerfil : System.Web.UI.Page
    {
        static ModeloUsuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteASP.Usuario.ModeloUsuario modeloUsuario = (ClienteASP.Usuario.ModeloUsuario)Session["Usuario"];
            if (!User.Identity.IsAuthenticated || modeloUsuario == null)
                FormsAuthentication.RedirectToLoginPage();
            else
            {
                Usuario.UsuarioClient cliente = new UsuarioClient();
                ModeloUsuario temporal = new ModeloUsuario();
                temporal = (ModeloUsuario)Session["Usuario"];
                Session["Usuario"] = cliente.buscarPorNombreusuario(temporal.nombreUsuario);

                usuario = (ModeloUsuario)Session["Usuario"];
                cargarDatos(usuario);
            }
        }
        public void cargarDatos(ModeloUsuario usu)
        {
            LabelNombre.Text = usu.nombre;
            LabelApellido.Text = usu.apellido;
            LabelDireccion.Text = usu.direccion;
            LabelNombreUsuario.Text = usu.nombreUsuario;
            LabelEmail.Text = usu.email;
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["MasterPage"] != null)
            {
                string res = (string)Session["MasterPage"];
                this.MasterPageFile = res;
            }
        }
    }
}