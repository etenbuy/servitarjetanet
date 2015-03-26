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

namespace Web.Configuracion.Dividendos
{
    public partial class Crear : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!Page.IsPostBack)
            {
                BindGrids();
                BuildClientes();
               
            }
        }
        protected void BindGrids()
        {
            Controllers.DividendoController controller = new Controllers.DividendoController();

            IList<Dividendo> dividendos = controller.Dividendos_Get();

            gvDividendos.DataSource = dividendos;
            gvDividendos.DataBind();

            lblTotalDividendos.Text = gvDividendos.Rows.Count.ToString();



        }
        protected void gvDividendos_DataBound(object sender, EventArgs e)
        {


        }
        protected void gvDividendos_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvDividendos_Sorting(object sender, GridViewSortEventArgs e)
        {

            DataTable dt = Session["DSDividendos"] as DataTable;

            if (dt != null)
            {
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                gvDividendos.DataSource = Session["DSDividendos"];
                gvDividendos.DataBind();

            }

        }

        private void BuildClientes()
        {
            Controllers.ClienteController controller = new Controllers.ClienteController();

            IList<int> clientes = new List<int>();

            clientes = controller.GetClientesID();


            ddlCliente.DataSource = controller.GetClientes(clientes);

            ddlCliente.DataTextField = "Descripcion";

            ddlCliente.DataValueField = "ClienteID";

            ddlCliente.DataBind();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Controllers.DividendoController controller = new Controllers.DividendoController();

            Dividendo dividendo = new Dividendo();

            dividendo.Fecha = Convert.ToDateTime(string.Format("{0:dd/MM/yyyy}", txtFecha.Text));
            dividendo.Dividendo_Obtenido = decimal.Parse(txtDividendo.Text);
            dividendo.Monto = decimal.Parse(txtMonto.Text);           
            dividendo.Tdc = txtTdc.Text;
            dividendo.ClienteID = int.Parse(ddlCliente.SelectedValue);
            Controllers.ControllerResult result = controller.CrearDividendo(dividendo,UsuarioAutenticado.UserName);

            if (result.Resultado == Controllers.Result.Successful)

                txtFecha.Text = string.Empty;
            txtDividendo.Text = string.Empty;
            txtMonto.Text = string.Empty;
            txtTdc.Text = string.Empty;
                BindGrids();
            Alert(result.Mensaje);
            
        }

       
    }
}
