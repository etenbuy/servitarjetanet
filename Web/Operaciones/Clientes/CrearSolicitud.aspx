<%@ Page Language="C#" MasterPageFile="~/Operaciones/Operaciones.master" AutoEventWireup="true"
    CodeBehind="CrearSolicitud.aspx.cs" Inherits="Web.Operaciones.Clientes.CrearSolicitud" Title="SERVITARJETA" %>

<%@ Register Src="~/ExtraControls/CartaPorteUI.ascx" TagName="CartaPorteUI" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent" runat="server">

    <h2>
        Crear Solicitud de Servicios</h2>
    <div>
    <asp:Label ID="lblMensaje" ForeColor="#FE7000" runat="server" Text=""></asp:Label>
        <table class="Formulario" cellpadding="0" cellspacing="0">
           
           
            <tr>
                <th>
                    Servicio:
                </th>
                <td colspan="2">
                    <asp:DropDownList ID="ddlServicio"  DataTextField="" DataValueField="187"
                        Width="300" runat="server">
                        <asp:ListItem Value="1">Asistencia Médica</asp:ListItem>
                         <asp:ListItem Value="2">Asistencia Jurídica</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                </td>
            </tr>
            
             <tr>
                <th>
                    Nota:
                </th>
                Coloque Diagnostico y datos personales de contacto en el campo NOTA
                <td colspan="2">
                
                     <asp:TextBox runat="server" ID="txtNota"  AutoPostBack="true" Width="500" 
                         TextMode="MultiLine" Height="400px" />
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

        </table>
    </div>
</asp:Content>
