using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Windows.Forms;
using ClienteASP.Producto;
using Utilidad;
using System.Drawing;
using System.Web.Security;
namespace ClienteASP.producto

{
    
    public partial class Registrar_producto : System.Web.UI.Page
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
        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoClient cliente = new ProductoClient();
                ClienteASP.Usuario.ModeloUsuario usuario = (ClienteASP.Usuario.ModeloUsuario)Session["Usuario"];
                cliente.registrarproducto(TextBoxNombre.Text,TextBoxCantidad.Text,TextBoxUnidad.Text,TextBoxDetalle.Text,Calendar1.SelectedDate.ToString(),usuario.nombreUsuario);
                Response.Redirect("RegistroExitoso.aspx");
            }
            catch (Exception ex)
            {

                LabelError.Text = ex.Message;
            }
        }
    }
}