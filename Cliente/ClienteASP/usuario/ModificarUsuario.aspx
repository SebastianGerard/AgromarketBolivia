<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SiteLoggedClient.Master" AutoEventWireup="true" 
    CodeBehind="ModificarUsuario.aspx.cs" Inherits="ClienteASP.usuario.ModificarUsuario" %>

    <asp:Content ID="Content2"  contentplaceholderid="MainContent" runat="server">
        <table style="width:100%; margin-left: 87px;">
        <tr>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Text="Nombre :"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBoxNombre" runat="server"></asp:TextBox>
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
                <asp:TextBox ID="TextBoxDirec" runat="server"></asp:TextBox>
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
                <asp:Label ID="LabelNombreUsuario" runat="server"></asp:Label>
                <asp:Label ID="LabelErrorNombreUsuario" runat="server" ForeColor="Red"></asp:Label>
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
        <asp:Button ID="ButtonModificar" runat="server" Text="Modificar" onclick="ButtonModificar_Click"/>        
        </td>
        <td>
                &nbsp;</td>
        </tr>
</table>   

</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .style2
        {
            text-align: right;
        }
        .style3
        {
            text-align: left;
        }
    </style>
</asp:Content>
