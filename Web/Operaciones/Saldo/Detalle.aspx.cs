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
using BusinessObjects;
using System.Collections.Generic;

namespace Web.Operaciones.Saldo
{
    public partial class Detalle : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!Page.IsPostBack)
            {

                BuildSolicitudes();
            }
        }

        private void BuildSolicitudes()
        {
            Controllers.SolicitudController controller = new Controllers.SolicitudController();

            dtvDetalle.DataSource = controller.Solicitudes_Get_ByID(Request.QueryString.Get("ID").ToString());
            dtvDetalle.DataBind();

            dtvDetalle2.DataSource = controller.Solicitudes_Get_ByID(Request.QueryString.Get("ID").ToString());
            dtvDetalle2.DataBind();
        }

        protected void txtCalFechaDesde_SelectionChanged(object sender, EventArgs e)
        {
        

        }
        protected void txtCalFechaHasta_SelectionChanged(object sender, EventArgs e)
        {
          

        }

        protected void gvSolicitudes_Sorting(object sender, GridViewSortEventArgs e)
        {

          

        }

        protected void gvSolicitudes_DataBound(object sender, EventArgs e)
        {

         /*   if (e.Row.RowType == DataControlRowType.DataRow)
            {
                monto += string.IsNullOrEmpty(((HiddenField)e.Row.FindControl("hfMonto")).Value.ToString()) ? 0 : decimal.Parse(((HiddenField)e.Row.FindControl("hfMonto")).Value.ToString());
                dividendo += string.IsNullOrEmpty(((HiddenField)e.Row.FindControl("hfDividendo")).Value.ToString()) ? 0 : decimal.Parse(((HiddenField)e.Row.FindControl("hfDividendo")).Value.ToString());

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                //e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;

                e.Row.Cells[4].Text = monto.ToString("###,###,###,###.00");
                e.Row.Cells[5].Text = dividendo.ToString("###,###,###,###.00");

                e.Row.Font.Bold = true;
            }
            */
        }

        protected void gvSolicitudes_RowDataBound(object sender, GridViewRowEventArgs e)
        {



          
        }

       
    }
}
