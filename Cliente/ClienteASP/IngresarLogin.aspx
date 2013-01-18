<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IngresarLogin.aspx.cs" Inherits="ClienteASP.IngresarLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        text-align: right;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style1">
                <asp:Label ID="Label1" runat="server" Text="Nombre de Usuario:"></asp:Label>
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
                <asp:Label ID="Label2" runat="server" Text="Contrasena:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxContrasena" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:Button ID="ButtonIngresar" runat="server" Text="Ingresar" 
                    onclick="ButtonIngresar_Click" />
                <asp:LinkButton ID="LinkButton1" runat="server" Text = "Registrar" 
                    onclick="LinkButton1_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
