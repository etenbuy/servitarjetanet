<%@ Page Language="C#" MasterPageFile="~/Configuracion/Configuracion.master" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="Web.Configuracion.Dividendos.Crear" Title="SERVITARJETA 2.0" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent" runat="server">

 

    <h2>
        Crear Dividendos</h2>
    <div>
    <asp:Label ID="lblMensaje" ForeColor="#FE7000" runat="server" Text=""></asp:Label>
        <table class="Formulario" cellpadding="0" cellspacing="0">
           
            <tr>
                <th>
                    Fecha:
                </th>
               
                 <td colspan="2">
                    <asp:TextBox runat="server" ID="txtFecha"  Width="200" />
                    <asp:CalendarExtender ID="Calendar" Format="dd/MM/yyyy" runat="server" TargetControlID="txtFecha" />
                </td>
            </tr>
            
            <tr>
                <th>
                    Cliente:
                </th>
                <td colspan="2">
                    <asp:DropDownList ID="ddlCliente" onkeyup="fn(this.form,this)" Width="300" DataTextField="Nombre" DataValueField="ClienteID"
                        runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                </td>
            </tr>
            
            <tr>
                <th>
                    TDC:
                </th>
                <td colspan="2">
                    <asp:TextBox ID="txtTdc" runat="server"></asp:TextBox>
                </td>
                <td>
               
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Requerido!" runat="server"
                        ValidationGroup="Submit" ErrorMessage="Requerido!" ControlToValidate="txtTdc"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    Monto:
                </th>
                <td colspan="2">
                    <asp:TextBox ID="txtMonto" runat="server"></asp:TextBox>
                </td>
                <td>
               
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="Requerido!" runat="server"
                        ValidationGroup="Submit" ErrorMessage="Requerido!" ControlToValidate="txtMonto"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <th>
                    Dividendo:
                </th>
                <td colspan="2">
                    <asp:TextBox ID="txtDividendo" runat="server"></asp:TextBox>
                </td>
                <td>
               
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="Requerido!" runat="server"
                        ValidationGroup="Submit" ErrorMessage="Requerido!" ControlToValidate="txtDividendo"></asp:RequiredFieldValidator>
                </td>
            </tr>
            

            <tr>
                <td colspan="4">
                    <asp:Button ID="btnCrear" runat="server" Text="Guardar" OnClick="btnCrear_Click"
                        ValidationGroup="Submit" OnClientClick="if (!Page_ClientValidate('Submit')) return false; if (!confirm('¿Esta seguro de crear este dividendo?')) return false;" />
                    
                </td>
            </tr>
           
            
        </table>
        Cantidad :<asp:Label ID="lblTotalDividendos" Text="0" runat="server"></asp:Label>    
        <asp:GridView ID="gvDividendos" CellPadding="0" CellSpacing="0" CssClass="Formulario"
        AllowSorting="true" HeaderStyle-Wrap="false" runat="server" Font-Size="10px"
       OnSorting="gvDividendos_Sorting" AutoGenerateColumns="false"  ShowFooter="true"
         ondatabound="gvDividendos_DataBound">
        <RowStyle HorizontalAlign="Center" />
        <Columns>
            <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente"/>
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha"/>
            <asp:BoundField DataField="Tdc" HeaderText="TDC" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="TDC" />
            <asp:BoundField DataField="Monto" HeaderText="Monto" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="Monto" />
                <asp:BoundField DataField="Dividendo_Obtenido" HeaderText="Dividendo" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="Dividendo" />
            
                
            
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="hfClienteID" Value='<%#Eval("Clienteid")%>' runat="server" />
                   
                    
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView>
    </div>

  

</asp:Content>
 