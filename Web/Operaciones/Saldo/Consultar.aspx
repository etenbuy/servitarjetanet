<%@ Page Language="C#" MasterPageFile="~/Operaciones/Operaciones.master" AutoEventWireup="true" CodeBehind="Consultar.aspx.cs" Inherits="Web.Operaciones.Saldo.Consultar" Title="SERVITARJETA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent" runat="server">

 

    <h2>
        Saldos y Movimientos</h2>
    <div>
        
         <br />
        <br />
        <div align="left" style="float: left; width: 544px;">
        
         <asp:TextBox runat="server" ID="txtCalFechaDesde" OnTextChanged="txtCalFechaDesde_SelectionChanged" AutoPostBack="true" Width="150" />
               
                <asp:CalendarExtender ID="calendarFechaDesde" Format="dd/MM/yyyy" runat="server" TargetControlID="txtCalFechaDesde"
                    Animated="true" />
          </div>
        <div align="right" style="float: right; width: 586px; height: 57px;">
        
        <asp:TextBox runat="server" ID="txtCalFechaHasta" OnTextChanged="txtCalFechaHasta_SelectionChanged" AutoPostBack="true" Width="150" />
               
                <asp:CalendarExtender ID="calendarFechaHasta" Format="dd/MM/yyyy" runat="server" TargetControlID="txtCalFechaHasta"
                    Animated="true" />
        </div>
        <br />
        <br />
    <asp:Label ID="lblMensaje" ForeColor="#FE7000" runat="server" Text=""></asp:Label>
    
   
    
        Cantidad :<asp:Label ID="lblTotalDividendos" Text="0" runat="server"></asp:Label>    
        <asp:GridView ID="gvDividendos" CellPadding="0" CellSpacing="0" CssClass="Formulario"
        AllowSorting="true" HeaderStyle-Wrap="false" runat="server" Font-Size="10px"
       OnSorting="gvDividendos_Sorting" AutoGenerateColumns="false"  ShowFooter="true"
         ondatabound="gvDividendos_DataBound" Width="1136px">
        <RowStyle HorizontalAlign="Center" />
        <Columns>
            <asp:BoundField DataField="Numero" HeaderText="Numero" SortExpression="Numero"/>           
            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado"/>
             <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha"/>
            <asp:BoundField DataField="Monto" HeaderText="Monto" SortExpression="Monto"/>
                 <asp:BoundField DataField="Pagado" HeaderText="Pagado" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="Pagado" >
            </asp:BoundField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="hfClienteID" Value='<%#Eval("Clienteid")%>' runat="server" visible="false"/>
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>

    </asp:GridView>
    </div>

  

</asp:Content>
 