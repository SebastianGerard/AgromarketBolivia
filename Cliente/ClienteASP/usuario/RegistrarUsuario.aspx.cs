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
            if (TextBoxUsuario.Text.Length <= 3)
            {
                respuesta = true;
                LabelError.Text = "El nombre es muy corto, debe ser mas de 2 caracteres";
            }
            if (TextBoxApellido.Text.Length <= 3)
            {
                respuesta = true;
                LabelErrorApellido.Text = "El apellido es muy corto , debe ser mas de 2 caracteres";
            }
            if (TextBoxDireccion.Text.Length <= 5)
            {
                respuesta = true;
                LabelErrorDireccion.Text = "La direccion es muy corta, debe ser mas de 5 caracteres";
            }
            if (TextBoxNombreUsuario.Text.Length <= 5)
            {
                respuesta = true;
                LabelErrorNombreUsuario.Text = "El nombre es muy corto, debe ser mas de 5 caracteres";
            }
            if(TextBoxContrasena.Text.Length < 6)
            {
                respuesta = true;
                LabelErrorContasena.Text = "Debe ser de 6 caracteres, debe ser mas de 6 caracteres";
            }
            if (TextBoxEmail.Text.Length <= 5)
            {
                respuesta = true;
                LabelErrorEmail.Text = "El email es muy corto, debe ser mas de 5 caracteres";
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
            try
            {
                  if (validarCampos())
                    { }
                    else
                    {
                        try
                        {
                            //Se llama al método remoto insertar usuario que se encargarga de registrarlo en la base de datos
                            if (usuario.insertarUsuario(TextBoxUsuario.Text, TextBoxApellido.Text, TextBoxDireccion.Text, TextBoxNombreUsuario.Text, TextBoxContrasena.Text, "Cliente", TextBoxEmail.Text))
                            {

                                Server.Transfer("~/usuario/IngresarLogin.aspx", true);
                            }

                        }
                        catch (Exception ex)
                        {

                            LabelError.Text = ex.Message;
                        }
                    }
               
            }
            catch (Exception ex)
            {
                LabelErrorNombreUsuario.Text = "Debes escribir un nombre de usuario"; 
            }
                
     
            
        }
        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("IngresarLogin.aspx");
            Server.Transfer("~/usuario/IngresarLogin.aspx", true);
        }
    }
}