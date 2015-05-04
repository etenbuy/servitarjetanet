<%@ Page Language="C#" MasterPageFile="~/Configuracion/Configuracion.master" AutoEventWireup="true"
    CodeBehind="Editar.aspx.cs" Inherits="Web.Configuracion.Usuarios.Editar" Title="SERVITARJETA" %>

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
                            Contraseña:
                        </th>
                        <td>
                            <asp:TextBox ID="txtContrasena" Width="200px" TextMode="Password" runat="server"></asp:TextBox>
                        </td>
                        <td>
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
                            <asp:CompareValidator ID="CompareValidator1" ControlToCompare="txtContrasena" ControlToValidate="txtConfirmeContrasena"
                                runat="server" ErrorMessage="*"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            Email:
                        </th>
                        <td>
                            <asp:TextBox ID="txtEmail" Width="200px" Text="<%=((BusinessObjects.Usuario)usuario).memUser.Email.ToLower()%>"
                                runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
                                runat="server" ControlToValidate="txtEmail" ErrorMessage="*"></asp:RegularExpressionValidator>
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
                            Modulos:
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
                            <asp:CheckBox ID="cbActivarUsuario" runat="server" Text="Activo" Checked="true" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button CssClass="buttons" ID="btnActualizar"  OnClick="btnActualizar_Click" Text="Actualizar" runat="server" />
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
