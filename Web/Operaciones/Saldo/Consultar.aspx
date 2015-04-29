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
        <asp:GridView ID="gvSolicitudes" CellPadding="0" CellSpacing="10" 
        AllowSorting="true" HeaderStyle-Wrap="false" runat="server" BorderWidth="0px" Font-Size="Large"
       OnSorting="gvSolicitudes_Sorting" AutoGenerateColumns="false"  ShowFooter="true"
         ondatabound="gvSolicitudes_DataBound" Width="1136px">
        <RowStyle HorizontalAlign="Center" />
        <Columns>
       
                        <asp:BoundField DataField="SolicitudID" HeaderText="Nº Solicitud" SortExpression="SolicitudID"/>
            <asp:BoundField DataField="FechaCreado" HeaderText="Fecha de Solicitud" SortExpression="FechaCreado" dataformatstring="{0:MMMM d, yyyy}" htmlencode="false"/>
            <asp:BoundField DataField="Numero_Factura" HeaderText="Nº Factura" SortExpression="Numero_Factura"/>
            <asp:BoundField DataField="Monto" HeaderText="Monto de Factura" SortExpression="Monto"/>        
            <asp:BoundField DataField="Monto_Pagado" HeaderText="Monto a Reembolsar" SortExpression="Pagado" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado"/>  
            <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField ID="hfSolicitud" Value='<%#Eval("SolicitudID")%>' runat="server" />
                                <asp:LinkButton ID="lbtnDetalle" runat="server" OnClick="lbtnDetalle_Click" Text="Detalle"></asp:LinkButton>
                            </ItemTemplate>
            </asp:TemplateField>      
        </Columns>

    </asp:GridView>
    
     <asp:Panel ID="pnlPopup" runat="server" CssClass="PopUp" Style="display: none;" Height="400px"
                    ScrollBars="Vertical">
                    <asp:UpdatePanel ID="upanPopUp" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="Header">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            Detalle
                                        </td>
                                        <td style="width: 5%;" align="right;">
                                            <asp:LinkButton ID="btnCerrar" runat="server" Text="x" CssClass="CloseButton" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
                            <asp:ModalPopupExtender ID="mdlPopup" runat="server" TargetControlID="btnShowPopup"
                                PopupControlID="pnlPopup" CancelControlID="btnCerrar" BackgroundCssClass="modalBackground">
                            </asp:ModalPopupExtender>
                            <asp:Label ID="lblSolicitud" runat="server" Text=""></asp:Label>
                            <asp:GridView ID="gvDetalles" CellPadding="0" CellSpacing="0" CssClass="Formulario" HeaderStyle-Wrap="false"
                                runat="server" Font-Size="10px" AutoGenerateColumns="false">
                                <RowStyle ForeColor="#00cc00" />
                                <Columns>
                                    <asp:BoundField DataField="SolicitudID" HeaderText="Solicitud" />
                                    <asp:BoundField DataField="Numero_Factura" HeaderText="N Factura" />
                                    <asp:BoundField DataField="Ntdc" HeaderText="N TDC o Cuenta" />
                                    <asp:BoundField DataField="Monto_Pagado" HeaderText="Monto Pagado" />
                                    <asp:BoundField DataField="FechaCreado" HeaderText="Fecha Solicitud" />
                                    <asp:BoundField DataField="Monto_Factura" HeaderText="Monto Factura" />
                                    <asp:BoundField DataField="Ndeposito" HeaderText="N Deposito" />
                                    <asp:BoundField DataField="FechaPagado" HeaderText="Fecha Pago" />
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
        <asp:LinkButton ID="kbkPrint" runat="server" onclick="kbkPrint_Click">IMPRIMIR</asp:LinkButton>
       
  
    </div>

  

</asp:Content>
 