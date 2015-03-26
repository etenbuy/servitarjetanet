<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CartaPorteUI.ascx.cs"
    Inherits="Web.ExtraControls.CartaPorteUI" %>
<table cellpadding="2" width="100%" style="border: 1px solid #009900">
    <tr style="background-color: #FFFF66">
        <td align="center" style="color: #072; font-weight: bold;">
            CARTA DE PORTES DE ENTRADA
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td style="font-weight: bold; color: #FF0000">
                        NRO:
                        <%=Nro %>
                    </td>
                    <td style="font-weight: bold; color: #009900;">
                        CHAPALETAS:
                        <%=Chapaletas %>
                    </td>
                    <td style="font-weight: bold; color: #009900;">
                        DEVUELTOS:
                        <%=EnvasesME %>
                    </td>
                    <td style="font-weight: bold; color: #009900;">
                        ENVASES:
                        <%=EnvasesTotal %>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="border-style: solid solid none solid; border-width: 1px; border-color: #009900;
                        font-size: 8px; color: #009900; padding-left: 4px;" width="70%">
                        NOMBRE Y DOMICILIO DEL CONSIGNADOR
                    </td>
                    <td style="border-style: solid solid none none; border-width: 1px; border-color: #009900;
                        font-size: 8px; color: #009900;" align="center">
                        FECHA DE ENTREGA
                    </td>
                </tr>
                <tr>
                    <td style="border-style: none solid solid solid; border-width: 1px; border-color: #009900;"
                        align="center">
                        <%=Consignador %>
                    </td>
                    <td style="border-style: solid solid solid none; border-width: 1px; border-color: #009900;"
                        align="center">
                        <%=ConsignadorFecha %>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="border-style: solid solid none solid; border-width: 1px; border-color: #009900;
                        font-size: 8px; color: #009900; padding-left: 4px;" width="70%">
                        NOMBRE Y DOMICILIO DEL CONSIGNATARIO
                    </td>
                    <td style="border-style: solid solid none none; border-width: 1px; border-color: #009900;
                        font-size: 8px; color: #009900; padding-left: 4px;" align="center">
                        FECHA DE ENTREGA
                    </td>
                </tr>
                <tr>
                    <td align="center" style="border-style: none solid solid solid; border-width: 1px;
                        border-color: #009900;">
                        <%=Consignatario %>
                    </td>
                    <td style="border-style: solid solid solid none; border-width: 1px; border-color: #009900;"
                        align="center">
                        <%=ConsignatarioFecha %>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="border-style: solid solid none solid; border-width: 1px; border-color: #009900;
                        font-size: 8px; color: #009900; padding-left: 4px;">
                        NRO PLOMOS
                    </td>
                    <td style="border-style: solid solid none solid; border-width: 1px; border-color: #009900;
                        font-size: 8px; color: #009900; padding-left: 4px;">
                        MONTO EN Bs
                    </td>
                </tr>
                <tr>
                    <td align="center" style="width: 50%; border-style: none solid solid solid; border-width: 1px;
                        border-color: #009900;">
                        <%=Plomos %>
                    </td>
                    <td align="center" style="border-style: none solid solid solid; border-width: 1px;
                        border-color: #009900; font-size: 16px; font-weight: bold;">
                        <%=Monto %>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
