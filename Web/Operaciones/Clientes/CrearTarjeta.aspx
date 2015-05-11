<%@ Page Language="C#" MasterPageFile="~/Operaciones/Operaciones.master" AutoEventWireup="true"
    CodeBehind="CrearTarjeta.aspx.cs" Inherits="Web.Operaciones.Clientes.CrearTarjeta" Title="SERVITARJETA" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent" runat="server">
  <div align="center">  
    <div>
        <asp:Label ID="lblTarjeta" runat="server" Font-Size="Large" Text="Numero de Tarjeta que desea Afiliar" ForeColor="#134e9d"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="txtTarjeta" runat="server" Width="280px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnEnviar" CssClass="buttons" OnClick="btnEnviar_Click" runat="server" Text="ENVIAR" />
	</div>

</asp:Content>

