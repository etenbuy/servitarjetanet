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

namespace Web.Configuracion.Pagos
{
    public partial class Editar : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!Page.IsPostBack)
            {
                cargarTipo();
                BindClientes();
           
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

        private void builTotales()
        {
            Controllers.SolicitudController controller = new Controllers.SolicitudController();
            Solicitud solicitud = new Solicitud();
            // solicitud = controller.SolicitudesTotales_Get_ByClient(UsuarioAutenticado.UserName, ddlTarjetas.SelectedItem.Text);
            solicitud = controller.SolicitudesTotalesTarjeta_Get_ByClient(UsuarioAutenticado.UserName, ddlTarjetas.SelectedItem.Text);

            if (solicitud.Saldo != null)
            {
                txtMontoPagado.Text = string.Format("{0:###,###,###,###.00}", solicitud.Saldo);
            }
            else
            {
                txtMontoPagado.Text = "0";
            }




        }

        protected void gvSolicitudes_OnCheckedChanged(object sender, EventArgs e)
        {

            txtMontoPagado.Text = "0";
            var rows = gvSolicitudes.Rows;
            int count = gvSolicitudes.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                bool isChecked = ((CheckBox)rows[i].FindControl("SelectCheckBox")).Checked;
                if (isChecked)
                {
                    txtMontoPagado.Text = Convert.ToString(Convert.ToDecimal(txtMontoPagado.Text) + Convert.ToDecimal(rows[i].Cells[5].Text));
                }
            }

            
           
        }

        protected void BindClientes()
        {

            Controllers.SolicitudController controller = new Controllers.SolicitudController();
            gvClientes.DataSource = controller.GetClientesTotalesByClient();
            gvClientes.DataBind();

            lblClientes.Text = gvClientes.Rows.Count.ToString();


        }
        protected void BindGrids()
        {           

            Controllers.SolicitudController controller = new Controllers.SolicitudController();

            gvSolicitudes.DataSource = controller.Solicitudes_TarjetaPagadasGet_ByClient(txtLoginCreado.Text, ddlTarjetas.SelectedItem.Text);
            gvSolicitudes.DataBind();
           
        
            lblTotalSolicitudes.Text = gvSolicitudes.Rows.Count.ToString();


        }
        protected void gvSolicitudes_DataBound(object sender, EventArgs e)
        {


        }
        protected void gvSolicitudes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void gvSolicitudes_Sorting(object sender, GridViewSortEventArgs e)
        {


        }

        private void Buscar(int SolicitudID)
        {
            

            lblMensaje.Visible = false;

            Controllers.SolicitudController controller = new Controllers.SolicitudController();

            IList<Solicitud> solicitudes = controller.Solicitudes_Get_ByClientSolicitudID(SolicitudID);

            

            if (solicitudes == null)
            {
                lblMensaje.Text = "No se encontro ninguna solicitud con este numero que contenga datos";
                lblMensaje.Visible = true;
                return;
            }
            else
            {
                 for (int i = 0; i < solicitudes.Count; ++i)
                    {
                        
                       txtSolicitudID.Text = solicitudes[i].SolicitudID.ToString();
                       txtFactura.Text = solicitudes[i].Numero_Factura;
                       txtMontoFactura.Text = solicitudes[i].Monto.ToString();
                       txtMontoPagado.Text = solicitudes[i].Monto_Pagado.ToString();
                       

                    }
                
            }

         /*   Ticket ticket = new Ticket();
            Controllers.TicketController controllerticket = new Controllers.TicketController();

            ticket = controllerticket.GetTicketMontoMensual_Porcentaje();
            txtMontoPagado.Text = Convert.ToString(decimal.Parse(txtMontoFactura.Text));
*/

            BindGrids();

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Buscar(int.Parse(((HiddenField)((LinkButton)sender).FindControl("hfSolicitudID")).Value.ToString()));


        }
        protected void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            txtLoginCreado.Text = ((HiddenField)((LinkButton)sender).FindControl("hfLoginCreado")).Value.ToString();
            BuildTarjetas();
            ddlTarjetas_SelectedIndexChanged(null, null);
            
           
          
        }
        private void BuildTarjetas()
        {


            Controllers.ClienteController controllerCliente = new Controllers.ClienteController();

            Cliente cliente = new Cliente();
            cliente = controllerCliente.ObtenerCliente(txtLoginCreado.Text);

            Controllers.TarjetaController controllerTarjeta = new Controllers.TarjetaController();
            ddlTarjetas.DataSource = controllerTarjeta.Get_Tarjetas(cliente.ClienteID);

            ddlTarjetas.DataTextField = "Numero";
            ddlTarjetas.DataValueField = "Id";
            ddlTarjetas.DataBind();

            ddlTarjetas.Items.Insert(0, new ListItem("Seleccionar...", ""));
        }
        protected void cargarTipo()
        {
            Controllers.TipoController controller = new Controllers.TipoController();

            ddlTipo.DataSource = controller.Get_Tipos();
            ddlTipo.DataTextField = "Definicion";
            ddlTipo.DataValueField = "Valor";
            ddlTipo.DataBind();
        }
      

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Controllers.SolicitudController controller = new Controllers.SolicitudController();
            
            Solicitud solicitud = new Solicitud();
            solicitud.FechaPagado =  txtFechaPago.Text.ToString().Substring(0, 10);
            solicitud.Ntdc = txtTDC.Text;
            solicitud.Ndeposito = txtdeposito.Text;
           // solicitud.Monto_Factura = decimal.Parse(txtMontoFactura.Text);
            solicitud.Numero_Factura = txtFactura.Text;
            solicitud.Monto_Pagado = decimal.Parse(txtMontoPagado.Text);
           // solicitud.SolicitudID = int.Parse(txtSolicitudID.Text);
           // solicitud.StatusSolicitudID = int.Parse(ddlTipo.SelectedValue);
            solicitud.SolicitudTipoID = int.Parse(ddlTipo.SelectedValue);
            solicitud.LoginCreado = txtLoginCreado.Text;
            solicitud.Factura = "";
           // solicitud.Monto = decimal.Parse(txtMontoFactura.Text);
            solicitud.Numero_TDC = ddlTarjetas.SelectedItem.Text;

            var rows = gvSolicitudes.Rows;
            int count = gvSolicitudes.Rows.Count;
            Solicitud solicitudUpdate = new Solicitud();

            for (int i = 0; i < count; i++)
            {
                if (ddlTipo.SelectedItem.Text == "Solicitud Rechazada")
                {
                    bool isChecked = ((CheckBox)rows[i].FindControl("SelectCheckBox")).Checked;
                    if (isChecked)
                    {
                        solicitudUpdate.SolicitudID = int.Parse(rows[i].Cells[0].Text);
                        solicitudUpdate.StatusSolicitudID = 3;
                        solicitudUpdate.Descripcion = solicitudUpdate.Descripcion + " " +  solicitudUpdate.SolicitudID;
                        Controllers.ControllerResult resultupdate = controller.ActualizarStatusSolicitud(solicitudUpdate, UsuarioAutenticado.UserName);

                    }
                
                }
                if (ddlTipo.SelectedItem.Text == "Pago de Solicitud")
                {
                    bool isChecked = ((CheckBox)rows[i].FindControl("SelectCheckBox")).Checked;
                    if (isChecked)
                    {
                        solicitudUpdate.SolicitudID = int.Parse(rows[i].Cells[0].Text);
                        solicitudUpdate.StatusSolicitudID = 2;
                        solicitudUpdate.Descripcion = solicitudUpdate.Descripcion + " " + solicitudUpdate.SolicitudID;
                        Controllers.ControllerResult resultupdate = controller.ActualizarStatusSolicitud(solicitudUpdate, UsuarioAutenticado.UserName);

                    }

                }
               
            }
           
             if(solicitud.SolicitudTipoID == 2)
            {
                solicitud.Descripcion = "PAGO A CLIENTE Nro. " + solicitudUpdate.Descripcion; 
            }
             if(solicitud.SolicitudTipoID == 3)
            {
                solicitud.Descripcion = "SOLICITUD RECHAZADA Nro. " + solicitudUpdate.Descripcion; 
            }
            
            

            Controllers.ControllerResult result = controller.CrearSolicitud(solicitud, UsuarioAutenticado.UserName,"","");

           // Controllers.ControllerResult result = controller.ActualizarSolicitud(solicitud, UsuarioAutenticado.UserName);

            if (result.Resultado == Controllers.Result.Successful)
               txtSolicitudID.Text = string.Empty;
            txtFactura.Text = string.Empty;
            txtMontoFactura.Text = string.Empty;
            txtMontoPagado.Text = string.Empty;
            BindGrids();
            builTotales();
            BindClientes();
            Alert(result.Mensaje);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BuildTarjetas();

        }

        protected void ddlTarjetas_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrids();
            builTotales();
        }
        protected void CheckGridMesAno()
        {

            Controllers.SolicitudController controller = new Controllers.SolicitudController();
            IList<Solicitud> solicitudes = new List<Solicitud>();
            solicitudes = controller.Solicitudes_Mes_Ano(txtLoginCreado.Text, ddlTarjetas.SelectedItem.Text, ddlMes.SelectedItem.Text, ddlAno.SelectedItem.Text);

            
            var rows = gvSolicitudes.Rows;
            int count = gvSolicitudes.Rows.Count;
            Solicitud solicitudUpdate = new Solicitud();

          

            foreach(Solicitud solicitud in solicitudes)
            {
               
            for (int i = 0; i < count; i++)
            {
                  CheckBox ChkBox = ((CheckBox)rows[i].FindControl("SelectCheckBox"));

                  if (rows[i].Cells[0].Text == solicitud.SolicitudID.ToString())
                  {
                      ChkBox.Checked = true;
                  }
                 
                }
            }
           

        }
        protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckGridMesAno();
        }

       

        protected void ddlAno_SelectedIndexChanged1(object sender, EventArgs e)
        {
            CheckGridMesAno();
        }
    }
}
