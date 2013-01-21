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
                    string id = Request.QueryString["id"];
                    ClienteASP.Oferta.ModeloOferta[] ofertas = cliente.VerOfertasDelProducto(id);
                    DataList1.DataSource = ofertas;
                    DataList1.DataBind();
                }
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
                foreach (DataListItem item in DataList1.Items)
                {
                    CheckBox ch = (CheckBox)item.FindControl("CheckBox1");
                    if (ch.Checked == true)
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
                cliente.EscogerEstasOfertas(ofertasGanadoras, ofertasPerdedoras);
            }
            catch (Exception ex)
            {
                
                LabelError.Text = ex.Message;
            }
            
        }
    }
}