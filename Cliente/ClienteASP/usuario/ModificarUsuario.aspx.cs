using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ClienteASP.Usuario;

namespace ClienteASP.usuario
{
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        static ModeloUsuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteASP.Usuario.ModeloUsuario modeloUsuario = (ClienteASP.Usuario.ModeloUsuario)Session["Usuario"];
            if (!User.Identity.IsAuthenticated || modeloUsuario == null)
                FormsAuthentication.RedirectToLoginPage();
            else
            {
                if (!IsPostBack)
                {
                    //Se recupera el usuario y se cargan los datos en pantalla
                    usuario = (ModeloUsuario)Session["Usuario"];
                    cargarDatos(usuario);
                }
                
            }
        }

        public void cargarDatos(ModeloUsuario usuario)
        {
            TextBoxNombre.Text = usuario.nombre;
            TextBoxApellido.Text = usuario.apellido;
            TextBoxDirec.Text = usuario.direccion;
            LabelNombreUsuario.Text = usuario.nombreUsuario;
            TextBoxEmail.Text = usuario.email;
        }
        public void resetearLabelErrores()
        {
            LabelError.Text = "";
            LabelErrorApellido.Text = "";
            LabelErrorDireccion.Text = "";
            LabelErrorNombreUsuario.Text = "";
           
            LabelErrorEmail.Text = "";

        }
        public bool validarCampos()
        {
            bool respuesta = false;
            if (TextBoxNombre.Text.Length <= 3)
            {
                respuesta = true;
                LabelError.Text = "El nombre es muy corto, debe ser mas de 2 caracteres";
            }
            if (TextBoxApellido.Text.Length <= 3)
            {
                respuesta = true;
                LabelErrorApellido.Text = "El apellido es muy corto , debe ser mas de 2 caracteres";
            }
            if (TextBoxDirec.Text.Length <= 5)
            {
                respuesta = true;
                LabelErrorDireccion.Text = "La direccion es muy corta, debe ser mas de 5 caracteres";
            }           
           
            if (TextBoxEmail.Text.Length <= 5)
            {
                respuesta = true;
                LabelErrorEmail.Text = "El email es muy corto, debe ser mas de 5 caracteres";
            }

            return respuesta;
        }
        protected void ButtonModificar_Click(object sender, EventArgs e)
        {
            Usuario.UsuarioClient usuario = new Usuario.UsuarioClient();
            //usuario.insertarUsuario();
            resetearLabelErrores();
            try 
            {
                if (!validarCampos())
                {
                    try
                    {
                        //Se llama al método modificar remoto.
                        if (usuario.ModificarUsuario(TextBoxNombre.Text, TextBoxApellido.Text, TextBoxDirec.Text, LabelNombreUsuario.Text, TextBoxEmail.Text))
                        {

                            Server.Transfer("~/usuario/VerPerfil.aspx", true);
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
    }
}