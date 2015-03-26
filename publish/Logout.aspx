<%@ Page Language="C#" MasterPageFile="~/SiteMasterPage.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="Web.Logout" Title="Cerrar sesión" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Cerrar sesión</h1>

    <p>Ha cerrado la sesión satisfactoriamente.</p> 

    <br />
    
     <ul>
     <li><asp:HyperLink ID="HyperLinkHome" runat="server" NavigateUrl="~/Inicio.aspx" Text="Click aqui"></asp:HyperLink> para regresar al inicio</li>
    </ul>
</asp:Content>
