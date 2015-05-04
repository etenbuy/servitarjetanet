<%@ Page Language="C#" MasterPageFile="~/Operaciones/Operaciones.master" AutoEventWireup="true"
    CodeBehind="CrearReferidos.aspx.cs" Inherits="Web.Operaciones.Clientes.CrearReferidos" Title="SERVITARJETA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent" runat="server">

   <h2>
        Crear Referidos</h2>
    <div>
    Agregue referidos , para que los contactemos y gane dividendos.
    <asp:Label ID="lblMensaje" ForeColor="#FE7000" runat="server" Text=""></asp:Label>
        <table class="Formulario" cellpadding="0" cellspacing="0">
           
            
            
            <tr>
                <th>
                    Nombre y Apellido:
                </th>
                <td colspan="2">
                    <asp:TextBox runat="server" ID="txtDescripcion"  AutoPostBack="false" 
                        Width="495px" />
                </td>
                 <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="Requerido!" runat="server"
                        ValidationGroup="Submit" ErrorMessage="Requerido!" ControlToValidate="txtDescripcion"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
             <tr>
                <th>
                    Dirección:
                </th>
                
                <td colspan="2">
                
                     <asp:TextBox runat="server" ID="txtDireccion"  AutoPostBack="false" Width="500" 
                         TextMode="MultiLine" Height="400px" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="Requerido!" runat="server"
                        ValidationGroup="Submit" ErrorMessage="Requerido!" ControlToValidate="txtDireccion"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <th>
                    Telefonos:
                </th>
                <td colspan="2">
                    <asp:TextBox runat="server" ID="txtTelefono"  AutoPostBack="false" 
                        Width="497px" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Requerido!" runat="server"
                        ValidationGroup="Submit" ErrorMessage="Requerido!" ControlToValidate="txtTelefono"></asp:RequiredFieldValidator>
                </td>
            </tr>
           
           <tr>
                <th>
                    Correo:
                </th>
                <td colspan="2">
                    <asp:TextBox runat="server" ID="txtCorreo"  AutoPostBack="false" Width="496px" />
                </td>
               
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="Requerido!" runat="server"
                        ValidationGroup="Submit" ErrorMessage="Requerido!" ControlToValidate="txtCorreo"></asp:RequiredFieldValidator>
                </td>
               
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button CssClass="buttons" ID="btnCrear" runat="server" Text="Guardar" OnClick="btnCrear_Click"
                        ValidationGroup="Submit" OnClientClick="if (!Page_ClientValidate('Submit')) return false; if (!confirm('¿Esta seguro de crear al referido?')) return false;" />
                    <asp:Button CssClass="buttons" ID="btnEliminar" runat="server" Visible="false" Text="Eliminar" OnClick="btnEliminar_Click"
                        OnClientClick="if (!Page_ClientValidate()) return false; if (!confirm('¿Esta seguro de eliminar este referido?')) return false;"
                        ValidationGroup="Submit" />
                </td>
            </tr>

        </table>
        
        <asp:GridView ID="gvReferidos" Width="100%" AllowSorting="true" OnSorting="gvReferido_Sorting"
                    CssClass="Formulario" runat="server" AutoGenerateColumns="false">
                    <RowStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:BoundField DataField="Descripcion" HeaderText="Nombre y Apellido" SortExpression="Descripcion"/>
                        <asp:BoundField DataField="Direccion" HeaderText="Dirección" SortExpression="Direccion"/>
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfonos" SortExpression="Telefono"/>
                       <asp:BoundField DataField="Email" HeaderText="Correo" SortExpression="Correo"/>
                        
                  <asp:TemplateField>
                
                </asp:TemplateField>        
                    </Columns>
                </asp:GridView>

    </div>

</asp:Content>
