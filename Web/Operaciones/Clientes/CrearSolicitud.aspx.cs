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

namespace Web.Operaciones.Clientes
{
    public partial class CrearSolicitud : PageBase
    {



        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {

                SolicitudesPorMes();
            }
        }

        private void SolicitudesPorMes()
        {
            Controllers.SolicitudController controller = new Controllers.SolicitudController();

            IList<Solicitud> solicitudes = controller.SolicitudesAlMes_Get_ByClient("juan.delgado");

            if (solicitudes.Count == 1)
            {
                primer_ticket.Enabled = false;
                FileUploadFactura.Enabled = false;
                FileUploadRecibo.Enabled = false;
                lblMensaje.Text = "Ticket Utilizado";
                
            }
            if (solicitudes.Count == 2)
            {
                FileUploadFactura.Enabled = false;
                FileUploadRecibo.Enabled = false;
                FileUploadFactura2.Enabled = false;
                FileUploadRecibo2.Enabled = false;
                primer_ticket.Enabled = false;
                segundo_ticket.Enabled = false;
                lblMensaje.Text = "Ticket Utilizado";
                lblMensaje2.Text = "Ticket Utilizado";
            }
            if (solicitudes.Count == 3)
            {
                FileUploadFactura.Enabled = false;
                FileUploadRecibo.Enabled = false;
                FileUploadFactura2.Enabled = false;
                FileUploadRecibo2.Enabled = false;
                primer_ticket.Enabled = false;
                segundo_ticket.Enabled = false;
                lblMensaje.Text = "Ticket Utilizado";
                lblMensaje2.Text = "Ticket Utilizado";
            }
            if (solicitudes.Count == 4)
            {
                FileUploadFactura.Enabled = false;
                FileUploadRecibo.Enabled = false;
                FileUploadFactura2.Enabled = false;
                FileUploadRecibo2.Enabled = false;
                primer_ticket.Enabled = false;
                segundo_ticket.Enabled = false;
                lblMensaje.Text = "Ticket Utilizado";
                lblMensaje2.Text = "Ticket Utilizado";
            }
            if (solicitudes.Count == 5)
            {
                FileUploadFactura.Enabled = false;
                FileUploadRecibo.Enabled = false;
                FileUploadFactura2.Enabled = false;
                FileUploadRecibo2.Enabled = false;
                primer_ticket.Enabled = false;
                segundo_ticket.Enabled = false;
                lblMensaje.Text = "Ticket Utilizado";
                lblMensaje2.Text = "Ticket Utilizado";
            }

            if (solicitudes.Count == 0)
            {
                FileUploadFactura.Enabled = true;
                FileUploadRecibo.Enabled = true;
                FileUploadFactura2.Enabled = true;
                FileUploadRecibo2.Enabled = true;
                primer_ticket.Enabled = true;
                segundo_ticket.Enabled = true;
                lblMensaje.Text = "";
                lblMensaje2.Text = "";
            }

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {

            Controllers.SolicitudController controller = new Controllers.SolicitudController();

            Solicitud solicitud = new Solicitud();

            Solicitud solicitudID = controller.Get_IDClient(UsuarioAutenticado.UserName);

            solicitud.StatusSolicitudID = 1;

            //solicitud.SolicitudTipoID = int.Parse(ddlServicio.SelectedValue);

            solicitud.ClienteID = solicitudID.ClienteID;

            solicitud.Monto = decimal.Parse(txtMonto.Text);

            solicitud.Nota = txtNota.Text;

            Controllers.ControllerResult result = controller.CrearSolicitud(solicitud, UsuarioAutenticado.UserName);

            if (result.Resultado == Controllers.Result.Successful)

                txtNota.Text = string.Empty;
                txtMonto.Text = string.Empty;
                SolicitudesPorMes();
            
            Alert(result.Mensaje);


        }
        protected void btnCrear2_Click(object sender, EventArgs e)
        {

            Controllers.SolicitudController controller = new Controllers.SolicitudController();

            Solicitud solicitud = new Solicitud();

            Solicitud solicitudID = controller.Get_IDClient(UsuarioAutenticado.UserName);

            solicitud.StatusSolicitudID = 1;

            //solicitud.SolicitudTipoID = int.Parse(ddlServicio.SelectedValue);

            solicitud.ClienteID = solicitudID.ClienteID;

            solicitud.Monto = decimal.Parse(txtMonto2.Text);

            solicitud.Nota = txtNota2.Text;

            Controllers.ControllerResult result = controller.CrearSolicitud(solicitud, UsuarioAutenticado.UserName);

            if (result.Resultado == Controllers.Result.Successful)

                txtNota2.Text = string.Empty;
                txtMonto2.Text = string.Empty;
                SolicitudesPorMes();
            
            Alert(result.Mensaje);


        }

        

        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {


        }


    }
}
