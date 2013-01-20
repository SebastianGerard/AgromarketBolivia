<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SiteLoggedClient.Master" AutoEventWireup="true" CodeBehind="Registrar producto.aspx.cs" Inherits="ClienteASP.producto.Registrar_producto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            width: 289px;
            text-align: right;
        }
        #TextArea1
        {
            height: 58px;
            width: 306px;
        }
        .style3
        {
            width: 245px;
        }
        .style4
        {
            width: 488px;
        }
        .style5
        {
            width: 201px;
        }
        .style6
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <table style="width:100%;">
        <tr>
            <td class="style3">
                <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
                </asp:ScriptManagerProxy>
            </td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" GroupingText="Producto">
                            <table style="width:100%;">
                                <tr>
                                    <td class="style2">
                                        Nombre:</td>
                                    <td class="style6">
                                        <asp:TextBox ID="TextBoxNombre" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2" valign="top">
                                        Detalle:</td>
                                    <td class="style6">
                                        <asp:TextBox ID="TextBoxDetalle" runat="server" Height="51px" MaxLength="200" 
                                            TextMode="MultiLine" Width="206px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        Cantidad:
                                    </td>
                                    <td class="style6">
                                        <asp:TextBox ID="TextBoxCantidad" runat="server" MaxLength="9"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2" valign="top">
                                        Fecha de vencimiento de la subasta:</td>
                                    <td class="style6">
                                        <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" 
                                            BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
                                            Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="134px" 
                                            ShowGridLines="True" Width="132px">
                                            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                            <OtherMonthDayStyle ForeColor="#CC9966" />
                                            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                            <SelectorStyle BackColor="#FFCC66" />
                                            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
                                                ForeColor="#FFFFCC" />
                                            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                                        </asp:Calendar>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        Unidad de medida:</td>
                                    <td class="style6">
                                        <asp:TextBox ID="TextBoxUnidad" runat="server" MaxLength="10"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <asp:Label ID="LabelError" runat="server" ForeColor="Red" Text=""></asp:Label>
                    <br />
                            <table style="width:100%;">
                                <tr>
                                    <td class="style5">
                                        &nbsp;</td>
                                    <td>
                                        <asp:Button ID="ButtonAceptar" runat="server" onclick="ButtonAceptar_Click" 
                                            Text="Aceptar" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style5">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style5">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    
</asp:Content>
