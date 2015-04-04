<%@ Page Language="C#" MasterPageFile="~/SiteMasterPage.Master" AutoEventWireup="true" CodeBehind="Disculpe.aspx.cs" Inherits="Web.Disculpe" Title="SERVITARJETA" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="Disculpe">
            
             <h1>Disculpe...</h1>          
    <div>
        <img src="Images/error.jpg" alt="Disculpe"/> 
            <div >
                <p>
                    La página que ha solicitado no se encuentra                     disponible en estos momentos, esto pudo ser 
                    ocasionado por problemas con su conexión a 
                    Internet.</p>
                 <p>
                    Por favor intente mas tarde.</p>
            </div>
    </div>
    <div class="Header">
         <a href='<%= ResolveUrl("~/Login.aspx") %>'>Si desea regresar a la página de inicio haga Click aqui</a>            
    </div>
</div>
</asp:Content>
