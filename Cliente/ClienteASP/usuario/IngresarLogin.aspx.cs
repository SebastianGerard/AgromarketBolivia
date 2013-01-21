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
        //Evento para autenticar al cliente
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try 
	        {
                //Se llama al método remoto Login para ver si los datos son correctos
                UsuarioClient cliente = new UsuarioClient();
                ModeloUsuario usuario = cliente.Login(Login1.UserName, Login1.Password);
                //Definicion de que master page utilizar respecto al nivel de acceso
                if (usuario.nivelAcceso == "Administrador")
                    Session["MasterPage"] = "~/MasterPages/SiteLoggedAdmin.Master";
                if (usuario.nivelAcceso == "Cliente")
                    Session["MasterPage"] = "~/MasterPages/SiteLoggedClient.Master";
                //Usuario autenticado
                e.Authenticated = true;
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
                //Se almacena al usuario en una sesión global definida en el archivo Global.asax
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