using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using Web.rssTransvalven;
using Microsoft.Reporting.WebForms;


namespace Web.MetroCambio.Reportes
{
    public partial class Reporte : System.Web.UI.Page
    {
        public string Pendientes
        {
            get
            {
                //string pendientes = string();
                return Session["Pendientes"] as string;


            }
            set
            {
                Session["Pendientes"] = value;

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

           // Controllers.BovedaController tareas = new Controllers.BovedaController();
            Pendientes = string.Empty;
            //Pendientes = tareas.GetBovedaTareasPendientes(4);
            

            if (!IsPostBack)
            {
                ReportingService2005 service = new ReportingService2005();
                service.Timeout = 10000;
                service.Url = ConfigurationSettings.AppSettings["ReportServerWebService"];
                service.Credentials = new System.Net.NetworkCredential(ConfigurationSettings.AppSettings["ReportServerUser"], ConfigurationSettings.AppSettings["ReportServerPass"]);
                CatalogItem[] items = service.ListChildren("/MetroCambio", false);

                ddlReportes.Items.Add("Seleccione un Reporte");
                foreach (CatalogItem item in items)
                {
                    ddlReportes.Items.Add(item.Name);

                }
            }

        }
        protected void ddlReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlReportes.SelectedIndex == 0)
            {
                this.rpvReportes.Visible = false;
            }
            else
            {
                rpvReportes.ProcessingMode = ProcessingMode.Remote;

                rpvReportes.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings.Get("ReportServerUrl"));

                rpvReportes.ServerReport.ReportPath = "/MetroCambio/" + ddlReportes.SelectedValue;


                rpvReportes.ServerReport.Refresh();

                rpvReportes.Visible = true;
            }
        }


    }
}
