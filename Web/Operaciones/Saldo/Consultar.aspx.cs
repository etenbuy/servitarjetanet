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
    public partial class Consultar : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!Page.IsPostBack)
            {
               
               
            }
        }

        protected void txtCalFechaDesde_SelectionChanged(object sender, EventArgs e)
        {
        

        }
        protected void txtCalFechaHasta_SelectionChanged(object sender, EventArgs e)
        {
          

        }

        protected void gvDividendos_Sorting(object sender, GridViewSortEventArgs e)
        {

          

        }

        protected void gvDividendos_DataBound(object sender, EventArgs e)
        {


        }

        protected void gvDividendos_RowDataBound(object sender, GridViewRowEventArgs e)
        {



          
        }

       
    }
}
