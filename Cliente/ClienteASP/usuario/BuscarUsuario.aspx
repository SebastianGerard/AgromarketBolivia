<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SiteLoggedAdmin.Master" AutoEventWireup="true" 
    CodeBehind="BuscarUsuario.aspx.cs" Inherits="ClienteASP.usuario.BuscarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
     <asp:Content ID="Content2"  contentplaceholderid="MainContent" runat="server">
     <table style="width:100%;">
     <tr>
     <td class="style2">
     <asp:Label ID="Label1" runat="server" Text="Buscar :"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBoxBuscar" runat="server"></asp:TextBox>
                <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" onclick="ButtonBuscar_Click"/>
                <asp:Label ID="LabelError" runat="server" ForeColor="Red"></asp:Label>
            </td>     
     <td>
                &nbsp;</td>
     </tr>      
     <tr>
     <td class="style2">
         <asp:GridView ID="GridViewUsuario" runat="server" 
             onselectedindexchanged="GridViewUsuario_SelectedIndexChanged">
         </asp:GridView>
         </td>
         <td class="style3">
                &nbsp;</td>
         </tr>
     </table>

     </asp:Content>
