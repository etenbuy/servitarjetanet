<%@ Page Language="C#" MasterPageFile="~/Operaciones/Operaciones.master" AutoEventWireup="true" CodeBehind="Consultar.aspx.cs" Inherits="Web.Operaciones.Saldo.Consultar" Title="SERVITARJETA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent" runat="server">

 <div align="center">

    <h1>
        Saldos y Movimientos</h1>
    <div>
        
        <br />
    <asp:Label ID="lblMensaje" ForeColor="#FE7000" runat="server" Text=""></asp:Label>
       <!-- Cantidad :
       <asp:Label ID="lblTotalSolicitudes" Text="0" runat="server"></asp:Label>   -->  
        <asp:GridView ID="gvSolicitudes" CellPadding="0" CellSpacing="0" CssClass="Formulario"
        AllowSorting="true" HeaderStyle-Wrap="false" runat="server" Font-Size="10px"
       OnSorting="gvSolicitudes_Sorting" AutoGenerateColumns="false"  ShowFooter="true"
         ondatabound="gvSolicitudes_DataBound" Width="1136px">
        <RowStyle HorizontalAlign="Center" />
        <Columns>
       
            <asp:HyperLinkField
            DataNavigateUrlFields="SolicitudID"
            DataNavigateUrlFormatString="Detalle.aspx?ID={0}"
            DataTextField="SolicitudID"
            HeaderText="Nº Solicitud"
            SortExpression="SolicitudID" />
            <asp:BoundField DataField="FechaCreado" HeaderText="Fecha Solicitud" SortExpression="FechaCreado" dataformatstring="{0:MMMM d, yyyy}" htmlencode="false"/>
            <asp:BoundField DataField="Numero_Factura" HeaderText="Nº Factura" SortExpression="Numero_Factura"/>
            <asp:BoundField DataField="Monto" HeaderText="Monto Factura" SortExpression="Monto"/>        
            <asp:BoundField DataField="Monto_Pagado" HeaderText="Monto a Pagar" SortExpression="Pagado" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado"/>          
        </Columns>

    </asp:GridView>
    </div>

  

</asp:Content>
 