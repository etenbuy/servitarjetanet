<%@ Page Language="C#" MasterPageFile="~/Operaciones/Operaciones.master" AutoEventWireup="true"
    CodeBehind="EstadosCuenta.aspx.cs" Inherits="Web.Operaciones.Clientes.EstadosCuenta" Title="SERVITARJETA" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent" runat="server">
    <div align="center"> 
     <script type = "text/javascript">
     function PrintPanel() {
         var panel = document.getElementById("estadocuenta");
         var printWindow = window.open('', '', 'height=969,width=1120');
         printWindow.document.write('<html><head><title>Estado de Cuenta</title>');
         printWindow.document.write('</head><body >');
         printWindow.document.write(panel.innerHTML);
         printWindow.document.write('</body></html>');
         printWindow.document.close();
         setTimeout(function() {
             printWindow.print();
         }, 500);
         return false;
     }
 </script> 
    <div>
        <asp:Label ID="lblTarjeta" runat="server" Font-Size="Large" Text="Seleccione Mes y Año" ForeColor="#134e9d"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlTarjetas" runat="server" Height="23px" Width="229px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Mes: "></asp:Label>
        <asp:DropDownList ID="ddlMes" runat="server" Height="16px" Width="109px">
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
&nbsp;<asp:DropDownList ID="ddlAno" runat="server" Height="18px" Width="116px">
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
        <br />
        <br />
        <asp:Button ID="btnEnviar" CssClass="buttons" OnClick="btnEnviar_Click" 
            runat="server" Text="BUSCAR" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnImprimir" CssClass="buttons" OnClick="btnImprimir_Click" 
        runat="server" Text="IMPRIMIR" OnClientClick = "return PrintPanel();" />
	    <br />
	    <br />

	    <div id="estadocuenta" style=" width:1120px; ">
	    <div align="left">
        <asp:HyperLink ID="HyperLinkLogo" runat="Server" ImageUrl="~/Images/logo.png" NavigateUrl=""></asp:HyperLink>
        </div>
        <br />
        <h2 style="text-align:left;">Cliente: <asp:Label style="text-align:left; color:Black;" ID="lblCliente" runat="server" Text=""></asp:Label></h2> 
	    <h2 style="text-align:left;">Correo: <asp:Label style="text-align:left;color:Black;" ID="lblCorreo" runat="server" Text=""></asp:Label></h2> 
	    <br />
	    <h2 style="text-align:left;">RESUMEN DE MOVIMIENTOS Nro de Tarjeta <%=ddlTarjetas.SelectedItem.Text%> Periodo <%=ddlMes.SelectedItem.Text%> <%=ddlAno.SelectedItem.Text%></h2>
        <div style="text-align:left; border-top-style:solid; border-top-width:3px;">
            <table border="0"> 
            <tr> 
               <th style="width:550px;">Concepto</th> 
               <th style="width:550px;">Cantidad</th> 
               <th style="width:550px;">Monto Total</th> 
            </tr> 
            <tr> 
               <td>Solicitudes Realizadas:</td> 
               <td style="text-align:center;"><asp:Label ID="lblSolicitadasCantidad" runat="server" Text="0"></asp:Label></td> 
               <td style="text-align:right;"><asp:Label ID="lblSolicitadasMonto" runat="server" Text="0"></asp:Label></td> 
            </tr> 
            <tr> 
               <td>Solicitudes Rechazadas:</td> 
               <td style="text-align:center;"><asp:Label ID="lblRechazadasCantidad" runat="server" Text="0"></asp:Label></td> 
               <td style="text-align:right;"><asp:Label ID="lblRechazadasMonto" runat="server" Text="0"></asp:Label></td> 
            </tr> 
            <tr> 
               <td>Solicitudes Pagadas:</td> 
               <td style="text-align:center;"><asp:Label ID="lblPagadaCantidad" runat="server" Text="0"></asp:Label></td> 
               <td style="text-align:right;"><asp:Label ID="lblPagadaMonto" runat="server" Text="0"></asp:Label></td> 
            </tr> 
            </table> 
            <br />
            
        </div>
        <br />
        <h2 style="text-align:left">RESUMEN DE SALDO</h2>
        <div style="text-align:left; border-top-style:solid; border-top-width:3px;">
            <br />
            <table border="0"> 
            <tr> 
               <th style="width:550px; text-align:left;">Saldo:</th> 
               <th style="width:560px; text-align:right;"><asp:Label ID="lblSaldo" runat="server" Text="0"></asp:Label></th> 
               
            </tr> 
            </table>
        </div>
        <br />
        <div style="text-align:left; border-top-style:solid; border-top-width:3px;">
            <br />
        <h2>ESTADO DE CUENTA</h2><br />
       <h3 style="color:Black;"> DETALLE DE MOVIMIENTOS</h3><br />
        <br />
        </div>
        <asp:GridView ID="gvSolicitudes" DataKeyNames="SolicitudID"
        AllowSorting="false" runat="server" AutoGenerateColumns="false" 
            HeaderStyle-Wrap="false" ShowFooter="FALSE" Width="1120px"
           
            CellPadding="10" CellSpacing="10" Font-Bold="True" Font-Size="Medium" 
            >
        <RowStyle HorizontalAlign="Center" />
        <Columns>
        
         <asp:BoundField DataField="FechaCreado" HeaderText="Fecha" SortExpression="FechaCreado" dataformatstring="{0:MMMM d, yyyy}" htmlencode="false"/>
         <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion"  />
         <asp:BoundField DataField="SolicitudID" HeaderText="Nro" SortExpression="SolicitudID"/>
            
            <asp:BoundField DataField="Numero_Factura" HeaderText="Factura" SortExpression="Numero_Factura" />
            <asp:BoundField DataField="Monto" HeaderText="Valor de Factura" 
                SortExpression="Monto" HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:###,###,###,###.00}"
                ItemStyle-HorizontalAlign="Right">        
                <HeaderStyle HorizontalAlign="Right"></HeaderStyle>

            <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Monto_Pagado" HeaderText="Monto" 
                SortExpression="Pagado" HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:###,###,###,###.00}"
                ItemStyle-HorizontalAlign="Right" >
                <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Estado" HeaderText="D/C" SortExpression="Estado"/>
            <asp:BoundField DataField="Saldo" HeaderText="Saldo" 
                SortExpression="Saldo" HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:###,###,###,###.00}"
                ItemStyle-HorizontalAlign="Right" >
                <HeaderStyle HorizontalAlign="Right"></HeaderStyle>

            <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>

        </Columns>


            <HeaderStyle Wrap="False" />


    </asp:GridView>
    
        <br />
        <br />
        </div>
	</div>

</asp:Content>

