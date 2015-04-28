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
    public partial class EditarClientes : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                BindGrids();
                rbtnActivo.SelectedValue = "1";
            }
        }

        public Cuenta Cliente
        {
            get
            {
                return Session["Cuenta"] as Cuenta;
            }
            set
            {
                Session["Cuenta"] = value;
            }
        }

        public IList<Cuenta> Clientes
        {
            get
            {
                IList<Cuenta> cuenta = new List<Cuenta>();
                return Session["Cuentas"] as IList<Cuenta>;


            }
            set
            {
                Session["Cuenta"] = value;

            }
        }
        protected void BindGrids()
        {
            Controllers.CuentaController controller = new Controllers.CuentaController();

            IList<Cuenta> cuentas = controller.GetCuentas();
            DataTable dtCuentas = CollectionHelper.ConvertTo<Cuenta>(controller.GetCuentasAll());
            gvClientes.DataSource = cuentas;
            gvClientes.DataBind();


            Session["DSClientes"] = dtCuentas;

            gvClientes.DataSource = Session["DSClientes"];

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

        private void Buscar(int cuentaid)
        {
            Cliente = null;

            lblMensaje.Visible = false;

            Controllers.CuentaController controller = new Controllers.CuentaController();

            Cliente = controller.GetCuenta(cuentaid);

            if (Cliente == null)
            {

                lblMensaje.Text = "No se econtraro ningun cliente con este nombre que contenga datos";
                lblMensaje.Visible = true;
                return;
            }

            txtID.Text = Convert.ToString(Cliente.CuentaID);
            txtNombre.Text = Cliente.Nombre;
            txtNumero.Text = Cliente.Numero;
            txtRif.Text = Cliente.co_cli;
            if (Cliente.Activo == 1)
            {
                rbtnActivo.SelectedValue = "0";
            }
            else
            {
                rbtnActivo.SelectedValue = "1";
            }
            BindGrids();

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Buscar(int.Parse(((HiddenField)((LinkButton)sender).FindControl("hfCuentaID")).Value.ToString()));

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Controllers.CuentaController controller = new Controllers.CuentaController();

            Cuenta cuenta = new Cuenta();
            cuenta.Nombre = txtNombre.Text;
            cuenta.co_cli = txtRif.Text;
            cuenta.Numero = txtNumero.Text;
            cuenta.Activo = int.Parse(rbtnActivo.SelectedValue);
            cuenta.CuentaID = int.Parse(txtID.Text);

            Controllers.ControllerResult result = controller.Cuenta_UPDATE(cuenta, UsuarioAutenticado.UserName);

            if (result.Resultado == Controllers.Result.Successful)
                txtNombre.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtRif.Text = string.Empty;

            Alert(result.Mensaje);
            BindGrids();
        }
    }
}
