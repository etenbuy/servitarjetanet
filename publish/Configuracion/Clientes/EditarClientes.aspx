<%@ Page Language="C#" MasterPageFile="~/Configuracion/Configuracion.master" AutoEventWireup="true" CodeBehind="EditarClientes.aspx.cs" Inherits="Web.Configuracion.Clientes.EditarClientes" Title="SERVITARJETA 2.0" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent" runat="server">

 

    <h2>
        Editar Cuentas Cliente</h2>
    <div>
    <asp:Label ID="lblMensaje" ForeColor="#FE7000" runat="server" Text=""></asp:Label>
        <table class="Formulario" cellpadding="0" cellspacing="0">
           <tr>
                <th>
                    ID:
                </th>
                <td colspan="2">
                    <asp:TextBox ID="txtID" runat="server" Enabled="false"></asp:TextBox>
                </td>
                <td>
                    
                </td>
            </tr>
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
                 <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                        runat="server">
   <%--                      runat="server" ControlToValidate="txtNumero" ErrorMessage="solo numeros" ValidationGroup="Submit">--%>
                        <%--</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Requerido!" runat="server"
                        ValidationGroup="Submit" ErrorMessage="Requerido!" ControlToValidate="txtNumero"></asp:RequiredFieldValidator>--%>--%>
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
                    
                    <asp:Button ID="btnGuardar" runat="server" Visible="true" Text="Guardar" OnClick="btnGuardar_Click"
                        OnClientClick="if (!Page_ClientValidate()) return false; if (!confirm('¿Esta seguro de actualizar este cliente?')) return false;"
                        ValidationGroup="Submit" />
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
                   <asp:LinkButton ID="lbtnEditar" Text="Editar" runat="server" OnClick="btnEditar_Click"></asp:LinkButton>
                    
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView>
    
    </div>

  

</asp:Content>
 