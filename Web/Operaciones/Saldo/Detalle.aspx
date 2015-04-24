<%@ Page Language="C#" MasterPageFile="~/Operaciones/Operaciones.master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Web.Operaciones.Saldo.Detalle" Title="SERVITARJETA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent" runat="server">
 <div align="center">
    <h1>
        Detalle</h1>
    <div>
        <br />
    <asp:Label ID="lblMensaje" ForeColor="#FE7000" runat="server" Text=""></asp:Label>
        <div style="float:left;">
        <asp:DetailsView ID="dtvDetalle" runat="server" CssClass="detalles"
            AutoGenerateRows="False" BorderStyle="None" GridLines="None">
          <Fields>
           <asp:BoundField DataField="SolicitudID" HeaderText="Solicitud" SortExpression="SolicitudID"/>
            <asp:BoundField DataField="Numero_Factura" HeaderText="Nº Factura" SortExpression="Numero_Factura"/>            
            <asp:BoundField DataField="Ntdc" HeaderText="Nº TDC o Cuenta Bancaria" SortExpression="Ntdc"/>
            <asp:BoundField DataField="Monto_Pagado" HeaderText="Monto Pagado" SortExpression="Monto_Pagado"/>
          </Fields> 
        </asp:DetailsView>
        </div>
        <div style="float:right;">
        <asp:DetailsView ID="dtvDetalle2" runat="server" CssClass="detalles"
            AutoGenerateRows="False" BorderStyle="None" GridLines="None">
          <Fields>
           <asp:BoundField DataField="FechaCreado" HeaderText="Fecha Solicitud" SortExpression="Fecha_Creado"/>
            <asp:BoundField DataField="Monto_Factura" HeaderText="Monto Factura" SortExpression="Monto_Factura"/>            
            <asp:BoundField DataField="Ndeposito" HeaderText="Nº Deposito" SortExpression="Ndeposito"/>
            <asp:BoundField DataField="FechaPagado" HeaderText="Fecha Pagado" SortExpression="FechaPagado"/>
          </Fields> 
        </asp:DetailsView>
        </div>
    </div>
<a href="Consultar.aspx" style="color:#134e9d">Volver</a>
</asp:Content>
 