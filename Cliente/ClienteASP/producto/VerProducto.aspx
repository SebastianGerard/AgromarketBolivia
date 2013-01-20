<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SiteLoggedClient.Master" AutoEventWireup="true" CodeBehind="VerProducto.aspx.cs" Inherits="ClienteASP.producto.VerProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style3
        {
            width: 322px;
        }
        .style4
        {
            width: 295px;
        }
        #TextArea2
        {
            height: 69px;
            width: 187px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                <asp:Label ID="LabelError" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <asp:Panel ID="Panel1" runat="server" GroupingText="Producto">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelNombre" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label2" runat="server" Text="Detalle:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxDetalle" runat="server" Enabled="false" Columns="20" MaxLength="500" Rows="5" TextMode="MultiLine" Text="" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Cantidad:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelCantidad" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Fecha de oferta:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelFechaOferta" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Fecha de vencimiento de oferta:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelVencimiento" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Usuario propietario"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelUsuario" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Unidad de medida:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelMedida" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="Vigente:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelVigente" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                <asp:Button ID="ButtonOfertar" runat="server" Text="Ofertar" 
                    onclick="ButtonOfertar_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
