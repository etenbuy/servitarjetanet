<%@ Page Language="C#" MasterPageFile="~/SiteMasterPage.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Web.Login" Title="SERVITARJETA - Iniciar sesión" %>

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
                    <table bgcolor="#74C4E9" width="340" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="22" bgcolor="#0040FF" style="color: #ffffff; padding-left:10px;" align="left" colspan="2">
                                Iniciar sesión en el sistema
                            </td>
                        </tr>
                        <tr>
                            <td align="right" height="32">
                                Usuario:
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
    
       <asp:Panel ID="Panel2" DefaultButton="btnLogin" runat="server">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td width="10">

                </td>
                <asp:Label ID="Label1" ForeColor="#FE7000" runat="server" Text="ENVIO DE FACTURAS Y RECIBOS"></asp:Label>
            </tr>
        <div>
        <asp:Label ID="lblMensaje" ForeColor="#FE7000" runat="server" Text=""></asp:Label>
            <table class="Formulario" cellpadding="0" cellspacing="0">
               
               
                <tr>
                    <th>
                        Monto:
                    </th>
                   
                    <td>
                    
                         <asp:TextBox runat="server" ID="txtMonto"  AutoPostBack="true" Width="500" 
                             THeight="400px" />
                    </td>
                    <td>
                    </td>
                </tr>
                
                
                 <tr>
                    <th>
                        Nota:
                    </th>
                   
                    <td>
                    
                         <asp:TextBox runat="server" ID="txtNota"  AutoPostBack="true" Width="500px" 
                             TextMode="MultiLine" Height="121px" />
                    </td>
                    <td>
                    </td>
                </tr>
                
                <tr>
                    <th>
                        Adjuntar Factura:
                    </th>
                   
                    <td>
                    <asp:FileUpload ID="FileUploadFactura" runat="server"  AutoPostBack="true" />
                    </td>
                    <td>
                    </td>
                </tr>
                
                <tr>
                    <th>
                        Adjuntar Recibo:
                    </th>
                   
                    <td>
                    <asp:FileUpload ID="FileUploadRecibo" runat="server"  AutoPostBack="true" />
                    </td>
                    <td>
                    </td>
                </tr>
                
               
                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click"
                            ValidationGroup="Submit" OnClientClick="if (!Page_ClientValidate('Submit')) return false; if (!confirm('¿Esta seguro de crear esta solicitud?')) return false;" />
                       
                    </td>
                </tr>

            </table>
        </div>
            </tr>
            
        </table>
    </asp:Panel>
</asp:Content>
