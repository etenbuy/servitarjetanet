<%@ Page Language="C#" MasterPageFile="~/Operaciones/Operaciones.master" AutoEventWireup="true"
    CodeBehind="EstadosCuentas.aspx.cs" Inherits="Web.Operaciones.Clientes.EstadosCuentas" Title="SERVITARJETA" %>

<%@ Register Src="~/ExtraControls/CartaPorteUI.ascx" TagName="CartaPorteUI" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent" runat="server">
    
    <div>

		<br />
		<br />
		<asp:Label ID="Label4" runat="server" Text="MENSAJE :"></asp:Label>
		<br />
		<asp:TextBox ID="message_txt" runat="server" Height="117px"
		TextMode="MultiLine" Width="339px"></asp:TextBox>
		<br />
		<br />
		<asp:Label ID="Label5" runat="server" Text="CARGUE ESTADO DE CUENTA"></asp:Label>
		&nbsp;&nbsp;
		<asp:FileUpload ID="FileUpload1" runat="server" />
		<br />
		<br />
		<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="ENVIAR"
		Width="123px" />
		<br />
		<br />
		<asp:Label ID="Label1" runat="server" Text="Label" visible="false" ForeColor="#36C919"></asp:Label>
	</div>

</asp:Content>

