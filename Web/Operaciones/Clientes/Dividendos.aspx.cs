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
using Web.rssTransvalven;

namespace Web.Operaciones.Clientes
{
    public partial class Dividendos : PageBase
    {

        decimal monto = 0;
        decimal dividendo = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            BuildDividendos();
        }

      

       

      
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            

        

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

           
        }
        protected void gvDividendos_DataBound(object sender, EventArgs e)
        {


        }

        protected void gvDividendos_RowDataBound(object sender, GridViewRowEventArgs e)
        {

           

            if (e.Row.RowType == DataControlRowType.DataRow)
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
        }

        protected void gvDividendos_Sorting(object sender, GridViewSortEventArgs e)
        {

            //DataTable dt = Session["DSBolsas"] as DataTable;

            //if (dt != null)
            //{
            //    dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            //    gvBolsas.DataSource = Session["DSBolsas"];
            //    gvBolsas.DataBind();

            //}

        }

        private void BuildDividendos()
        {
            Controllers.DividendoController controller = new Controllers.DividendoController();

            gvDividendos.DataSource = controller.Dividendos_Get_ByClient(1);
            gvDividendos.DataBind();

            
        }

    }
}
