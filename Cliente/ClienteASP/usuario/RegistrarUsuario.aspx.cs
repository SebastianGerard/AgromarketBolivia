using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ClienteASP.usuario
{
    public partial class RegistrarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Usuario.UsuarioClient usuario = new Usuario.UsuarioClient();
            //usuario.insertarUsuario();
        }
        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("IngresarLogin.aspx");
            Server.Transfer("~/IngresarLogin.aspx", true);
        }
    }
}