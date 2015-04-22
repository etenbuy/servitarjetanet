<%@ Page Language="C#" MasterPageFile="~/SiteMasterPage.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Web.Login" Title="SERVITARJETA - Iniciar sesión" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 125px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
    <br />
   
    <asp:Panel ID="Panel1" DefaultButton="btnLogin" runat="server">
        <table width="" cellpadding="0" cellspacing="0" border="0">
            <tr>

                <td>
                    <font color="red" face="Arial">
                        <asp:Literal runat="server" ID="LiteralError"></asp:Literal></font>
                    <br />
                    <table id="login" cellspacing="4" bgcolor="#fff" width="440" border="0" cellpadding="0" cellspacing="0">
                                  <tr>
                                            <td align="" bgcolor="#ececec" colspan="2" height="22" 
                                                style="color: #134e9d; text-align:left; color:#2E2E2E; font-weight:bold; font-size:smaller; padding-left:10px;">
                                                SI AUN NO HAZ RECIBIDO TU CLAVE TEMPORAL Y USUARIO EN TU EMAIL, COMUNICATE CON 
                                                TU EJECUTIVO DE CUENTA O LINEA DE ATENCION AL CLIENTE</td>
                                        </tr>
                    
                </td>
            </tr>
            
            <tr>
                <td align="" bgcolor="#134e9d" colspan="2" height="22" 
                    style="color: #134e9d; text-align:center; color:#fff; font-weight:bold; font-size:medium; padding-left:10px;">
                    Usuarios Afiliados</td>
            </tr>
            <tr>
                <td align="" bgcolor="#ececec" colspan="2" height="22" 
                    style="color: #134e9d; text-align:center; color:#134e9d; font-weight:bold; font-size:smaller; padding-left:10px;">
                    Si Ud.ya esta afiliado a este servicio,<br />
                    Ingrese su Usuario y Clave y presione Iniciar sesion</td>
            </tr>
            <tr bgcolor="#ececec">
                <td align="right" class="style1" height="32">
                    <label style="color:#134e9d; font-size:larger;">
                    Usuario:</label>
                </td>
                <td>
                    <asp:TextBox ID="txtUsuario" runat="server" TabIndex="1" TextMode="SingleLine" 
                        Width="200"></asp:TextBox>
                    <!--   <asp:DropDownList ID="ddlUsuario" runat="server"  TabIndex="1"
                                    Width="200">
                                </asp:DropDownList>-->
                </td>
            </tr>
            <tr bgcolor="#ececec">
                <td align="right" class="style1">
                    <label style="color:#134e9d; font-size:larger;">
                    Contraseña:</label>
                </td>
                <td>
                    <asp:TextBox ID="txtContrasena" runat="server" TabIndex="2" TextMode="Password" 
                        Width="200"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#ececec">
                <td class="style1" height="40">
                    &nbsp;
                </td>
                <td align="center" height="40" valign="middle">
                    <asp:Button ID="btnLogin" runat="server" BackColor="#134E9D" BorderStyle="None"
                        Font-Bold="True" ForeColor="White" onclick="btnLogin_Click" 
                        Text="Iniciar Sesion" />
                </td>
            </tr>
            <tr bgcolor="#ececec">
                <td align="right" class="style1">
                    <label style="color:#134e9d; font-size:small;">
                    Si olvido su clave o usuario</label>
                </td>
                <td align="center" height="40" valign="middle">
                    <asp:Button ID="btnpassreturn" runat="server" BackColor="#134E9D" 
                        BorderStyle="None" Font-Bold="True" ForeColor="White" 
                        onclick="btnpassreturn_Click" Text="Haga click aqui" />
                </td>
            </tr>
            <tr>
                <td colspan="2" height="22">
                    <img alt="security" height="32" src="Images/I.png" />
                </td>
            </tr>
            <tr>
                <td align="" bgcolor="#ececec" colspan="2" height="22" 
                    style="color: #134e9d; text-align:left; color:#134e9d; font-weight:bold; font-size:x-small; padding-left:10px;">
                    -Compruebe estar conectado(a) a la direccion http://servitarjeta.net, el cual es el unico<br />
                     sitio legitimo de acceso a la plataforma de gestion de solicitud de reembolsos</td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />
    
    </div>
</asp:Content>
