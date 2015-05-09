<%@ Page Language="C#" MasterPageFile="~/Configuracion/Configuracion.master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="Web.Configuracion.Pagos.Editar" Title="SERVITARJETA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent" runat="server">

 <div align="center">
    
    <h2>
        Actualizar Pagos</h2>
    <div>
    <asp:Label ID="lblMensaje" ForeColor="#FE7000" runat="server" Text=""></asp:Label>
        <table class="Formulario" cellpadding="0" cellspacing="0">
           
            <tr>
                <th>
                    Cliente:
                </th>
                <td colspan="2">
                    <asp:TextBox ID="txtLoginCreado" Enabled="true" runat="server"></asp:TextBox>

                </td>
                <td>
                
                    <asp:Button CssClass="buttons" ID="btnBuscar" runat="server" Text="Buscar" 
                        onclick="btnBuscar_Click" ValidationGroup="Find" OnClientClick="if (!Page_ClientValidate('Submit')) return false; if (!confirm('¿Esta seguro de crear este Pago?')) return false;" />
                
                </td>
                
            </tr>
            <tr>
                <th>
                    Tarjetas Afiliadas:
                </th>
                <td colspan="2">
                    <asp:DropDownList ID="ddlTarjetas" AutoPostBack="true" runat="server" 
                         Height="16px" 
                        Width="300px" onselectedindexchanged="ddlTarjetas_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="Requerido!" runat="server"
                        ValidationGroup="Find" ErrorMessage="Requerido!" ControlToValidate="txtLoginCreado"></asp:RequiredFieldValidator>
                </td>
            </tr>
          <tr>  
                <th>
                  <!--  Solicitud ID:-->
                </th>
                <td colspan="2">
                    <asp:TextBox ID="txtSolicitudID" Enabled="false" Visible="false" runat="server"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <th>
                  <!--   Nº
                    Factura:-->
                </th>
                <td colspan="2">
                    <asp:TextBox ID="txtFactura" Enabled="false" Visible="false" runat="server"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <th>
                   <!--  Monto Factura:-->
                </th>
                <td colspan="2">
                    <asp:TextBox ID="txtMontoFactura" Enabled="false" Visible="false" runat="server"></asp:TextBox>
                </td>
                
            </tr>
           
            <tr>
            <th>
                    Estado:
                </th>
                <td colspan="2">
                    <asp:DropDownList ID="ddlTipo" AutoPostBack="true" runat="server" 
                         Height="16px" 
                        Width="126px"></asp:DropDownList>
                </td>
             
            </tr>
            <tr>
                <th>
                    Fecha de Pago:
                </th>
                <td colspan="2">
                 <asp:TextBox ID="txtFechaPago" runat="server" Width="200px"></asp:TextBox>                   
                   <asp:CalendarExtender ID="Calendar" Format="dd/MM/yyyy" runat="server" TargetControlID="txtFechaPago" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="Requerido!" runat="server"
                        ValidationGroup="Submit" ErrorMessage="Requerido!" ControlToValidate="txtFechapago"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    Nº TDC o Cuenta Bancaria:
                </th>
                <td colspan="2">
                    <asp:TextBox ID="txtTDC" runat="server" MaxLength="30"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Requerido!" runat="server"
                        ValidationGroup="Submit" ErrorMessage="Requerido!" ControlToValidate="txtTDC"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    Nº Deposito:
                </th>
                <td colspan="2">
                    <asp:TextBox ID="txtdeposito" runat="server" MaxLength="10"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="Requerido!" runat="server"
                        ValidationGroup="Submit" ErrorMessage="Requerido!" ControlToValidate="txtdeposito"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    Monto a Reembolsar:
                </th>
                <td colspan="2">
                    <asp:TextBox ID="txtMontoPagado" runat="server" MaxLength="10"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="Requerido!" runat="server"
                        ValidationGroup="Submit" ErrorMessage="Requerido!" ControlToValidate="txtMontoPagado"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td colspan="4">
                    <asp:Button CssClass="buttons" ID="btnCrear" runat="server" Text="Enviar" OnClick="btnGuardar_Click"
                        ValidationGroup="Submit" OnClientClick="if (!Page_ClientValidate('Submit')) return false; if (!confirm('¿Esta seguro de crear este Pago?')) return false;" />
                    
                </td>
            </tr>
           
            
        </table>
        Cantidad :<asp:Label ID="lblTotalSolicitudes" Text="0" runat="server"></asp:Label>    
        <asp:GridView ID="gvSolicitudes" CellPadding="0" CellSpacing="0" CssClass="Formulario"
        AllowSorting="true" HeaderStyle-Wrap="false" runat="server" Font-Size="10px"
       OnSorting="gvSolicitudes_Sorting" AutoGenerateColumns="false"  ShowFooter="true"
         ondatabound="gvSolicitudes_DataBound">
        <RowStyle HorizontalAlign="Center" />
        <Columns>
            <asp:BoundField DataField="SolicitudID" HeaderText="SolicitudID" SortExpression="SolicitudID"/>
            <asp:BoundField DataField="LoginCreado" HeaderText="Cliente" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="LoginCreado" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="Estado" />
            <asp:BoundField DataField="FechaCreado" HeaderText="Fecha" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="FechaCreado" />
                <asp:BoundField DataField="Monto" HeaderText="Monto Factura" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="Monto" />
            <asp:BoundField DataField="Monto_Pagado" HeaderText="Monto a Reembolsar" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="Monto_Pagado" />
                
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="hfSolicitudID" Value='<%#Eval("solicitudid")%>' runat="server" />
                   <asp:LinkButton ID="lbtnEditar" Text="Editar" runat="server" OnClick="btnEditar_Click"></asp:LinkButton>
                    
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView>
    </div>

  

</asp:Content>
 