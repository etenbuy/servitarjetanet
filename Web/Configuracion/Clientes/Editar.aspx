<%@ Page Language="C#" MasterPageFile="~/Configuracion/Configuracion.master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="Web.Configuracion.Clientes.Editar" Title="SERVITARJETA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent" runat="server">

 

    <h2>
        Editar Clientes</h2>
    <div>
    <asp:Label ID="lblMensaje" ForeColor="#FE7000" runat="server" Text=""></asp:Label>
    <div style="float:left">
        <table class="Formulario" cellpadding="0" cellspacing="0">
           
           <tr>
                <th>
                    ID:
                </th>
                <td colspan="2">
                    <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Enabled="false" Text="Requerido!" runat="server"
                        ValidationGroup="Submit" ErrorMessage="Requerido!" ControlToValidate="txtID"></asp:RequiredFieldValidator>
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
                    Dirección:
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
                    <asp:Button CssClass="buttons" ID="btnCrear" runat="server" Text="Guardar" OnClick="btnGuardar_Click"
                        ValidationGroup="Submit" OnClientClick="if (!Page_ClientValidate('Submit')) return false; if (!confirm('¿Esta seguro de crear este cliente?')) return false;" />
                    
                </td>
            </tr>
        </table>
        </div>
        <div style="float:right">
         <table class="Formulario" cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    Cliente ID:
                </th>
                <td colspan="2">
                    <asp:TextBox ID="txtClienteID" runat="server"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <th>
                    Numero de Tarjeta:
                </th>
                <td colspan="2">
                    <asp:TextBox ID="txtNumero" runat="server" MaxLength="39"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Text="Requerido!" runat="server"
                        ValidationGroup="Submit" ErrorMessage="Requerido!" ControlToValidate="txtNumero"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
            <tr>
               
                <td colspan="4">
                <asp:Button CssClass="buttons" ID="btnCrearTarjeta" runat="server" Text="Crear" OnClick="btnCrearTarjeta_Click"
                        ValidationGroup="Submit" OnClientClick="if (!Page_ClientValidate('Submit')) return false; if (!confirm('¿Esta seguro de crear esta tarjeta?')) return false;" />
                    
                </td>
            </tr>
        </table>
        </div>
         <div style="float:left">
        Cantidad :<asp:Label ID="lblTotalClientes" Text="0" runat="server"></asp:Label>    
        <asp:GridView ID="gvClientes" CellPadding="0" CellSpacing="0" CssClass="Formulario"
        AllowSorting="true" HeaderStyle-Wrap="false" runat="server" Font-Size="10px"
       OnSorting="gvClientes_Sorting" AutoGenerateColumns="false"  ShowFooter="true"
         ondatabound="gvClientes_DataBound">
        <RowStyle HorizontalAlign="Center" />
        <Columns>
            <asp:BoundField DataField="ClienteID" Visible="true" HeaderText="ClienteID" SortExpression="ClienteID"/>
            <asp:BoundField DataField="descripcion" HeaderText="descripcion" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="descripcion" />
                <asp:BoundField DataField="Email" Visible="true" HeaderText="Email"/>
         
                
            
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="hfClienteID" Value='<%#Eval("clienteid")%>' runat="server" />
                   <asp:LinkButton ID="lbtnEditar" Text="Editar" runat="server" OnClick="btnEditar_Click"></asp:LinkButton>
                    
                </ItemTemplate>
            </asp:TemplateField>
            
            </Columns>
        </asp:GridView>
        </div>
        
        <div style="float:right">
        Cantidad :<asp:Label ID="lblTarjetas" Text="0" runat="server"></asp:Label>    
        <asp:GridView ID="gvTarjetas" CellPadding="0" CellSpacing="0" CssClass="Formulario"
        AllowSorting="true" HeaderStyle-Wrap="false" runat="server" Font-Size="10px"
        AutoGenerateColumns="false"  ShowFooter="true">
        <RowStyle HorizontalAlign="Center" />
        <Columns>
            <asp:BoundField DataField="ClienteID" Visible="true" HeaderText="ClienteID" SortExpression="ClienteID"/>
            <asp:BoundField DataField="Numero" HeaderText="Numero" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" SortExpression="Numero" />
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="hfNumero" Value='<%#Eval("Numero")%>' runat="server" />
                   <asp:LinkButton ID="lbtnEditarTarjeta" Text="Editar" runat="server" OnClick="btnEditarTarjeta_Click"></asp:LinkButton>
                    
                </ItemTemplate>
            </asp:TemplateField>
            
            </Columns>
        </asp:GridView>
        </div>
        
        
        
    </div>
</asp:Content>
 