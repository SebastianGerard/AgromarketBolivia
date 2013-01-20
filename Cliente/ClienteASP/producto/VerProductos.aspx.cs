using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ClienteASP.producto
{
    public partial class VerProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteASP.Usuario.ModeloUsuario modeloUsuario = (ClienteASP.Usuario.ModeloUsuario)Session["Usuario"];
            if (!User.Identity.IsAuthenticated || modeloUsuario == null)
                FormsAuthentication.RedirectToLoginPage();
            if (!IsPostBack)
            {
                ClienteASP.Producto.ProductoClient cliente = new Producto.ProductoClient();
                ClienteASP.Producto.ModeloProducto[] productos = cliente.ObtenerTodosProductos();
                DataList1.DataSource = productos;
                DataList1.DataBind();
            }
            else
            {
                Session["ABuscar"] = TextBox1.Text;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteASP.Producto.ProductoClient cliente = new Producto.ProductoClient();
                string palabra = Session["ABuscar"].ToString();
                ClienteASP.Producto.ModeloProducto[] productos = cliente.ObtenerProductosConElNombre(TextBox1.Text);
                DataList1.DataSource = productos;
                DataList1.DataBind();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}