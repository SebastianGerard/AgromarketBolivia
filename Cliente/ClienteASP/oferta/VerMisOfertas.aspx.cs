﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ClienteASP.oferta
{
    public partial class VerMisOfertas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Verifica si el usuario está logueado o no. 
            ClienteASP.Usuario.ModeloUsuario modeloUsuario = (ClienteASP.Usuario.ModeloUsuario)Session["Usuario"];
            if (!User.Identity.IsAuthenticated || modeloUsuario == null)
                FormsAuthentication.RedirectToLoginPage();
            try
            {
                //Se obtienen las ofertas del servidor y se las pone en el data list
                ClienteASP.Oferta.OfertaClient cliente = new Oferta.OfertaClient();
                ClienteASP.Oferta.ModeloOferta[] oferta = cliente.VerMisOfertas(modeloUsuario.nombreUsuario);
                DataList1.DataSource = oferta;
                DataList1.DataBind();
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
    }
}