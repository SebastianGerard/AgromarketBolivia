using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClienteASP.Usuario;
using System.Web.Security;
namespace ClienteASP
{
    public partial class IngresarLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/usuario/RegistrarUsuario.aspx", true);
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try 
	        {
                UsuarioClient cliente = new UsuarioClient();
                ModeloUsuario usuario = cliente.Login(Login1.UserName, Login1.Password);
                if (usuario.nivelAcceso == "Administrador")
                    Session["MasterPage"] = "~/MasterPages/SiteLoggedAdmin.Master";
                if (usuario.nivelAcceso == "Cliente")
                    Session["MasterPage"] = "~/MasterPages/SiteLoggedClient.Master";
                e.Authenticated = true;
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
                Session["Usuario"] = usuario;
                Response.Redirect("~/About.aspx");
	        }
	        catch (Exception ex)
	        {
		        Login1.PasswordRequiredErrorMessage = ex.Message;
	        }
            
        }
    }
}