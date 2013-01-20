using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ClienteASP.producto
{
    public partial class RegistroExitoso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteASP.Usuario.ModeloUsuario modeloUsuario = (ClienteASP.Usuario.ModeloUsuario)Session["Usuario"];
            if (!User.Identity.IsAuthenticated || modeloUsuario == null || modeloUsuario.nivelAcceso != "Cliente")
                FormsAuthentication.RedirectToLoginPage();
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["MasterPage"] != null)
            {
                string res = (string)Session["MasterPage"];
                this.MasterPageFile = res;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/About.aspx");
        }
    }
}