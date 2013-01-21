<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SiteLoggedClient.Master" AutoEventWireup="true" 
    CodeBehind="VerPerfil.aspx.cs" Inherits="ClienteASP.usuario.VerPerfil" %>

    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <table style="width:100%;">
    <tr>
    <td>
    <asp:Label ID="Label1" runat="server" Text="Nombre :"></asp:Label>
    <asp:Label ID="LabelNombre" runat="server"></asp:Label>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Label2" runat="server" Text="Apellido :"></asp:Label>
    <asp:Label ID="LabelApellido" runat="server"></asp:Label>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Label3" runat="server" Text="Direccion :"></asp:Label>
    <asp:Label ID="LabelDireccion" runat="server"></asp:Label>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Label4" runat="server" Text="Nombre Usuario :"></asp:Label>
    <asp:Label ID="LabelNombreUsuario" runat="server"></asp:Label>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Label5" runat="server" Text="Email :"></asp:Label>
    <asp:Label ID="LabelEmail" runat="server"></asp:Label>
    </td>
    </tr>
    <tr>
    <td>
        &nbsp;</td>
    </tr>
   </table>
    </asp:Content>