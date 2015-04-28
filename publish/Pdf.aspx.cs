using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Configuration;

namespace Web
{
    public partial class Pdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Clear();
            HttpWebRequest request = null;

            //solicitud

            if (Request.QueryString["tipo"].ToString() == "solicitud" && Request.QueryString["boveda"].ToString() == "acopio")

                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fAcopio%2fsolicitud&rs:Format=pdf&rs:Command=Render&SolicitudID=" + Request.QueryString["SolicitudID"].ToString() + "");

            //traspasos

            if (Request.QueryString["tipo"].ToString() == "traspasocartaporteA")

                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fImprimibles%2fTraspasoCartaporteA&rs:Format=pdf&rs:Command=Render&TraspasoID=" + Request.QueryString["TraspasoID"].ToString() + "");
           
            if (Request.QueryString["tipo"].ToString() == "traspasocartaporte")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fImprimibles%2fTraspasoCartaporte&rs:Format=pdf&rs:Command=Render&TraspasoID=" + Request.QueryString["TraspasoID"].ToString() + "");


            if (Request.QueryString["tipo"].ToString() == "traspasoefectivocaja")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fImprimibles%2fTraspasoEfectivoCaja&rs:Format=pdf&rs:Command=Render&TraspasoID=" + Request.QueryString["TraspasoID"].ToString() + "");
                
            if (Request.QueryString["tipo"].ToString() == "traspasoefectivo")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fImprimibles%2fTraspasoEfectivo&rs:Format=pdf&rs:Command=Render&TraspasoID=" + Request.QueryString["TraspasoID"].ToString() + "");

            if (Request.QueryString["tipo"].ToString() == "traspasoinventario")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fImprimibles%2fTraspasoInventario&rs:Format=pdf&rs:Command=Render&TraspasoID=" + Request.QueryString["TraspasoID"].ToString() + "");

            if (Request.QueryString["tipo"].ToString() == "traspasobolsa")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fImprimibles%2fTraspasoBolsa&rs:Format=pdf&rs:Command=Render&TraspasoID=" + Request.QueryString["TraspasoID"].ToString() + "");
          
            //hojas de cierre
            if (Request.QueryString["tipo"].ToString() == "hojacajero" && Request.QueryString["boveda"].ToString() == "vabt")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fVabt%2fHojaCajero&rs:Format=pdf&rs:Command=Render&Fecha=" + Request.QueryString["Fecha"].ToString() + "");

            if (Request.QueryString["tipo"].ToString() == "hojacajero" && Request.QueryString["boveda"].ToString() == "metrocambio")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fMetrocambio%2fHojaCajero&rs:Format=pdf&rs:Command=Render&Fecha=" + Request.QueryString["Fecha"].ToString() + "");

            if (Request.QueryString["tipo"].ToString() == "hojacajero" && Request.QueryString["boveda"].ToString() == "entubado")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fEntubado%2fHojaCajero&rs:Format=pdf&rs:Command=Render&Fecha=" + Request.QueryString["Fecha"].ToString() + "");

            if (Request.QueryString["tipo"].ToString() == "hojacajero" && Request.QueryString["boveda"].ToString() == "anteboveda")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fAnteboveda%2fHojaCajero&rs:Format=pdf&rs:Command=Render&Fecha=" + Request.QueryString["Fecha"].ToString() + "");

            if (Request.QueryString["tipo"].ToString() == "hojacajero" && Request.QueryString["boveda"].ToString() == "boveda")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fboveda%2fHojaCajero&rs:Format=pdf&rs:Command=Render&Fecha=" + Request.QueryString["Fecha"].ToString() + "");

            if (Request.QueryString["tipo"].ToString() == "hojacajero" && Request.QueryString["boveda"].ToString() == "anillo")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fAnillo%2fHojaCajero&rs:Format=pdf&rs:Command=Render&Fecha=" + Request.QueryString["Fecha"].ToString() + "");

            if (Request.QueryString["tipo"].ToString() == "hojacajero" && Request.QueryString["boveda"].ToString() == "control")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fControl%2fHojaCajero&rs:Format=pdf&rs:Command=Render&Fecha=" + Request.QueryString["Fecha"].ToString() + "");

            if (Request.QueryString["tipo"].ToString() == "hojacajero" && Request.QueryString["boveda"].ToString() == "acopio")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fAcopio%2fHojaCajero&rs:Format=pdf&rs:Command=Render&Fecha=" + Request.QueryString["Fecha"].ToString() + "");

             
            //acta

