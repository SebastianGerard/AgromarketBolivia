<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SiteLoggedClient.Master" AutoEventWireup="true" CodeBehind="OfertaExitosa.aspx.cs" Inherits="ClienteASP.oferta.OfertaExitosa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:Label ID="Label1" runat="server" style="font-size: large" Text="Oferta realizada exitosamente..."></asp:Label>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Click para volver...</asp:LinkButton>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
</asp:Content>
