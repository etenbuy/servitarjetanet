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

namespace Web
{
    public partial class SiteMasterPage : System.Web.UI.MasterPage
    {

        public SiteMapPath SmPath
        {
            get
            {
                return this.smpModulo;

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);
            if (Request.IsAuthenticated)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect(ResolveUrl("~/Logout.aspx"));
                }

            }
            if (!IsPostBack)
            {
                BuildMenu();
            }
        }
        /// <summary>
        /// Gets the page render time.
        /// </summary>
        protected string PageRenderTime
        {
            get
            {
                // Be sure that all ContentPlaceHolder pages are derived from PageBase.
                // BTW: this is how you access content pages from a master page --
                // most developers ask about access the other way around, that is, access 
                // the master page from the content pages which is also demonstrated here 
                // with the above TheMenuInMasterPage property.
                try
                {
                    PageBase pageBase = this.ContentPlaceHolder1.Page as PageBase; //(this.FindControl("ContentPlaceHolder1") as ContentPlaceHolder).Page as PageBase;// 
                    return pageBase.PageRenderTime;
                }
                catch { /* do nothing */ }

                return string.Empty;
            }
        }

        private void BuildMenu()
        {

            if (Request.IsAuthenticated)
            {
                lbtnLoginLogout.Text =  ((MembershipUser)Session["usuario"]).UserName + ", (Cerrar sesión)";
                lbtnLoginLogout.PostBackUrl = ResolveUrl("~/Logout.aspx");

            }
            else
            {
                lbtnLoginLogout.Text = "Iniciar sesión";
                lbtnLoginLogout.PostBackUrl = ResolveUrl("~/Login.aspx");
            }
 
        }

    }
}
