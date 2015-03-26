<%@ Page Language="C#" MasterPageFile="~/MetroCambio/MetroCambio.master" AutoEventWireup="true"
    CodeBehind="Reporte.aspx.cs" Inherits="Web.MetroCambio.Reportes.Reporte" Title="SERVITARJETA" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent" runat="server">
<script type="text/javascript">
    var texto = '<%= Pendientes %>';
    var longitud = texto.length;
    function scroll() {
        texto = texto.substring(1, longitud - 1) + texto.charAt(0);
        window.status = texto;
       
        setTimeout("scroll()", 150);
    }
</script>
    <asp:DropDownList ID="ddlReportes" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlReportes_SelectedIndexChanged">
    </asp:DropDownList>
    <div style="padding-bottom: 20px;">
        <rsweb:ReportViewer ID="rpvReportes" Visible="false" Width="100%" ShowPrintButton="false"
            runat="server">
        </rsweb:ReportViewer>
    </div>
</asp:Content>
