<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="IngresarLogin.aspx.cs" Inherits="ClienteASP.IngresarLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
            text-align: right;
            width: 307px;
        }
        .style8
        {
            width: 405px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        
        <tr>
            <td class="style8">
                </td>
            <td>
                <asp:Login ID="Login1" runat="server" onauthenticate="Login1_Authenticate" 
                LoginButtonText="Entrar" PasswordLabelText="Contraseña:" 
                RememberMeText="Remember me next time." TitleText=""
                UserNameLabelText="Nombre de usuario:" Width="264px" BorderColor="Black" 
                    style="text-align: center">
                </asp:Login>
            </td>
            <td>
                </td>
        </tr>
        <tr>
            <td class="style8" >
                </td>
            <td>
                </td>
            <td>
                </td>
        </tr>
        <tr>
            <td class="style8">
                </td>
            <td>
                
                <asp:LinkButton ID="LinkButton2" runat="server" Text = "Registrar" 
                    onclick="LinkButton1_Click" />
            </td>
            <td>
               </td>
        </tr>
    </table>
</asp:Content>
