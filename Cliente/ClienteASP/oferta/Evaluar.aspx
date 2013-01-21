<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SiteLoggedAdmin.Master" AutoEventWireup="true" CodeBehind="Evaluar.aspx.cs" Inherits="ClienteASP.oferta.Evaluar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            width: 306px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="LabelError" ForeColor="Red" runat="server" Text=""></asp:Label>
    <br />
    <table style="width:100%;">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:DataList ID="DataList1" runat="server" style="margin-right: 0px">
                    <ItemTemplate>
                        <asp:Panel ID="Panel1" runat="server" GroupingText="Oferta" Width="462px">

                            <table style="width:100%;">
                                <tr>
                                    <td class="style3">
                                        <asp:Label ID="Label1" runat="server" Text="Producto: "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelProducto" runat="server" Text='<%# Eval("producto.nombre") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        <asp:Label ID="Label2" runat="server" Text="Cantidad disponible:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelCantidadProducto" runat="server" Text='<%# Eval("producto.cantidad") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        <asp:Label ID="Label3" runat="server" Text="Cantidad Ofertada:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelCantidadOferta" runat="server" Text='<%# Eval("cantidad") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        <asp:Label ID="Label4" runat="server" Text="Fecha Oferta:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelFechaOferta" runat="server" Text='<%# Eval("fecha") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        <asp:Label ID="Label5" runat="server" Text="Aceptada:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelAceptada" runat="server" Text='<%# Eval("tomada") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        <asp:Label ID="Label6" runat="server" Text="Precio a pagar:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelPrecioOferta" runat="server" Text='<%# Eval("precio") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        <asp:Label ID="Label7" runat="server" Text="Propietario:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelNombreUsuarioProp" runat="server" Text='<%# Eval("producto.Usuario.nombre") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        <asp:Label ID="Label8" runat="server" Text="Fecha Vencimiento:"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="LabelFechaVencimiento" runat="server" Text='<%# Eval("producto.fechaVencimientoOferta") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        &nbsp;</td>
                                    <td>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
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
    <br />
    <asp:Button ID="ButtonGuardar" runat="server" Text="Guardar" 
        onclick="ButtonGuardar_Click" />
</asp:Content>