            if (Request.QueryString["tipo"].ToString() == "ActaAjustes" && Request.QueryString["boveda"].ToString() == "control")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fControl%2fActaAjustes&rs:Format=pdf&rs:Command=Render&ActaID=" + Request.QueryString["ActaID"].ToString() + "");

            //efectivo caja

            if (Request.QueryString["tipo"].ToString() == "TraspasoEfectivoCaja")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fIMPRIMIBLES%2fTraspasoEfectivoCaja&rs:Format=pdf&rs:Command=Render&TraspasoID=" + Request.QueryString["TraspasoID"].ToString() + "");
                
            ////bloques
            if (Request.QueryString["tipo"].ToString() == "bloques")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fIMPRIMIBLES%2fBloques&rs:Format=pdf&rs:Command=Render" + Request.QueryString["bloques"].ToString() + "");

                
            //cartaportes biblia
            if (Request.QueryString["tipo"].ToString() == "cartaporteMC")

                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fImprimibles%2fCartaporteMC&rs:Format=pdf&rs:Command=Render" + Request.QueryString["cartaportes"].ToString() + "");

            //cartaportes crear
            if (Request.QueryString["tipo"].ToString() == "cartaporte" && Request.QueryString["boveda"].ToString() == "acopio")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fAcopio%2fCartaPorteACOPIO&rs:Format=pdf&rs:Command=Render&CartaPorteID=" + Request.QueryString["CartaporteID"].ToString() + "");

            if (Request.QueryString["tipo"].ToString() == "cartaporte" && Request.QueryString["boveda"].ToString() == "acopioE")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fAcopio%2fCartaPorteACOPIOE&rs:Format=pdf&rs:Command=Render&CartaPorteID=" + Request.QueryString["CartaporteID"].ToString() + "");

            //anillo
            if (Request.QueryString["tipo"].ToString() == "cartaporte" && Request.QueryString["boveda"].ToString() == "anillo")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fAnillo%2fCartaPorteANILLO&rs:Format=pdf&rs:Command=Render&CartaPorteID=" + Request.QueryString["CartaporteID"].ToString() + "");
            //bcv
            if (Request.QueryString["tipo"].ToString() == "cartaporteBCV" && Request.QueryString["boveda"].ToString() == "metrocambio")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fIMPRIMIBLES%2fCartaPorteBCV&rs:Format=pdf&rs:Command=Render&CartaPorteID=" + Request.QueryString["CartaporteID"].ToString() + "");
            //metro adicional
            if (Request.QueryString["tipo"].ToString() == "cartaporteMCA" && Request.QueryString["boveda"].ToString() == "metrocambio")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fIMPRIMIBLES%2fCartaPorteMCA&rs:Format=pdf&rs:Command=Render&CartaPorteID=" + Request.QueryString["CartaporteID"].ToString() + "");
            //Vabt
            if (Request.QueryString["tipo"].ToString() == "cartaporte" && Request.QueryString["boveda"].ToString() == "vabt")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fVabt%2fCartaPorteVabt&rs:Format=pdf&rs:Command=Render&CartaPorteID=" + Request.QueryString["CartaporteID"].ToString() + "");

