<%@ Page Language="C#" MasterPageFile="~/Operaciones/Operaciones.master" AutoEventWireup="true"
    CodeBehind="CrearSolicitud.aspx.cs" Inherits="Web.Operaciones.Clientes.CrearSolicitud" Title="SERVITARJETA" %>

<%@ Register Src="~/ExtraControls/CartaPorteUI.ascx" TagName="CartaPorteUI" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent" runat="server">

<script type="text/javascript">
function toggleAlert() {
toggleDisabled(document.getElementById("content"));
}
function toggleDisabled(el) {
try {
el.disabled = el.disabled ? false : true;
}
catch(E){
}
if (el.childNodes && el.childNodes.length > 0) {
for (var x = 0; x < el.childNodes.length; x++) {
toggleDisabled(el.childNodes[x]);
}
}
}
</script>

    <h2>
        ENVIO DE FACTURAS Y RECIBOS Primer Ticket Mensual</h2>
  <asp:Panel ID="primer_ticket" runat="server">
    <asp:Label ID="lblMensaje" ForeColor="#FE7000" runat="server" Text=""></asp:Label>
        <table class="Formulario" cellpadding="0" cellspacing="0">
           
           
            <tr>
                <th>
                    Monto:
                </th>
               
                <td colspan="2">
                
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
               
                <td colspan="2">
                
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
               
                <td colspan="2">
                <asp:FileUpload ID="FileUploadFactura" runat="server"  AutoPostBack="true" />
                </td>
                <td>
                </td>
            </tr>
            
            <tr>
                <th>
                    Adjuntar Recibo:
                </th>
               
                <td colspan="2">
                <asp:FileUpload ID="FileUploadRecibo" runat="server"  AutoPostBack="true" />
                </td>
                <td>
                </td>
            </tr>
            
           
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnCrear" runat="server" Text="Guardar" OnClick="btnCrear_Click"
                        ValidationGroup="Submit" OnClientClick="if (!Page_ClientValidate('Submit')) return false; if (!confirm('¿Esta seguro de crear esta solicitud?')) return false;" />
                    <asp:Button ID="btnEliminar" runat="server" Visible="false" Text="Eliminar" OnClick="btnEliminar_Click"
                        OnClientClick="if (!Page_ClientValidate()) return false; if (!confirm('¿Esta seguro de eliminar esta solicitud?')) return false;"
                        ValidationGroup="Submit" />
                </td>
            </tr>

      <tr>
      
    </tr>
    
        </table>
  
    </asp:panel>
     <h2>
        ENVIO DE FACTURAS Y RECIBOS Segundo Ticket Mensual</h2>
    
     <asp:panel ID="segundo_ticket" runat="server">
    <asp:Label ID="Label1" ForeColor="#FE7000" runat="server" Text=""></asp:Label>
        <table class="Formulario" cellpadding="0" cellspacing="0">
           
           
            <tr>
                <th>
                    Monto:
                </th>
               
                <td colspan="2">
                
                     <asp:TextBox runat="server" ID="TextBox1"  AutoPostBack="true" Width="500" 
                         THeight="400px" />
                </td>
                <td>
                </td>
            </tr>
            
            
             <tr>
                <th>
                    Nota:
                </th>
               
                <td colspan="2">
                
                     <asp:TextBox runat="server" ID="TextBox2"  AutoPostBack="true" Width="500px" 
                         TextMode="MultiLine" Height="121px" />
                </td>
                <td>
                </td>
            </tr>
            
            <tr>
                <th>
                    Adjuntar Factura:
                </th>
               
                <td colspan="2">
                <asp:FileUpload ID="FileUploadFactura2" runat="server"  AutoPostBack="true" />
                </td>
                <td>
                </td>
            </tr>
            
            <tr>
                <th>
                    Adjuntar Recibo:
                </th>
               
                <td colspan="2">
                <asp:FileUpload ID="FileUploadRecibo2" runat="server"  AutoPostBack="true" />
                </td>
                <td>
                </td>
            </tr>
            
           
            <tr>
                <td colspan="4">
                    <asp:Button ID="Button1" runat="server" Text="Guardar" OnClick="btnCrear_Click"
                        ValidationGroup="Submit" OnClientClick="if (!Page_ClientValidate('Submit')) return false; if (!confirm('¿Esta seguro de crear esta solicitud?')) return false;" />
                    <asp:Button ID="Button2" runat="server" Visible="false" Text="Eliminar" OnClick="btnEliminar_Click"
                        OnClientClick="if (!Page_ClientValidate()) return false; if (!confirm('¿Esta seguro de eliminar esta solicitud?')) return false;"
                        ValidationGroup="Submit" />
                </td>
            </tr>

        </table>
    </asp:panel>
    
</asp:Content>
