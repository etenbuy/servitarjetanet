<%@ Page Language="C#" MasterPageFile="~/SiteMasterPage.Master" AutoEventWireup="true"
    CodeBehind="Rembolso.aspx.cs" Inherits="Web.Rembolso" Title="SERVITARJETA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div align="center">
    <h1>
          <label style="color:#134e9d; font-size:larger;">ENVIO DE FACTURAS Y RECIBOS</label></h1>
    <br />
    <p>
      <label style="color:#134e9d; font-size:larger;"></label>  </p>
    <%-- panel allows default button to be set --%>
 
       <asp:Panel ID="Panel2" DefaultButton="btnEnviar" runat="server">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td width="10">

                </td>
                <asp:Label ID="Label1" ForeColor="#134e9d" runat="server" Text="ENVIO DE FACTURAS Y RECIBOS"></asp:Label>
            </tr>
        <div>
        <asp:Label ID="lblMensaje" ForeColor="#F80404" runat="server" Text=""></asp:Label>
            <table class="Formulario" cellpadding="0" cellspacing="0">
               
                <tr>
                    <th>
                        Correo Electrónico:
                    </th>
                   
                    <td>
                    
                         <asp:TextBox runat="server" ID="txtCorreo"  AutoPostBack="false" Width="500" 
                             THeight="400px" />
                    </td>
                    <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="Requerido!" runat="server"
                        ValidationGroup="Submit" ErrorMessage="Requerido!" ControlToValidate="txtCorreo"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                <tr>
                    <th>
                        Monto:
                    </th>
                   
                    <td>
                    
                         <asp:TextBox runat="server" ID="txtMonto"  AutoPostBack="false" Width="500" 
                             THeight="400px" ontextchanged="txtMonto_TextChanged" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <th>
                        Monto a Reembolsar:
                    </th>
                    <td>
                        <label id="lblmontopagar"></label>
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
                    <asp:FileUpload ID="FileUploadFactura" runat="server"  AutoPostBack="false" />
                    </td>
                    <td>
                    </td>
                </tr>
                
                <tr>
                    <th>
                        Adjuntar Recibo:
                    </th>
                   
                    <td>
                    <asp:FileUpload ID="FileUploadRecibo" runat="server"  AutoPostBack="false" />
                    </td>
                    <td>
                    </td>
                </tr>
                
               
                <tr>
                    <td colspan="3">
                        <asp:Button CssClass="buttons" ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click"
                            ValidationGroup="Submit" 
                            OnClientClick="if (!Page_ClientValidate('Submit')) return false; if (!confirm('¿Esta seguro de crear esta solicitud?')) return false;" 
                            BackColor="#134E9D" BorderStyle="None" Font-Bold="True" ForeColor="White" />
                       
                    </td>
                </tr>

            </table>
        </div>
            </tr>
            
        </table>
    </asp:Panel>
    </div>
</asp:Content>