            //despachar ruta
            if (Request.QueryString["tipo"].ToString() == "hojaruta" && Request.QueryString["boveda"].ToString() == "MLTe")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fAnteboveda%2fHojaRutaLosTeques&rs:Format=pdf&rs:Command=Render&RutaID=" + Request.QueryString["RutaID"].ToString() + "");
            if (Request.QueryString["tipo"].ToString() == "hojaruta" && Request.QueryString["boveda"].ToString() == "MLTeM")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fAnteboveda%2fHojaRutaLosTequesM&rs:Format=pdf&rs:Command=Render&RutaID=" + Request.QueryString["RutaID"].ToString() + "");
            if (Request.QueryString["tipo"].ToString() == "hojaruta" && Request.QueryString["boveda"].ToString() == "vab")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fAnteboveda%2fHojaRutaVAB&rs:Format=pdf&rs:Command=Render&RutaID=" + Request.QueryString["RutaID"].ToString() + "");
            if (Request.QueryString["tipo"].ToString() == "hojaruta" && Request.QueryString["boveda"].ToString() == "vabt")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fAnteboveda%2fHojaRutaVABT&rs:Format=pdf&rs:Command=Render&RutaID=" + Request.QueryString["RutaID"].ToString() + "");
            if (Request.QueryString["tipo"].ToString() == "hojaruta" && Request.QueryString["boveda"].ToString() == "metrocambio")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fAnteboveda%2fHojaRutaMC&rs:Format=pdf&rs:Command=Render&RutaID=" + Request.QueryString["RutaID"].ToString() + "");
            if (Request.QueryString["tipo"].ToString() == "hojaruta" && Request.QueryString["boveda"].ToString() == "metrocable")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fAnteboveda%2fHojaRutaAPOYO&rs:Format=pdf&rs:Command=Render&RutaID=" + Request.QueryString["RutaID"].ToString() + "");
            if (Request.QueryString["tipo"].ToString() == "hojaruta" && Request.QueryString["boveda"].ToString() == "banco")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fAnteboveda%2fHojaRutaBANCO&rs:Format=pdf&rs:Command=Render&RutaID=" + Request.QueryString["RutaID"].ToString() + "");
            if (Request.QueryString["tipo"].ToString() == "hojaruta" && Request.QueryString["boveda"].ToString() == "comercial")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fAnteboveda%2fHojaRutaCOMERCIAL&rs:Format=pdf&rs:Command=Render&RutaID=" + Request.QueryString["RutaID"].ToString() + "");
            if (Request.QueryString["tipo"].ToString() == "hojaruta" && Request.QueryString["boveda"].ToString() == "cartera")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fAnteboveda%2fHojaRutaCARTERA&rs:Format=pdf&rs:Command=Render&RutaID=" + Request.QueryString["RutaID"].ToString() + "");

            

            //depositos
            if (Request.QueryString["tipo"].ToString() == "deposito")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fBoveda%2fDeposito&rs:Format=pdf&rs:Command=Render&DepositoID=" + Request.QueryString["DepositoID"].ToString() + "");

            //acta diferencia
            if (Request.QueryString["tipo"].ToString() == "acta" && Request.QueryString["boveda"].ToString() == "acopio")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fIMPRIMIBLES%2fActaAcopio&rs:Format=pdf&rs:Command=Render&DiferenciaID=" + Request.QueryString["DiferenciaID"].ToString() + "&Cajero=" + Request.QueryString["Cajero"].ToString() + "&Cubiculo=" + Request.QueryString["Cubiculo"].ToString() + "");
            if (Request.QueryString["tipo"].ToString() == "acta" && Request.QueryString["boveda"].ToString() == "entubado")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fENTUBADO%2fActa&rs:Format=pdf&rs:Command=Render&DiferenciaID=" + Request.QueryString["DiferenciaID"].ToString() + "&Cajero=" + Request.QueryString["Cajero"].ToString() + "&Cubiculo=" + Request.QueryString["Cubiculo"].ToString() + "");
            if (Request.QueryString["tipo"].ToString() == "acta" && Request.QueryString["boveda"].ToString() == "metrocambio")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fIMPRIMIBLES%2fActa3&rs:Format=pdf&rs:Command=Render&DiferenciaID=" + Request.QueryString["DiferenciaID"].ToString() + "&Cajero=" + Request.QueryString["Cajero"].ToString() + "&Cubiculo=" + Request.QueryString["Cubiculo"].ToString() + "");
            if (Request.QueryString["tipo"].ToString() == "acta" && Request.QueryString["boveda"].ToString() == "vabt")
                request = (HttpWebRequest)WebRequest.Create("http://CCSSQL:80/reportserver?%2fIMPRIMIBLES%2fActaAcopio&rs:Format=pdf&rs:Command=Render&DiferenciaID=" + Request.QueryString["DiferenciaID"].ToString() + "&Cajero=" + Request.QueryString["Cajero"].ToString() + "&Cubiculo=" + Request.QueryString["Cubiculo"].ToString() + "");




            
             
            request.Credentials = new System.Net.NetworkCredential(ConfigurationSettings.AppSettings["ReportServerUser"], ConfigurationSettings.AppSettings["ReportServerPass"]);
            System.IO.Stream stream = ((HttpWebResponse)request.GetResponse()).GetResponseStream();
            Response.ContentType = "application/pdf";
            int buffer = 2048;
            byte[] data = new byte[buffer];
            for (int count = stream.Read(data, 0, buffer);count >0 ; count = stream.Read(data, 0, buffer))
            {
                Response.OutputStream.Write(data, 0, count);

            }
            Response.End();


        }
    }
}
