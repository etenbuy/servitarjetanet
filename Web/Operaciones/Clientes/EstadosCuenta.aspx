<%@ Page Language="C#" MasterPageFile="~/Operaciones/Operaciones.master" AutoEventWireup="true"
    CodeBehind="EstadosCuenta.aspx.cs" Inherits="Web.Operaciones.Clientes.EstadosCuenta" Title="SERVITARJETA" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent" runat="server">
    <div align="center">  
    <div>
        <asp:Label ID="lblTarjeta" runat="server" Font-Size="Large" Text="Seleccione Mes y Año" ForeColor="#134e9d"></asp:Label>
        <br />
        <br />
      
        <asp:GridView ID="gvSolicitudes" DataKeyNames="SolicitudID"
        AllowSorting="false" runat="server" AutoGenerateColumns="false" 
            HeaderStyle-Wrap="false" ShowFooter="FALSE" Width="1136px"
            onselectedindexchanged="gvSolicitudes_SelectedIndexChanged" 
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
        <asp:Button ID="btnEnviar" CssClass="buttons" OnClick="btnEnviar_Click" runat="server" Text="ENVIAR" />
	</div>

</asp:Content>

