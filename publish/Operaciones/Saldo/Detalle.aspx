<%@ Page Language="C#" MasterPageFile="~/Operaciones/Operaciones.master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Web.Operaciones.Saldo.Detalle" Title="SERVITARJETA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent" runat="server" >
    
    <h1>
        Detalles de Pago de solicitud</h1>
        
        <h2>
        <asp:HyperLink runat="server" NavigateUrl="~/Operaciones/Saldo/Consultar.aspx">Volver</asp:HyperLink></h2>
     
    <asp:Label ID="lblSolicitud" runat="server" Text=""></asp:Label>
     
    <div style="position:relative; float:left; font-size:large;">
        <asp:DetailsView ID="dtvDetalles" runat="server"
            AutoGenerateRows="False">
              <Fields>
               <asp:BoundField DataField="SolicitudID" HeaderText="Solicitud" SortExpression="SolicitudID" />
               <asp:BoundField DataField="Numero_Factura" HeaderText="N Factura" SortExpression="Numero_Factura" />
               <asp:BoundField DataField="Ntdc" HeaderText="N TDC o Cuenta" SortExpression="Ntdc" />
               <asp:BoundField DataField="Monto_Pagado" HeaderText="Monto Pagado" SortExpression="Monto_Pagado" />
                </Fields>
        </asp:DetailsView>
        
    </div>
    <div style="position:relative; float:left;  font-size:large;">
        <asp:DetailsView ID="dtvDetalles2" runat="server" Height="50px" Width="350px" 
            AutoGenerateRows="False" BorderStyle="None" GridLines="None" CellPadding="10" CellSpacing="10">
              <Fields>
               <asp:BoundField DataField="FechaCreado" HeaderText="Fecha Solicitud" SortExpression="FechaCreado" />
                <asp:BoundField DataField="Monto_Factura" HeaderText="Monto Factura" SortExpression="Monto_Factura" />
                 <asp:BoundField DataField="Ndeposito" HeaderText="N Deposito" SortExpression="Ndeposito" />
                  <asp:BoundField DataField="FechaPagado" HeaderText="Fecha Pago" SortExpression="FechaPagado" />
                </Fields>
        </asp:DetailsView>
        
    </div>
</asp:Content>
 