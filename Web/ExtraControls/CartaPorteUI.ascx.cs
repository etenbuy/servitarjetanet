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
using BusinessObjects;

namespace Web.ExtraControls
{
    public partial class CartaPorteUI : System.Web.UI.UserControl
    {
        public string Nro { get; set; }

        public string Consignador { get; set; }

        public string Consignatario { get; set; }

        public string ConsignadorFecha { get; set; }

        public string ConsignatarioFecha { get; set; }

        public string Plomos { get; set; }

        public string EnvasesME { get; set; }

        public string Chapaletas { get; set; }

        public string EnvasesTotal { get; set; }

        public string Monto { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }        

    }



}