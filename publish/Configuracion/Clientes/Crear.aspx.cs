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

namespace Web.Configuracion.Clientes
{
    public partial class Crear : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!Page.IsPostBack)
            {
                BindGrids();
               
            }
        }
        protected void BindGrids()
        {
            Controllers.ClienteController controller = new Controllers.ClienteController();

            IList<Cliente> clientes = controller.Clientes_GET();
           
            gvClientes.DataSource = clientes;
            gvClientes.DataBind();

            lblTotalClientes.Text = gvClientes.Rows.Count.ToString();



        }
        protected void gvClientes_DataBound(object sender, EventArgs e)
        {


        }
        protected void gvClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvClientes_Sorting(object sender, GridViewSortEventArgs e)
        {

            DataTable dt = Session["DSClientes"] as DataTable;

            if (dt != null)
            {
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                gvClientes.DataSource = Session["DSClientes"];
                gvClientes.DataBind();

            }

        }
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Controllers.ClienteController controller = new Controllers.ClienteController();

            Cliente cliente = new Cliente();
            
            cliente.Descripcion = txtNombre.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.Direccion = txtDireccion.Text;
            cliente.Email = txtMail.Text;
            cliente.RIF = txtRif.Text;
            Controllers.ControllerResult result = controller.CrearCliente(cliente,UsuarioAutenticado.UserName);

            if (result.Resultado == Controllers.Result.Successful)

                txtNombre.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtMail.Text = string.Empty;
                txtRif.Text = string.Empty;
                txtTelefono.Text = string.Empty;
                BindGrids();
            Alert(result.Mensaje);
            
        }

       
    }
}
