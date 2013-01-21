<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SiteLoggedAdmin.Master" AutoEventWireup="true" CodeBehind="VerProductosPendientes.aspx.cs" Inherits="ClienteASP.oferta.VerProductosPendientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            width: 12px;
        }
        .style3
        {
            width: 18px;
        }
        .style4
        {
            width: 30px;
        }
        .style5
        {
            width: 225px;
        }
        .style6
        {
            width: 19px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="LabelError" runat="server" ForeColor="Red"></asp:Label>
            <div>
                <asp:Label ID="Label1" runat="server" Text="Una lista de los productos que aún no fueron evaluados se detalla a continuación: "></asp:Label>
            </div>
    <br />
            <table style="width:100%;">
                <tr>
                    <td class="style5">
                        &nbsp;</td>
                    <td class="style6">
                        <asp:DataList ID="DataList1" runat="server" 
                            onitemcommand="DataList1_ItemCommand">
                            <ItemTemplate>
                                <asp:Panel ID="Panel1" runat="server" GroupingText="Producto" Width="473px">
                                    <table style="width:100%;">
                                        <tr>
                                            <td class="style4">
                                                <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="LabelNombre" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style4">
                                                <asp:Label ID="Label3" runat="server" Text="Propietario:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="LabelAutor" runat="server" 
                                                    Text='<%# Eval("Usuario.nombreUsuario") %>'></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style4">
                                                <asp:Label ID="Label4" runat="server" Text="Unidades:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="LabelUnidades" runat="server" Text='<%# Eval("cantidad") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="LabelTipoUnidades" runat="server" Text='<%# Eval("unidad") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style4">
                                                &nbsp;</td>
                                            <td>
                                               <asp:Label ID="LabelNro" runat="server" Text='<%# Eval("idProducto") %>' Visible="false"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Ver">Evaluar...</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
