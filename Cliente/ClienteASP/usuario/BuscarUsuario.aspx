<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SiteLoggedAdmin.Master" AutoEventWireup="true" 
    CodeBehind="BuscarUsuario.aspx.cs" Inherits="ClienteASP.usuario.BuscarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     </asp:Content>
     <asp:Content ID="Content2"  contentplaceholderid="MainContent" runat="server">

         <asp:GridView ID="GridViewUsuario" runat="server" 
             onselectedindexchanged="GridViewUsuario_SelectedIndexChanged">
         </asp:GridView>

     </asp:Content>
