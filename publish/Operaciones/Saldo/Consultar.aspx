<%@ Page Language="C#" MasterPageFile="~/Operaciones/Operaciones.master" AutoEventWireup="true" CodeBehind="Consultar.aspx.cs" Inherits="Web.Operaciones.Saldo.Consultar" Title="SERVITARJETA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent" runat="server">

 

    <h2>
        Saldos y Movimientos</h2>
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
            <asp:BoundField DataField="SolicitudID" HeaderText="Numero" SortExpression="SolicitudID"/>           
            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado"/>
             <asp:BoundField DataField="FechaCreado" HeaderText="Fecha" SortExpression="Fecha"/>
            <asp:BoundField DataField="Monto" HeaderText="Monto" SortExpression="Monto"/>
                 <asp:BoundField DataField="Monto_Pagado" HeaderText="Pagado" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="Pagado" >
            </asp:BoundField>            
        </Columns>

    </asp:GridView>
    </div>

  

</asp:Content>
 