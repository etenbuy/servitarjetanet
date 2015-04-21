using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Web.Development
{
    public partial class Development : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               

                
            }

            ((SiteMapPath)Master.FindControl("smpModulo")).SiteMapProvider = "Operaciones";

            ((AjaxControlToolkit.Accordion)Master.FindControl("accMenu")).SelectedIndex = 6;

        }
    }
}
