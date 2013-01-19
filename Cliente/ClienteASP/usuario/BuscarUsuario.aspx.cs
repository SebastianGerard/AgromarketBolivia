using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteASP.usuario
{
    public partial class BuscarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario.UsuarioClient usuario = new Usuario.UsuarioClient();
            GridViewUsuario.DataSource = usuario.ObtenerTodosUsuarios();
            GridViewUsuario.DataBind();
        }

        protected void GridViewUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}