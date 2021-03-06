﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteASP
{
    public partial class IngresarLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario.UsuarioClient usuario = new Usuario.UsuarioClient();
                bool entro = usuario.Login(TextBoxUsuario.Text, TextBoxContrasena.Text);
                if (entro)
                {
                    LabelError.Text = "OK, está adentro y deberia dirigirse a otra página :)";
                    
                }
                else
                {
                    LabelError.Text = "Error";
                }
            }
            catch (Exception ex)
            {

                LabelError.Text = ex.Message;
            }
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/usuario/RegistrarUsuario.aspx", true);
        }
    }
}