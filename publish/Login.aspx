<%@ Page Language="C#" MasterPageFile="~/SiteMasterPage.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Web.Login" Title="SERVITARJETA 2.0 - Iniciar sesión" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
         Iniciar sesión</h1>
    <br />
    <p>
        Por favor ingrese con las credenciales suministradas por el administrador.</p>
    <%-- panel allows default button to be set --%>
    <asp:Panel ID="Panel1" DefaultButton="btnLogin" runat="server">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td width="10">

                </td>
                <td>
                    <font color="red" face="Arial">
                        <asp:Literal runat="server" ID="LiteralError"></asp:Literal></font>
                    <br />
                    <table bgcolor="#FFFACD" width="340" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="22" bgcolor="#000000" style="color: #ffffff; padding-left:10px;" align="left" colspan="2">
                                Iniciar sesión en el sistema
                            </td>
                        </tr>
                        <tr>
                            <td align="right" height="32">
                                Usuario:
                            </td>
                            <td>
                                <%--<asp:TextBox ID="txtUsuario" runat="server" TextMode="SingleLine" TabIndex="1"
                                    Width="200"></asp:TextBox>--%>
                                <asp:DropDownList ID="ddlUsuario" runat="server"  TabIndex="1"
                                    Width="200">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Contraseña:
                            </td>
                            <td>
                                <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" TabIndex="2"
                                    Width="200"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                &nbsp;
                            </td>
                            <td height="40" valign="middle">
                                <asp:Button ID="btnLogin" runat="server" Text="Iniciar sesión" onclick="btnLogin_Click" 
                                    ></asp:Button>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />
</asp:Content>
