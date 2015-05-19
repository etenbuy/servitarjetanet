<%@ Page Language="C#" MasterPageFile="~/Configuracion/Configuracion.master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="Web.Configuracion.Pagos.Editar" Title="SERVITARJETA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent" runat="server">

 <div align="center">
    
    <h2>
        Actualizar Pagos</h2>
    <div>
     
     
    <asp:Label ID="lblMensaje" ForeColor="#FE7000" runat="server" Text=""></asp:Label>
    <div runat="server" style="float:left;">
    <asp:GridView ID="gvClientes" CellPadding="0" CellSpacing="0" CssClass=""
        AllowSorting="true" HeaderStyle-Wrap="false" runat="server" Font-Size="10px"
      AutoGenerateColumns="false"  ShowFooter="true">
        <RowStyle HorizontalAlign="Center" />
        <Columns>
            <asp:BoundField DataField="ClienteID" HeaderText="ClienteID" SortExpression="ClienteID"/>
            <asp:BoundField DataField="LoginCreado" HeaderText="Cliente" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="LoginCreado" />
                 <asp:BoundField DataField="Monto_Pagado" HeaderText="Monto a Pagar" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="Monto_Pagado" />

             <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="hfClienteID" Value='<%#Eval("ClienteID")%>' runat="server" />
                    <asp:HiddenField ID="hfLoginCreado" Value='<%#Eval("LoginCreado")%>' runat="server" />
                   <asp:LinkButton ID="lbtnCliente" Text="Seleccionar" runat="server" OnClick="btnSeleccionarCliente_Click"></asp:LinkButton>
                    
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView>
    </div>
    <div runat="server" style="float:left;">
     Cantidad Clientes pendientes por pagar:<asp:Label ID="lblClientes" Text="0" runat="server"></asp:Label>   
        <table class="Formulario" cellpadding="0" cellspacing="0" style="margin-left:50px; margin-right:50px;">
           
            <tr>
                <th>
                    Cliente:
                </th>
                <td colspan="2">
                    <asp:TextBox ID="txtLoginCreado" Enabled="true" runat="server" Width="297px"></asp:TextBox>

                </td>
                <td>
                
                    <asp:Button CssClass="buttons" Visible="false" ID="btnBuscar" runat="server" Text="Buscar" 
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
                        Width="297px"></asp:DropDownList>
                </td>
             
            </tr>
            <tr>
                <th>
                    Fecha de Pago:
                </th>
                <td colspan="2">
                 <asp:TextBox ID="txtFechaPago" runat="server" Width="297px"></asp:TextBox>                   
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
                    <asp:TextBox ID="txtTDC" runat="server" MaxLength="30" Width="297px"></asp:TextBox>
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
                    <asp:TextBox ID="txtdeposito" runat="server" MaxLength="10" Width="297px"></asp:TextBox>
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
                    <asp:TextBox ID="txtMontoPagado" runat="server" MaxLength="10" Width="297px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="Requerido!" runat="server"
                        ValidationGroup="Submit" ErrorMessage="Requerido!" ControlToValidate="txtMontoPagado"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td colspan="4">
                    <asp:Button CssClass="buttons" ID="btnCrear" runat="server" Text="ENVIAR" OnClick="btnGuardar_Click"
                        ValidationGroup="Submit" 
                        
                        OnClientClick="if (!Page_ClientValidate('Submit')) return false; if (!confirm('¿Esta seguro de crear este Pago?')) return false;" />
                    
                </td>
            </tr>
           
            
        </table>
        </div>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Seleccione mes y Año o por Rango de solicitudes"></asp:Label>
        <div runat="server">
        
           <asp:Label ID="Label1" runat="server" Text="Mes: "></asp:Label>
        <asp:DropDownList ID="ddlMes" runat="server" AutoPostBack="true" Height="16px" Width="109px" 
                onselectedindexchanged="ddlMes_SelectedIndexChanged">
        <asp:ListItem Text="01" Value="01" />
        <asp:ListItem Text="02" Value="02" />
        <asp:ListItem Text="03" Value="03" />
        <asp:ListItem Text="04" Value="04" />
        <asp:ListItem Text="05" Value="05" />
        <asp:ListItem Text="06" Value="06" />
        <asp:ListItem Text="07" Value="07" />
        <asp:ListItem Text="08" Value="08" />
        <asp:ListItem Text="09" Value="09" />
        <asp:ListItem Text="10" Value="10" />
        <asp:ListItem Text="11" Value="11" />
        <asp:ListItem Text="12" Value="12" />
        </asp:DropDownList>
&nbsp;<asp:Label ID="Label2" runat="server" Text="Año: "></asp:Label>
&nbsp;<asp:DropDownList ID="ddlAno" AutoPostBack="true" runat="server" Height="18px" Width="116px" 
                onselectedindexchanged="ddlAno_SelectedIndexChanged1">
        <asp:ListItem Text="2014" Value="2014" />
        <asp:ListItem Text="2015" Value="2015" />
        <asp:ListItem Text="2016" Value="2016" />
        <asp:ListItem Text="2017" Value="2017" />
        <asp:ListItem Text="2018" Value="2018" />
        <asp:ListItem Text="2019" Value="2019" />
        <asp:ListItem Text="2020" Value="2020" />
        <asp:ListItem Text="2021" Value="2021" />
        <asp:ListItem Text="2022" Value="2022" />
        <asp:ListItem Text="2023" Value="2023" />
        <asp:ListItem Text="2024" Value="2024" />
        <asp:ListItem Text="2025" Value="2025" />
        </asp:DropDownList>
        
        </div>
        <div runat="server" style="float:right;">
         Cantidad Solicitudes Por pagar:<asp:Label ID="lblTotalSolicitudes" Text="0" runat="server"></asp:Label>   
        <asp:GridView ID="gvSolicitudes" CellPadding="0" CssClass=""
        AllowSorting="True" HeaderStyle-Wrap="false" runat="server" Font-Size="10px"
       OnSorting="gvSolicitudes_Sorting" AutoGenerateColumns="False"  ShowFooter="True"
         ondatabound="gvSolicitudes_DataBound">
        <RowStyle HorizontalAlign="Center" />
        <Columns>
            <asp:BoundField DataField="SolicitudID" HeaderText="SolicitudID" SortExpression="SolicitudID"/>
            <asp:BoundField DataField="LoginCreado" HeaderText="Cliente" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="LoginCreado" >
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
                <asp:BoundField DataField="Estado" HeaderText="Estado" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="Estado" >
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="FechaCreado" HeaderText="Fecha" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="FechaCreado" >
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
                <asp:BoundField DataField="Monto" HeaderText="Monto Factura" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="Monto" >
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Monto_Pagado" HeaderText="Monto a Pagar" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="Monto_Pagado" >
        
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
        
        <asp:TemplateField HeaderText="Seleccionar">
            <ItemTemplate>
                <asp:CheckBox id="SelectCheckBox" HeaderText="Seleccionar" runat="server" AutoPostBack="true" OnCheckedChanged="gvSolicitudes_OnCheckedChanged"/>
            </ItemTemplate>
        </asp:TemplateField>
         
        </Columns>

<HeaderStyle Wrap="False"></HeaderStyle>
    </asp:GridView>
    </div>
    </div>

  

</asp:Content>
 