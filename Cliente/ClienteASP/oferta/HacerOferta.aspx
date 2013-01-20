<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SiteLoggedClient.Master" AutoEventWireup="true" CodeBehind="HacerOferta.aspx.cs" Inherits="ClienteASP.Oferta.HacerOferta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            width: 286px;
        }
        .style3
        {
            width: 340px;
        }
        .style4
        {
            text-align: right;
        }
        .style5
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Panel ID="Panel1" runat="server" GroupingText="Oferta">
                    <table style="width:100%;">
                        <tr>
                            <td class="style4">
                                <asp:Label ID="Label1" runat="server" Text="Cantidad deseada: "></asp:Label>
                            </td>
                            <td class="style5">
                                <asp:TextBox ID="TextBoxCantidad" MaxLength="10" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                <asp:Label ID="Label2" runat="server" Text="Precio ofertado:"></asp:Label>
                            </td>
                            <td class="style5">
                                <asp:TextBox ID="TextBoxPrecio" MaxLength="10" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                <asp:Label ID="Label3" runat="server" Text="Tipo moneda:"></asp:Label>
                            </td>
                            <td class="style5">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>Bs.</asp:ListItem>
                                    <asp:ListItem>$us Americanos</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                <asp:Label ID="Label4" runat="server" Text="Propietario:"></asp:Label>
                            </td>
                            <td class="style5">
                                <asp:Label ID="LabelPropietario" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                <asp:Label ID="Label5" runat="server" Text="Cantidad disponible:"></asp:Label>
                            </td>
                            <td class="style5">
                                <asp:Label ID="LabelCantidad" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                <asp:Label ID="Label6" runat="server" Text="Producto: "></asp:Label>
                            </td>
                            <td class="style5">
                                <asp:Label ID="LabelProducto" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:Label ID="LabelError" runat="server" ForeColor="Red" Text=""></asp:Label>
                    <br />
                    <asp:Button ID="ButtonOfertar" runat="server" Text="Ofertar" 
                        onclick="ButtonOfertar_Click" />
                </asp:Panel>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
