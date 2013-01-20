using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ClienteASP.Usuario;

namespace ClienteASP.usuario
{
    public partial class BuscarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ModeloUsuario modeloUsuario = (ModeloUsuario)Session["Usuario"];
            if (!User.Identity.IsAuthenticated || modeloUsuario==null || modeloUsuario.nivelAcceso!="Administrador" )
                FormsAuthentication.RedirectToLoginPage();
            Usuario.UsuarioClient usuario = new Usuario.UsuarioClient();
            
            GridViewUsuario.DataSource = usuario.ObtenerTodosUsuarios();
            GridViewUsuario.DataBind();
        }

        protected void GridViewUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["MasterPage"] != null)
            {
                string res = (string)Session["MasterPage"];
                this.MasterPageFile = res;
            }
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario.UsuarioClient usuario = new Usuario.UsuarioClient();
                GridViewUsuario.DataSource = usuario.ObtenerUsuariosConElNombre(TextBoxBuscar.Text);
               
                GridViewUsuario.DataBind();
                GridViewUsuario.Columns[1].Visible = false;
                GridViewUsuario.Columns[4].Visible = false;
                
            }
            catch (Exception ex)
            {
                LabelError.Text = ex.Message;
            }
                
        }
    }
}