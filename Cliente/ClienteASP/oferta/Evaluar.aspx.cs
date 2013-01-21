using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ClienteASP.oferta
{
    public partial class Evaluar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ClienteASP.Usuario.ModeloUsuario modeloUsuario = (ClienteASP.Usuario.ModeloUsuario)Session["Usuario"];
                if (!User.Identity.IsAuthenticated || modeloUsuario == null || modeloUsuario.nivelAcceso == "Cliente")
                    FormsAuthentication.RedirectToLoginPage();
                if (!IsPostBack)
                {
                    
                    ClienteASP.Oferta.OfertaClient cliente = new Oferta.OfertaClient();
                    string id = Request.QueryString["id"]; //Recupero el parámetro id. que recibí desde la anterior página
                    ClienteASP.Oferta.ModeloOferta[] ofertas = cliente.VerOfertasDelProducto(id); //Recibo las ofertas del producto con ese id
                    //Las ofertas se desplegan en el datalist
                    DataList1.DataSource = ofertas;
                    DataList1.DataBind();
                }
            }
            catch (Exception ex)
            {
                
                LabelError.Text = ex.Message;
            }
            
        }
        //Método para ver qué master page estoy utilizando 
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["MasterPage"] != null)
            {
                string res = (string)Session["MasterPage"];
                this.MasterPageFile = res;
            }
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["id"];
                Oferta.OfertaClient cliente = new Oferta.OfertaClient();
                ClienteASP.Oferta.ModeloOferta[] ofertas = cliente.VerOfertasDelProducto(id);
                ClienteASP.Oferta.ModeloOferta[] ofertasGanadoras = new Oferta.ModeloOferta[100];
                ClienteASP.Oferta.ModeloOferta[] ofertasPerdedoras = new Oferta.ModeloOferta[100];

                int i = 0;
                int indG = 0;
                int indP = 0;
                //Las ofertas seleccionadas se separan de las que no fueron seleccionadas
                foreach (DataListItem item in DataList1.Items)
                {
                    CheckBox ch = (CheckBox)item.FindControl("CheckBox1"); // recupero el control checkbox1
                    if (ch.Checked == true)//si el check box de esa oferta está tiqueado
                    {
                        ofertasGanadoras[indG] = new Oferta.ModeloOferta();
                        ofertasGanadoras[indG] = ofertas[i];
                        indG++;
                    }
                    else
                    {
                        ofertasPerdedoras[indP] = new Oferta.ModeloOferta();
                        ofertasPerdedoras[indP] = ofertas[i];
                        indP++;
                    }
                    i++;
                }
                cliente.EscogerEstasOfertas(ofertasGanadoras, ofertasPerdedoras); //Método que llama a escoger ofertas.
            }
            catch (Exception ex)
            {
                
                LabelError.Text = ex.Message;
            }
            
        }
    }
}