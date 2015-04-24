<%@ Page Language="C#" MasterPageFile="~/Configuracion/Configuracion.master" AutoEventWireup="true"
    CodeBehind="EditarClave.aspx.cs" Inherits="Web.Configuracion.Usuarios.EditarClave" Title="SERVITARJETA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent" runat="server">
    <h2>
        Editar Usuario</h2>
    <table>
        <tr>
            <td valign="top">
                <asp:TreeView ID="trvUsuarios" ImageSet="Contacts" runat="server" OnSelectedNodeChanged="trvUsuarios_SelectedNodeChanged">
                </asp:TreeView>
            </td>
            <td>
                <%if (usuario != null)
                  { %>
                <table cellpadding="0" cellspacing="0" class="Formulario">
                    <tr>
                        <th>
                            Usuario:
                        </th>
                        <td>
                            <%=usuario.memUser.UserName.ToUpper() %>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Contraseña Actual:
                        </th>
                        <td>
                            <asp:TextBox ID="txtContrasena" Width="200px" TextMode="Password" runat="server"></asp:TextBox>
                        </td>
                        
                    </tr>
                    <tr>
                        <th>
                            Nueva Contraseña:
                        </th>
                        <td>
                            <asp:TextBox ID="txtNuevaContrasena" Width="200px" TextMode="Password" runat="server"></asp:TextBox>
                        </td>
                        
                    </tr>
                    <tr>
                        <th>
                            Confirme Contraseña:
                        </th>
                        <td>
                            <asp:TextBox ID="txtConfirmeContrasena" Width="200px" TextMode="Password" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:CompareValidator ID="CompareValidator1" ControlToCompare="txtNuevaContrasena" ControlToValidate="txtConfirmeContrasena"
                                runat="server" ErrorMessage="*"></asp:CompareValidator>
                        </td>
                    </tr>
                    
                    <tr>
                        <th align="right">
                            Primer Nombre:
                        </th>
                        <td>
                            <asp:TextBox ID="txtPrimerNombre" Width="200px" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            Segundo Nombre:
                        </th>
                        <td>
                            <asp:TextBox ID="txtSegundoNombre" Width="200px" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            Primer Apellido:
                        </th>
                        <td>
                            <asp:TextBox ID="txtPrimerApellido" Width="200px" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            Segundo Apellido:
                        </th>
                        <td>
                            <asp:TextBox ID="txtSegundoApellido" Width="200px" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            
                        </th>
                        <td>
                            <asp:CheckBoxList runat="server" ID="cblModulos">
                                
                            </asp:CheckBoxList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:CheckBox ID="cbActivarUsuario" Visible="false" runat="server" Text="Activo" Checked="true" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btnActualizar"  OnClick="btnActualizar_Click" Text="Actualizar" runat="server" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                <%} %>
            </td>
        </tr>
    </table>
</asp:Content>
