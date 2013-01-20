<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" 
    CodeBehind="RegistrarUsuario.aspx.cs" Inherits="ClienteASP.usuario.RegistrarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <style type="text/css">
         .style2
         {
             text-align: right;
             width: 422px;
         }
         .style3
         {
             text-align: left;
         }
     </style>
     </asp:Content>

<asp:Content ID="Content2"  contentplaceholderid="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Text="Nombre :"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBoxUsuario" runat="server"></asp:TextBox>
                <asp:Label ID="LabelError" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
        <td class="style2">
                <asp:Label ID="Label2" runat="server" Text="Apellido :"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBoxApellido" runat="server"></asp:TextBox>
                <asp:Label ID="LabelErrorApellido" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
        <td class="style2">
                <asp:Label ID="Label3" runat="server" Text="Direccion :"></asp:Label>
                </td>
                <td class="style3">
                <asp:TextBox ID="TextBoxDireccion" runat="server"></asp:TextBox>
                <asp:Label ID="LabelErrorDireccion" runat="server" ForeColor="Red"></asp:Label>
            
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
        <td class="style2">
                <asp:Label ID="Label4" runat="server" Text="Nombre Usuario :"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBoxNombreUsuario" runat="server"></asp:TextBox>
                <asp:Label ID="LabelErrorNombreUsuario" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
        <td class="style2">
                <asp:Label ID="Label5" runat="server" Text="Contrasena :"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBoxContrasena" runat="server" TextMode = "Password"></asp:TextBox>
                <asp:Label ID="LabelErrorContasena" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
         
        <td class="style2">
                <asp:Label ID="Label10" runat="server" Text="Email :"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
                <asp:Label ID="LabelErrorEmail" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
        <td class="style2">
        </td>
        <td class="style3">
        <asp:Button ID="ButtonAceptar" runat="server" Text="Registrar" onclick="ButtonAceptar_Click"/>
        <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" onclick="ButtonCancelar_Click"/>
        </td>
        <td>
                &nbsp;</td>
        </tr>
</table>   

</asp:Content>





