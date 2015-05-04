<%@ Page Language="C#" MasterPageFile="~/Operaciones/Operaciones.master" AutoEventWireup="true" CodeBehind="Consultar.aspx.cs" Inherits="Web.Operaciones.Saldo.Consultar" Title="SERVITARJETA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent" runat="server">

 <div align="center">
 <script type = "text/javascript">
     function PrintPanel() {
         var panel = document.getElementById("<%= pnlPopup.ClientID %>");
         var printWindow = window.open('', '', 'height=400,width=800');
         printWindow.document.write('<html><head><title>DETALLES DE PAGO DE SOLICITUD</title>');
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
    <h1>
        Saldos y Movimientos</h1>
    <div>
        
        <table style="width:550px">
            <tr>
                <td style="   padding-right: 50px; width:200px; font-weight:bolder; border-bottom-color:#134e9d; border-style: ridge; border-top: aliceblue; border-left: aliceblue; border-right: aliceblue;
                        border-bottom-color: #134e9d;">
                     MONTO TOTAL PAGADO
                </td>
                 <td style="   padding-right: 50px; width:200px; font-weight:bolder; border-bottom-color:#134e9d; border-style: ridge; border-top: aliceblue; border-left: aliceblue; border-right: aliceblue;
                        border-bottom-color: #134e9d;">
                     MONTO TOTAL EN PROCESO
                </td>
                
            </tr>
            
            <tr>
                 <td style="font-weight:bolder; font-size:50px; color:LightGreen; padding-top:30px;">
                     <asp:Label ID="lblTotalPagado" runat="server" Text="Label"></asp:Label>
                </td>
                <td style="font-weight:bolder; font-size:50px; color:Orange; padding-top:30px;">
                    <asp:Label ID="lblTotalProceso" runat="server" Text="Label"></asp:Label></td>
               
            </tr>
            
        </table>
        <br />
        <br />
        <br />
    <asp:Label ID="lblMensaje" ForeColor="#FE7000" runat="server" Text=""></asp:Label>

        <asp:GridView ID="gvSolicitudes" DataKeyNames="SolicitudID"
        AllowSorting="true" runat="server" 
       OnSorting="gvSolicitudes_Sorting" AutoGenerateColumns="false" 
            HeaderStyle-Wrap="false" ShowFooter="true" Width="1136px"
            onselectedindexchanged="gvSolicitudes_SelectedIndexChanged" 
            CellPadding="10" CellSpacing="10" Font-Bold="True" Font-Size="Medium" 
            onrowdatabound="gvSolicitudes_RowDataBound">
        <RowStyle HorizontalAlign="Center" />
        <Columns>
         <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="SolicitudID" HeaderText="Nº Solicitud" SortExpression="SolicitudID"/>
            <asp:BoundField DataField="FechaCreado" HeaderText="Fecha de Solicitud" SortExpression="FechaCreado" dataformatstring="{0:MMMM d, yyyy}" htmlencode="false"/>
            <asp:BoundField DataField="Numero_Factura" HeaderText="Nº Factura" SortExpression="Numero_Factura" FooterText="Total"/>
            <asp:BoundField DataField="Monto" HeaderText="Monto de Factura" 
                SortExpression="Monto" HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:###,###,###,###.00}"
                ItemStyle-HorizontalAlign="Right">        
                <HeaderStyle HorizontalAlign="Right"></HeaderStyle>

            <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Monto_Pagado" HeaderText="Monto a Reembolsar" 
                SortExpression="Pagado" HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:###,###,###,###.00}"
                ItemStyle-HorizontalAlign="Right" >
                <HeaderStyle HorizontalAlign="Right"></HeaderStyle>

            <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado"/>  
           
           <asp:TemplateField>
                <ItemTemplate>
                <asp:HiddenField ID="hfMonto_Pagado" runat="server" Value='<%#Eval("Monto_Pagado") %>'  />
                    <asp:HiddenField ID="hfMonto" runat="server" Value='<%#Eval("Monto") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>


            <HeaderStyle Wrap="False" />


    </asp:GridView>
    
     <asp:Panel ID="pnlPopup" ScrollBars="None" runat="server" CssClass="PopUp" Style="display: none;" Height="400px">
                 <asp:UpdatePanel ID="upanPopUp" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="">
                                <table width="100%">
                                    <tr>
                                        <td style="color: #134e9d; font-weight:bold; font-size:larger;" align="center">
                                            DETALLES DE PAGO DE SOLICITUD
                                        </td>
                                        <td style="width: 5%;" align="right;">
                                            <asp:LinkButton ID="btnCerrar" runat="server" Text="x" CssClass="CloseButton" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <asp:Button CssClass="buttons" ID="btnShowPopup" runat="server" Style="display: none" />
                            <asp:ModalPopupExtender ID="mdlPopup" runat="server" TargetControlID="btnShowPopup"
                                PopupControlID="pnlPopup" CancelControlID="btnCerrar" BackgroundCssClass="modalBackground">
                            </asp:ModalPopupExtender>
                            <asp:Label ID="lblSolicitud" runat="server" Text=""></asp:Label>
                            <br />
                            <br />
                                <table style="width: 100%"; id="detail"; ">
                                 <tbody>
                                    <tr>
                                        <td style="   padding-right: 50px; width:200px; font-weight:bolder; border-bottom-color:#134e9d; border-style: ridge; border-top: aliceblue; border-left: aliceblue; border-right: aliceblue;
                                                border-bottom-color: #134e9d;">
                                             NRO DE SOLICITUD
                                        </td>
                                        <td style="font-weight:bolder;">
                                            <asp:Label ID="lblsolicitudid" runat="server" Text=""></asp:Label>  
                                        </td>
                                   
                                     
                                        <td style="   padding-right: 50px; width:200px; font-weight:bolder; border-bottom-color:#134e9d; border-style: ridge; border-top: aliceblue; border-left: aliceblue; border-right: aliceblue;
                                                border-bottom-color: #134e9d;">
                                             FECHA DE SOLICITUD
                                        </td>
                                        <td style="font-weight:bolder;"> 
                                             <asp:Label ID="lblFechaCreado" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style=" font-weight:bolder; border-bottom-color:#134e9d; border-style: ridge; border-top: aliceblue; border-left: aliceblue; border-right: aliceblue;
                                                border-bottom-color: #134e9d;">
                                             NRO DE FACTURA
                                        </td>
                                        <td style="font-weight:bolder;">
                                             <asp:Label ID="lblNumero_Factura" runat="server" Text=""></asp:Label> 
                                        </td>
                                  
                                        <td style=" font-weight:bolder; border-bottom-color:#134e9d; border-style: ridge; border-top: aliceblue; border-left: aliceblue; border-right: aliceblue;
                                                border-bottom-color: #134e9d;">
                                             MONTO DE FACTURA
                                        </td>
                                        <td style="font-weight:bolder;">
                                             <asp:Label ID="lblMonto_Factura" runat="server" Text=""></asp:Label> 
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style=" font-weight:bolder; border-bottom-color:#134e9d; border-style: ridge; border-top: aliceblue; border-left: aliceblue; border-right: aliceblue;
                                                border-bottom-color: #134e9d;">
                                             NRO DE TDC o CUENTA BANCARIA
                                        </td>
                                        <td style="font-weight:bolder;">
                                            <asp:Label ID="lblNtdc" runat="server" Text=""></asp:Label> 
                                        </td>
                                  
                                        <td style=" font-weight:bolder; border-bottom-color:#134e9d; border-style: ridge; border-top: aliceblue; border-left: aliceblue; border-right: aliceblue;
                                                border-bottom-color: #134e9d;">
                                             NRO DE DEPOSITO
                                        </td>
                                        <td style="font-weight:bolder;">
                                             <asp:Label ID="lblNdeposito" runat="server" Text=""></asp:Label> 
                                        </td>
                                    </tr>
                                     <tr>
                                        <td style=" font-weight:bolder; border-bottom-color:#134e9d; border-style: ridge; border-top: aliceblue; border-left: aliceblue; border-right: aliceblue;
                                                border-bottom-color: #134e9d;">
                                             MONTO PAGADO
                                        </td>
                                        <td style="font-weight:bolder;">
                                             <asp:Label ID="lblMonto_Pagado" runat="server" Text=""></asp:Label> 
                                        </td>
                                  
                                        <td style=" font-weight:bolder; border-bottom-color:#134e9d; border-style: ridge; border-top: aliceblue; border-left: aliceblue; border-right: aliceblue;
                                                border-bottom-color: #134e9d;">
                                             FECHA DE PAGO
                                        </td>
                                        <td style="font-weight:bolder;">
                                             <asp:Label ID="lblFechaPagado" runat="server" Text=""> </asp:Label> 
                                        </td>
                                    </tr>
                                 </tbody>
                                </table>
                            
                           
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                    <br />
                        <asp:Button CssClass="buttons" ID="btnPrint" runat="server" Text="IMPRIMIR" 
                            OnClientClick = "return PrintPanel();" onclick="btnPrint_Click" />
                </asp:Panel>
   
  
    </div>

  

</asp:Content>
 