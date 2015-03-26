<%@ Page Language="C#" MasterPageFile="~/Configuracion/Configuracion.master" AutoEventWireup="true" CodeBehind="AdministrarClientes.aspx.cs" Inherits="Web.Configuracion.Clientes.AdministrarClientes" Title="SERVITARJETA 2.0" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent" runat="server">

 

    <h2>
        Crear Cuentas Cliente</h2>
    <div>
    <asp:Label ID="lblMensaje" ForeColor="#FE7000" runat="server" Text=""></asp:Label>
        <table class="Formulario" cellpadding="0" cellspacing="0">
           
            <tr>
                <th>
                    Nombre:
                </th>
                <td colspan="2">
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="Requerido!" runat="server"
                        ValidationGroup="Submit" ErrorMessage="Requerido!" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    Numero Cuenta:
                </th>
                <td colspan="2">
                    <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtNumero"
                        FilterType="Numbers">
                    </asp:FilteredTextBoxExtender>
                    
                </td>
                <td>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="^[1-9]+[0-9]*$"
                        runat="server" ControlToValidate="txtNumero" ErrorMessage="*" ValidationGroup="Submit">
                        </asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Requerido!" runat="server"
                        ValidationGroup="Submit" ErrorMessage="Requerido!" ControlToValidate="txtNumero"></asp:RequiredFieldValidator>
                </td>
            </tr>
           <tr>
                <th>
                    Tipo:
                </th>
                <td colspan="2">
                    <asp:TextBox ID="txtTipo" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="Requerido!" runat="server"
                        ValidationGroup="Submit" ErrorMessage="Requerido!" ControlToValidate="txtTipo"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    RIF:
                </th>
                <td colspan="2">
                    <asp:TextBox ID="txtRif" runat="server" MaxLength="10"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="Requerido!" runat="server"
                        ValidationGroup="Submit" ErrorMessage="Requerido!" ControlToValidate="txtRif"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
            <tr>
                <th>
                    Activo
                </th>
                <td colspan="3">
                    <asp:RadioButtonList ID="rbtnActivo" runat="server" Width="95px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
          
          
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnCrear" runat="server" Text="Guardar" OnClick="btnCrear_Click"
                        ValidationGroup="Submit" OnClientClick="if (!Page_ClientValidate('Submit')) return false; if (!confirm('¿Esta seguro de crear este cliente?')) return false;" />
                    
                </td>
            </tr>
           
            
        </table>
        Cantidad :<asp:Label ID="lblTotalClientes" Text="0" runat="server"></asp:Label>    
        <asp:GridView ID="gvClientes" CellPadding="0" CellSpacing="0" CssClass="Formulario"
        AllowSorting="true" HeaderStyle-Wrap="false" runat="server" Font-Size="10px"
       OnSorting="gvClientes_Sorting" AutoGenerateColumns="false"  ShowFooter="true"
         ondatabound="gvClientes_DataBound">
        <RowStyle HorizontalAlign="Center" />
        <Columns>
            <asp:BoundField DataField="CuentaID" Visible="false" HeaderText="CuentaID" SortExpression="CuentaID"/>
            <asp:BoundField DataField="co_cli" HeaderText="Rif" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="Rif" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="Nombre" />
                <asp:BoundField DataField="numero" HeaderText="Cuenta" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="Cuenta" />
            <asp:BoundField DataField="activodescripcion" HeaderText="Activo" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="Activo" />
            
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="hfCuentaID" Value='<%#Eval("cuentaid")%>' runat="server" />
                   
                    
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView>
    </div>

  

</asp:Content>
 