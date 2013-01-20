<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SiteLoggedClient.Master" AutoEventWireup="true" CodeBehind="VerProductos.aspx.cs" Inherits="ClienteASP.producto.VerProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            width: 365px;
        }
        .style3
        {
            width: 286px;
        }
        .style4
        {
            text-align: right;
        }
        .style5
        {
            width: 181px;
        }
        .style6
        {
            width: 475px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width:100%;">
                <tr>
                    <td class="style2" style="text-align: right">
                        <asp:Label ID="Label1" runat="server" Text="Nombre: "></asp:Label>
                    </td>
                    <td class="style3">
                        <asp:TextBox ID="TextBox1" runat="server" Width="254px"></asp:TextBox>
                    </td>
                    <td style="text-align: left">
                        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
                    </td>
                </tr>
            </table>
            <asp:Label ID="LabelError" runat="server" ForeColor="Red"></asp:Label>
    <br />
            <table style="width:100%;">
                <tr>
                    <td class="style5">
                        &nbsp;</td>
                    <td class="style6">
                        <asp:DataList ID="DataList1" runat="server">
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
                                                &nbsp;</td>
                                            <td>
                                                <asp:LinkButton ID="LinkButton1" runat="server">Ver detalles...</asp:LinkButton>
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
