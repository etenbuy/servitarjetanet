<%@ Page Language="C#" MasterPageFile="~/SiteMasterPage.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Web.Login" Title="SERVITARJETA - Iniciar sesión" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
    <h1>
          <label style="color:#134e9d; font-size:larger;"> INGRESE AL SISTEMA</label></h1>
    <br />
    <p>
      <label style="color:#134e9d; font-size:larger;">  Por favor ingrese con las credenciales suministradas por el administrador.</label>  </p>
    <%-- panel allows default button to be set --%>
    
    <asp:Panel ID="Panel1" DefaultButton="btnLogin" runat="server">
        <table width="" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td width="10">

                </td>
                <td>
                    <font color="red" face="Arial">
                        <asp:Literal runat="server" ID="LiteralError"></asp:Literal></font>
                    <br />
                    <table bgcolor="#fff" width="340" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="22" bgcolor="White"style="color: #134e9d; padding-left:10px;" align="" colspan="2">
                               &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" height="32">
                              <label style="color:#134e9d; font-size:larger;">Usuario:</label>  
                            </td>
                            <td>
                                <asp:TextBox ID="txtUsuario" runat="server" TextMode="SingleLine" TabIndex="1"
                                    Width="200"></asp:TextBox>
                             <!--   <asp:DropDownList ID="ddlUsuario" runat="server"  TabIndex="1"
                                    Width="200">
                                </asp:DropDownList>-->
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                               <label style="color:#134e9d; font-size:larger;">Contraseña:</label>    
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
                                <asp:Button ID="btnLogin" runat="server" Text="Iniciar sesión" 
                                    onclick="btnLogin_Click" BackColor="#134E9D" BorderStyle="None" 
                                    Font-Bold="True" ForeColor="White" 
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
    
    </div>
</asp:Content>
