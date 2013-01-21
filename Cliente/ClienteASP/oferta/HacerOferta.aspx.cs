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
                //Método para ver si el usuario está logueado o no.
                ClienteASP.Usuario.ModeloUsuario modeloUsuario = (ClienteASP.Usuario.ModeloUsuario)Session["Usuario"];
                if (!User.Identity.IsAuthenticated || modeloUsuario == null)
                    FormsAuthentication.RedirectToLoginPage();
                //Declaro un cliente del servicio producto
                ClienteASP.Producto.ProductoClient cliente = new Producto.ProductoClient();
                //Declaro un objeto del servicio, de tipo Modelo Producto y obtengo el producto por el id recibido por parámetro
                ClienteASP.Producto.ModeloProducto producto = cliente.ObtenerProductoPorId(Request.QueryString["id"]);
                //Si el producto fue evaluado no se pueden realizar más ofertas porq ya tiene un dueño
                if (producto.evaluado == true)
                {
                    LabelError.Text = "El producto ya fue evaluado, imposible realizar la oferta";
                    ButtonOfertar.Enabled = false;
                }
                    //si no habilitamos el botón para poder realizar ofertas
                else
                    ButtonOfertar.Enabled = true;
                //Ponemos los datos por pantalla
                LabelPropietario.Text = producto.Usuario.nombre;
                LabelProducto.Text = producto.nombre;
                LabelCantidad.Text = producto.cantidad.ToString();
            }
            catch (Exception ex)
            {
                
                LabelError.Text = ex.Message;
            }
            

        }
        //Método para reconocer qué master page utilizar
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
                //Lo mismo que en Page Load para evitar que se trabaje con datos inconsistentes en caso de que el cliente modifique el id de la URL
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