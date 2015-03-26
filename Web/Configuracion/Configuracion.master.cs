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

namespace Web.Configuracion
{
    public partial class Configuracion : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SiteMapPath)Master.FindControl("smpModulo")).SiteMapProvider = "Configuracion";

            ((AjaxControlToolkit.Accordion)Master.FindControl("accMenu")).SelectedIndex = 0;

        }
    }
}
