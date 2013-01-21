using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ClienteASP.Oferta
{
    public partial class HacerOferta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ClienteASP.Usuario.ModeloUsuario modeloUsuario = (ClienteASP.Usuario.ModeloUsuario)Session["Usuario"];
                if (!User.Identity.IsAuthenticated || modeloUsuario == null)
                    FormsAuthentication.RedirectToLoginPage();
                
                ClienteASP.Producto.ProductoClient cliente = new Producto.ProductoClient();
                ClienteASP.Producto.ModeloProducto producto = cliente.ObtenerProductoPorId(Request.QueryString["id"]);
                if (producto.evaluado == true)
                {
                    LabelError.Text = "El producto ya fue evaluado, imposible realizar la oferta";
                    ButtonOfertar.Enabled = false;
                }
                else
                    ButtonOfertar.Enabled = true;
                LabelPropietario.Text = producto.Usuario.nombre;
                LabelProducto.Text = producto.nombre;
                LabelCantidad.Text = producto.cantidad.ToString();
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
            try
            {
                LabelError.Text = "";
                ClienteASP.Producto.ProductoClient clientep = new Producto.ProductoClient();
                ClienteASP.Producto.ModeloProducto producto =clientep.ObtenerProductoPorId( Request.QueryString["id"]);
                ClienteASP.Usuario.ModeloUsuario usuario = (Usuario.ModeloUsuario)Session["Usuario"];
                if(producto.evaluado==true)
                {
                    LabelError.Text = "El producto ya fue evaluado, imposible realizar la oferta";
                    ButtonOfertar.Enabled=false;
                }
                else
                {
                    ClienteASP.Oferta.OfertaClient cliente = new OfertaClient();
                    cliente.OfrecerOferta(TextBoxCantidad.Text, TextBoxPrecio.Text, producto.idProducto.ToString(), usuario.nombreUsuario, DropDownList1.SelectedItem.ToString());
                    Response.Redirect("OfertaExitosa.aspx");
                }
                
            }
            catch (Exception ex)
            {

                LabelError.Text = ex.Message; ;
            }
        }
    }
}