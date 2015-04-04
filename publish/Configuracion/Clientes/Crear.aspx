<%@ Page Language="C#" MasterPageFile="~/Configuracion/Configuracion.master" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="Web.Configuracion.Clientes.Crear" Title="SERVITARJETA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent" runat="server">

 

    <h2>
        Crear Clientes</h2>
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
                    Direcci�n:
                </th>
                <td colspan="2">
                    <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                </td>
                <td>
               
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Requerido!" runat="server"
                        ValidationGroup="Submit" ErrorMessage="Requerido!" ControlToValidate="txtDireccion"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    Telefono:
                </th>
                <td colspan="2">
                    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                </td>
                <td>
               
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="Requerido!" runat="server"
                        ValidationGroup="Submit" ErrorMessage="Requerido!" ControlToValidate="txtTelefono"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
            <tr>
                <th>
                    Email:
                </th>
                <td colspan="2">
                    <asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
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
                <td colspan="4">
                    <asp:Button ID="btnCrear" runat="server" Text="Guardar" OnClick="btnCrear_Click"
                        ValidationGroup="Submit" OnClientClick="if (!Page_ClientValidate('Submit')) return false; if (!confirm('�Esta seguro de crear este cliente?')) return false;" />
                    
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
            <asp:BoundField DataField="ClienteID" Visible="false" HeaderText="ClienteID" SortExpression="ClienteID"/>
            <asp:BoundField DataField="descripcion" HeaderText="descripcion" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="descripcion" />
            <asp:BoundField DataField="direccion" HeaderText="direccion" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="direccion" />
                <asp:BoundField DataField="telefono" HeaderText="telefono" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="telefono" />
            <asp:BoundField DataField="email" HeaderText="email" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="email" />
                 <asp:BoundField DataField="RIF" HeaderText="RIF" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="RIF" />
                
            
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="hfClienteID" Value='<%#Eval("clienteid")%>' runat="server" />
                   
                    
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView>
    </div>

  

</asp:Content>
 