<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="RegistrarUsuario.aspx.cs" Inherits="ClienteASP.usuario.RegistrarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     </asp:Content>

<asp:Content ID="Content2"  contentplaceholderid="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style1">
                <asp:Label ID="Label1" runat="server" Text="Nombre :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxUsuario" runat="server"></asp:TextBox>
                <asp:Label ID="LabelError" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
        <td class="style1">
                <asp:Label ID="Label2" runat="server" Text="Apellido :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxApellido" runat="server"></asp:TextBox>
                <asp:Label ID="LabelErrorApellido" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
        <td class="style1">
                <asp:Label ID="Label3" runat="server" Text="Direccion :"></asp:Label>
                </td>
                <td>
                <asp:TextBox ID="TextBoxDireccion" runat="server"></asp:TextBox>
                <asp:Label ID="LabelErrorDireccion" runat="server" ForeColor="Red"></asp:Label>
            
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
        <td class="style1">
                <asp:Label ID="Label4" runat="server" Text="Nombre Usuario :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxNombreUsuario" runat="server"></asp:TextBox>
                <asp:Label ID="LabelErrorNombreUsuario" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
        <td class="style1">
                <asp:Label ID="Label5" runat="server" Text="Contrasena :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxContrasena" runat="server"></asp:TextBox>
                <asp:Label ID="LabelErrorContasena" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
        <td class="style1">
                <asp:Label ID="Label10" runat="server" Text="Email :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
                <asp:Label ID="LabelErrorEmail" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
        <td>
        </td>
        <td>
        <asp:Button ID="ButtonAceptar" runat="server" Text="Registrar" onclick="ButtonAceptar_Click"/>
        <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" onclick="ButtonCancelar_Click"/>
        </td>
        <td>
                &nbsp;</td>
        </tr>
</table>   

</asp:Content>





