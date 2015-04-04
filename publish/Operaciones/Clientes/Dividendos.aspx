<%@ Page Language="C#" MasterPageFile="~/Operaciones/Operaciones.master" AutoEventWireup="true"
    CodeBehind="Dividendos.aspx.cs" Inherits="Web.Operaciones.Clientes.Dividendos"
    Title="SERVITARJETA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent" runat="server">

  <h2>
        Mis Dividendos</h2>
    <div>
    
    <asp:Label ID="lblMensaje" ForeColor="#FE7000" runat="server" Text=""></asp:Label>
      
        
        <asp:GridView ID="gvDividendos" 
                    CssClass="Formulario" runat="server"
        AutoGenerateColumns="false"  ShowFooter="true"  ondatabound="gvDividendos_DataBound" 
        onrowdatabound="gvDividendos_RowDataBound">
           
                <RowStyle HorizontalAlign="Center" />
        
                  
                    <Columns>
                    
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HiddenField ID="hfMonto" runat="server" Value='<%#Eval("Monto") %>' />   
                            <asp:HiddenField ID="hfDividendo" runat="server" Value='<%#Eval("Dividendo_Obtenido") %>' />                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha"/>
                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"/>
                        <asp:BoundField DataField="Tdc" HeaderText="TDC" SortExpression="TDC" 
                            FooterText="Totales" ItemStyle-Width="20%">
<ItemStyle Width="20%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Monto" HeaderText="Monto" SortExpression="monto" DataFormatString="{0:###,###,###,###.000}" />
                        <asp:BoundField DataField="Dividendo_Obtenido" HeaderText="Dividendo" SortExpression="Dividendo" DataFormatString="{0:###,###,###,###.000}" />
                        
                    </Columns>
    </asp:GridView>
  

    </div>

 
</asp:Content>
