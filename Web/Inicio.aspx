<%@ Page Language="C#" MasterPageFile="~/SiteMasterPage.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Web.Inicio" Title="Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--<script type= "text/javascript">
//open a new window
window.open("Inicio2.aspx", "_blank",
  "menubar=no;status=1;toolbar=no,resizable=1");
//close the parent window
Close();
// close the window without any prompt
function Close()
{
  
  var ie = navigator.appName == "Microsoft Internet Explorer" ? true : false;
  if (ie)
  {
  
   
      window.close();
  }
}
 
</script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

</asp:Content>
