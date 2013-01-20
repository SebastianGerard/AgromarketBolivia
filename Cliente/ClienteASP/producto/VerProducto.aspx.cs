using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ClienteASP.producto
{
    public partial class VerProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteASP.Usuario.ModeloUsuario modeloUsuario = (ClienteASP.Usuario.ModeloUsuario)Session["Usuario"];
            if (!User.Identity.IsAuthenticated || modeloUsuario == null)
                FormsAuthentication.RedirectToLoginPage();
            ClienteASP.Producto.ProductoClient cliente = new Producto.ProductoClient();
            try
            {
                ClienteASP.Producto.ModeloProducto producto = cliente.ObtenerProductoPorId(Request.QueryString["id"]);
                LabelCantidad.Text = producto.cantidad.ToString();
                TextBoxDetalle.Text = producto.detalle;
                if (!producto.evaluado)
                {
                    LabelVigente.Text = "SI";
                    ButtonOfertar.Enabled = true;
                }
                else
                {
                    LabelVigente.Text = "NO";
                    ButtonOfertar.Enabled = false;
                }
                LabelFechaOferta.Text= producto.fechaOferta.ToString();
                LabelVencimiento.Text = producto.fechaVencimientoOferta.ToString();
                LabelNombre.Text= producto.nombre;
                LabelMedida.Text = producto.unidad;
                LabelUsuario.Text = producto.Usuario.nombre;
            }
            catch (Exception ex)
            {
                LabelError.Text = ex.Message;
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

        protected void ButtonOfertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/oferta/HacerOferta.aspx?id="+Request.QueryString["id"]);
        }
    }
}