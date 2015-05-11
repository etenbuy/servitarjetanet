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
    public partial class Editar : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!Page.IsPostBack)
            {
                BindGrids();
           
            }
        }

        public Cliente Cliente
        {
            get
            {
                return Session["Cliente"] as Cliente;
            }
            set
            {
                Session["Cliente"] = value;
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
            Controllers.ClienteController controller = new Controllers.ClienteController();

            IList<Cliente> clientes = controller.Clientes_GET();

            gvClientes.DataSource = clientes;
            gvClientes.DataBind();

            lblTotalClientes.Text = gvClientes.Rows.Count.ToString();




        }

        protected void BindGridsTarjetas(int clienteID)
        {
            Controllers.TarjetaController controller = new Controllers.TarjetaController();

            IList<Tarjeta> tarjetas = controller.Get_Tarjetas(clienteID);

            gvTarjetas.DataSource = tarjetas;
            gvTarjetas.DataBind();

            lblTarjetas.Text = gvTarjetas.Rows.Count.ToString();

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

        private void Buscar(int clienteid)
        {
            Cliente = null;

            lblMensaje.Visible = false;

            Controllers.ClienteController controller = new Controllers.ClienteController();

            Cliente = controller.ObtenerCliente(clienteid);

            if (Cliente == null)
            {

                lblMensaje.Text = "No se encontro ningun cliente con este nombre que contenga datos";
                lblMensaje.Visible = true;
                return;
            }

            txtDireccion.Text = Cliente.Direccion;
            txtMail.Text = Cliente.Email;
            txtNombre.Text = Cliente.Descripcion;
            txtRif.Text = Cliente.RIF;
            txtTelefono.Text = Cliente.Telefono;
            txtID.Text = Convert.ToString(Cliente.ClienteID);
           
          
            BindGrids();
            BindGridsTarjetas(Cliente.ClienteID);

        }
        private void BuscarTarjeta(string numero)
        {
            Cliente = null;

            lblTarjetas.Visible = false;

            Controllers.ClienteController controller = new Controllers.ClienteController();
            Controllers.TarjetaController controllerTarjeta = new Controllers.TarjetaController();
            Tarjeta tarjeta = new Tarjeta();
            tarjeta = controllerTarjeta.ObtenerTarjeta(numero);


            if (tarjeta == null)
            {

               // lblTarjetas.Text = "No se encontro ningun cliente con este nombre que contenga datos";
                lblTarjetas.Visible = true;
                return;
            }
            txtNumero.Text = tarjeta.Numero;
            txtClienteID.Text = tarjeta.ClienteID.ToString();

            BindGridsTarjetas(tarjeta.ClienteID);

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Buscar(int.Parse(((HiddenField)((LinkButton)sender).FindControl("hfClienteID")).Value.ToString()));

        }

        protected void btnEditarTarjeta_Click(object sender, EventArgs e)
        {
            BuscarTarjeta(((HiddenField)((LinkButton)sender).FindControl("hfNumero")).Value.ToString());

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Controllers.ClienteController controller = new Controllers.ClienteController();

            Cliente cliente = new Cliente();

            cliente.Descripcion = txtNombre.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.Direccion = txtDireccion.Text;
            cliente.Email = txtMail.Text;
            cliente.RIF = txtRif.Text;
            cliente.ClienteID = int.Parse(txtID.Text);
            Controllers.ControllerResult result = controller.ActualizarCliente(cliente, UsuarioAutenticado.UserName);

            if (result.Resultado == Controllers.Result.Successful)

                txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtMail.Text = string.Empty;
            txtRif.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            BindGrids();
            Alert(result.Mensaje);
        }

        protected void btnGuardarTarjeta_Click(object sender, EventArgs e)
        {
            Controllers.TarjetaController controller = new Controllers.TarjetaController();

            Tarjeta tarjeta = new Tarjeta();

            tarjeta.ClienteID = int.Parse(txtClienteID.Text);
            tarjeta.Numero = txtNumero.Text;

            Controllers.ControllerResult result = controller.ActualizarTarjeta(tarjeta, UsuarioAutenticado.UserName);

            if (result.Resultado == Controllers.Result.Successful)


                txtNumero.Text = string.Empty;

            BindGridsTarjetas(tarjeta.ClienteID);
            Alert(result.Mensaje);
        }

        protected void btnCrearTarjeta_Click(object sender, EventArgs e)
        {
            Controllers.TarjetaController controller = new Controllers.TarjetaController();

            Tarjeta tarjeta = new Tarjeta();

            tarjeta.ClienteID = int.Parse(txtClienteID.Text);
            tarjeta.Numero = txtNumero.Text;
            
            Controllers.ControllerResult result = controller.CrearTarjeta(tarjeta, UsuarioAutenticado.UserName);

            if (result.Resultado == Controllers.Result.Successful)

               
            txtNumero.Text = string.Empty;

            BindGridsTarjetas(tarjeta.ClienteID);
            Alert(result.Mensaje);
        }
    }
}
