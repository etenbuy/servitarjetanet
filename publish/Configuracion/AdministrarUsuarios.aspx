<%@ Page Language="C#" MasterPageFile="~/SiteMasterPage.Master" AutoEventWireup="true" CodeBehind="AdministrarUsuarios.aspx.cs" Inherits="Web.Configuracion.AdministrarUsuarios" Title="Administracion de usuarios" %>

    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Crear Usuario</h2>
    <table class="TablaGeneral2" width="100%" cellpadding="0" cellpadding="0">
        <tr>
            <th>
                Crear usuario
            </th>
            <th>
                Modulos
            </th>
        </tr>
        <tr>
            <td style="border-right: solid 1px #99ff99; border-bottom: solid 1px #99ff99; border-left: solid 1px #99ff99;"
                align="center">
                Datos de la cuenta nueva
                <table>
                    <tr>
                        <td align="right">
                            Usuario:
                        </td>
                        <td>
                            <asp:TextBox ID="txtUsuario" Width="150px" MaxLength="30" runat="server"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Contraseña:
                        </td>
                        <td>
                            <asp:TextBox ID="txtContrasena" Width="150px" TextMode="Password" runat="server"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Confirme Contraseña:
                        </td>
                        <td>
                            <asp:TextBox ID="txtConfirmeContrasena" Width="150px" TextMode="Password" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:CompareValidator ID="CompareValidator1" ControlToCompare="txtContrasena" ControlToValidate="txtConfirmeContrasena"
                                runat="server" ErrorMessage="*"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Email:
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" Width="150px" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
                                runat="server" ControlToValidate="txtEmail" ErrorMessage="*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <asp:Button CssClass="buttons" ID="btnCrearUsuario" OnClick="btnCrearUsuario_Click" Text="Crear usuario"
                                runat="server" />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:CheckBox ID="cbActivarUsuario" runat="server" Text="Activar usuario" Checked="true" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="border-right: solid 1px #99ff99; border-bottom: solid 1px #99ff99; border-left: solid 1px #99ff99;"
                align="center">
                Seleccione los modulos
                <table>
                    <tr>
                        <td align="left">
                            <asp:CheckBoxList runat="server" ID="cblModulos">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
    <h2>
        Administrar Usuarios</h2>
    <table width="100%" style="border: solid 1px #00cc00; margin-top: 10px;">
        <tr>
            <td valign="top" style="padding: 0; margin: 0; border: 0; width: 67%;">
                <asp:GridView ID="gvUsuarios" CssClass="GridGeneral" AlternatingRowStyle-CssClass="AlternatingRowStyle"
                    GridLines="None" AutoGenerateColumns="false" runat="server" 
                    OnRowDeleting="gvUsuarios_RowDeleting" OnRowCreated="gvUsuarios_RowCreated">
                    <Columns>
                        <asp:TemplateField HeaderText="Activo" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbActivo" OnCheckedChanged="cbActivo_CheckedChanged" AutoPostBack="true"
                                    Checked='<%# Eval("IsApproved") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="UserName" HeaderStyle-HorizontalAlign="Left" HeaderText="Usuario"
                            HeaderStyle-Width="30%" />
                        <asp:TemplateField HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtModulos" runat="server" OnClick="lbtModulos_Click" Text="Modulos"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                 
                        <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="true" HeaderStyle-Width="10%" />
                    </Columns>
                </asp:GridView>
            </td>
            <td valign="top" style="padding: 0; margin: 0; border: 0; width: 33%;">
                <table width="100%" cellpadding="0" cellspacing="0" border="0" style="float: left;"
                    class="GridGeneral">
                    <tr>
                        <th style="padding-top: 1px; padding-bottom: 1px;">
                            Modulos
                        </th>
                    </tr>
                    
                    <tr>
                        <td>
                            Asignar a "
                            <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                        " a los modulos:</td></tr>
                    <tr>
                        <td>
                            <asp:CheckBoxList runat="server" ID="cblModulosUsuario">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button CssClass="buttons" ID="btnActualizarModulos" runat="server" Text="Actualizar" 
                                Visible="false" onclick="btnActualizarModulos_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
</table>

</asp:Content>
