using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ClienteASP.usuario
{
    public partial class RegistrarUsuario : System.Web.UI.Page
    {
        public void resetearLabelErrores()
        {
            LabelError.Text = "";
            LabelErrorApellido.Text = "";
            LabelErrorDireccion.Text = "";
            LabelErrorNombreUsuario.Text = "";
            LabelErrorContasena.Text = "";
            LabelErrorEmail.Text =  "";
 
        }
        public bool validarCampos()
        {
            bool respuesta = false;
            if (TextBoxUsuario.Text.Length < 5)
            {
                respuesta = true;
                LabelError.Text = "El nombre es muy corto";
            }
            if (TextBoxApellido.Text.Length < 5)
            {
                respuesta = true;
                LabelErrorApellido.Text = "El apellido es muy corto";
            }
            if (TextBoxDireccion.Text.Length < 7)
            {
                respuesta = true;
                LabelErrorDireccion.Text = "La direccion es muy corta";
            }
            if (TextBoxNombreUsuario.Text.Length < 5)
            {
                respuesta = true;
                LabelErrorNombreUsuario.Text = "El nombre es muy corto";
            }
            if(TextBoxContrasena.Text.Length < 6)
            {
                respuesta = true;
                LabelErrorContasena.Text = "Debe ser de 6 caracteres";
            }
            if (TextBoxEmail.Text.Length < 5)
            {
                respuesta = true;
                LabelErrorEmail.Text = "El email es muy corto";
            }

            return respuesta;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Usuario.UsuarioClient usuario = new Usuario.UsuarioClient();
            //usuario.insertarUsuario();
            resetearLabelErrores();
            if (usuario.buscarUsuarioPorNombreUsuario(TextBoxNombreUsuario.Text))
            {
                LabelErrorNombreUsuario.Text = "Nombre ya existe";
            }
            else
            {
                if (validarCampos())
                { }
                else
                {
                    try
                    {
                        if (usuario.insertarUsuario(TextBoxUsuario.Text, TextBoxApellido.Text, TextBoxDireccion.Text, TextBoxNombreUsuario.Text, TextBoxContrasena.Text, "admin", TextBoxEmail.Text))
                        {
                            
                            Server.Transfer("~/IngresarLogin.aspx", true); 
                        }
                        
                    }
                    catch (Exception ex)
                    {

                        LabelError.Text = ex.Message;
                    }
                }
            }
     
            
        }
        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("IngresarLogin.aspx");
            Server.Transfer("~/IngresarLogin.aspx", true);
        }
    }
}