using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BusinessObjects;
using System.Text;
using System.Collections.Generic;
using Web.rssTransvalven;


namespace Web
{

    public class PageBase:Page
    {

        private string gvSortExp { get; set; }

        private SortDirection gvSortDir { get; set; }


        public MembershipUser UsuarioAutenticado
        {
            get
            {
                return (MembershipUser)Session["usuario"];

            }
        }
        public string[] UsuarioAutenticadoAccesos
        {
            get
            {
                return (string[])Session["usuario"];

            }
        }

        #region Page Render Timing

        // Page render performance fields.
        private DateTime startTime = DateTime.Now;
        private TimeSpan renderTime;

        /// <summary>
        /// Sets and gets the page render starting time. This property 
        /// represents the Template Design Pattern.
        /// </summary>
        public DateTime StartTime
        {
            set { startTime = value; }
            get { return startTime; }
        }

        /// <summary>
        /// Gets page render time. This property is virtual therefore getting the 
        /// page performance is overridable by derived pages. This property 
        /// represents the Template Design Pattern.
        /// </summary>
        public virtual string PageRenderTime
        {
            get
            {
                renderTime = DateTime.Now - startTime;
                return renderTime.Seconds + "." + renderTime.Milliseconds + " seconds";
            }
        }

        #endregion

        public string GetSortDirection(string column)
        {

            string sortDirection = "ASC";

            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {

                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }


            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }
      

        #region ViewState Provider Service Access

        // Random number generator 
        private static Random _random = new Random(Environment.TickCount);




        #endregion

        #region Javascript support

        /// <summary>
        /// Adds an 'Open Window' Javascript function to page.
        /// </summary>
        protected void RegisterOpenWindowJavaScript()
        {
            string script =
              "<script language='JavaScript' type='text/javascript'>" + "\r\n" +
               " <!--" + "\r\n" +
               " function openwindow(url,name,width,height) " + "\r\n" +
               " { " + "\r\n" +
               "   window.open(url,name,'toolbar=yes,location=yes,scrollbars=yes,status=yes,menubar=yes,resizable=yes,top=50,left=50,width='+width+',height=' + height) " + "\r\n" +
               " } " + "\r\n" +
               " //--> " + "\r\n" +
              "</script>" + "\r\n";

            ClientScript.RegisterClientScriptBlock(typeof(string), "OpenWindowScript", script);
        }

        public void Alert(string message)
        {

            StringBuilder script = new StringBuilder();

            script.Append("<script type = 'text/javascript'>");

            script.Append("alert('");

            script.Append(message.Replace(Environment.NewLine, @"\n"));

            script.Append("')");

            script.Append("</script>");

            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", script.ToString());
        }

        public void Alert(IList<string> messages)
        {
            string message = string.Empty;

            foreach (string error in messages)
            {
                message = message + error + @"\n";
            }

            StringBuilder script = new StringBuilder();

            script.Append("<script type = 'text/javascript'>");

            script.Append("alert('");

            script.Append(message);

            script.Append("')");

            script.Append("</script>");

            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", script.ToString());
        }

        public void Alert(string message, string newUri)
        {

            StringBuilder script = new StringBuilder();

            script.Append("<script type = 'text/javascript'>");

            script.Append("alert('");

            script.Append(message);

            script.Append("'), window.location.href='" + newUri + "';");

            script.Append("</script>");

            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", script.ToString());
        }

        #endregion
    }


}
