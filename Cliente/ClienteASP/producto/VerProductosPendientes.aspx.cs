using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ClienteASP.oferta
{
    public partial class VerProductosPendientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteASP.Usuario.ModeloUsuario modeloUsuario = (ClienteASP.Usuario.ModeloUsuario)Session["Usuario"];
            if (!User.Identity.IsAuthenticated || modeloUsuario == null)
                FormsAuthentication.RedirectToLoginPage();
            if (!IsPostBack)
            {
                ClienteASP.Producto.ProductoClient cliente = new Producto.ProductoClient();
                ClienteASP.Producto.ModeloProducto[] productos = cliente.ObtenerProductosNoEvaluados();
                DataList1.DataSource = productos;
                DataList1.DataBind();
            }
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["MasterPage"] != null)
            {
                string res = (string)Session["MasterPage"];
                this.MasterPageFile = res;
            }
        }

        

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Ver")
            {
                Label label = (Label)e.Item.FindControl("LabelNro");
                Response.Redirect("~/oferta/Evaluar.aspx?id=" + label.Text);
            }
        }
    }
}