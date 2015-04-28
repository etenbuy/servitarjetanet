﻿using System;
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
                BindGrids();
                cargarStatus();
                
           
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

            Controllers.SolicitudController controller = new Controllers.SolicitudController();

            gvSolicitudes.DataSource = controller.Solicitudes_Get_ByClient(txtLoginCreado.Text);
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
                       txtFactura.Text = solicitudes[i].Factura;
                       txtMontoFactura.Text = solicitudes[i].Monto.ToString();
                       

                    }
                
            }

            Ticket ticket = new Ticket();
            Controllers.TicketController controllerticket = new Controllers.TicketController();
            ticket = controllerticket.GetTicketMonto(txtMontoFactura.Text);
            txtMontoPagado.Text = ticket.Monto_Pagar.ToString();

            BindGrids();

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Buscar(int.Parse(((HiddenField)((LinkButton)sender).FindControl("hfSolicitudID")).Value.ToString()));


        }

        protected void cargarStatus()
        {
            Controllers.StatusController controller = new Controllers.StatusController();

            ddlEstado.DataSource = controller.Get_Status();
            ddlEstado.DataTextField = "Descripcion";
            ddlEstado.DataValueField = "StatusID";
            ddlEstado.DataBind();
        }
      

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Controllers.SolicitudController controller = new Controllers.SolicitudController();
            
            Solicitud solicitud = new Solicitud();
            solicitud.FechaPagado =  Convert.ToDateTime(txtFechaPago.Text);
            //solicitud.FechaPagado = DateTime.ParseExact(txtFechaPago.Text, "dd/MM/yyyy", null);
            solicitud.Ntdc = txtTDC.Text;
            solicitud.Ndeposito = txtdeposito.Text;
            solicitud.Monto_Factura = decimal.Parse(txtMontoFactura.Text);
            solicitud.Numero_Factura = txtFactura.Text;
            solicitud.Monto_Pagado = decimal.Parse(txtMontoPagado.Text);
            solicitud.SolicitudID = int.Parse(txtSolicitudID.Text);
            solicitud.StatusSolicitudID = int.Parse(ddlEstado.SelectedValue);

            Controllers.ControllerResult result = controller.ActualizarSolicitud(solicitud, UsuarioAutenticado.UserName);

            if (result.Resultado == Controllers.Result.Successful)
               txtSolicitudID.Text = string.Empty;
            txtFactura.Text = string.Empty;
            txtMontoFactura.Text = string.Empty;
            txtMontoPagado.Text = string.Empty;
            BindGrids();
            Alert(result.Mensaje);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Controllers.SolicitudController controller = new Controllers.SolicitudController();

            gvSolicitudes.DataSource = controller.Solicitudes_Get_ByClient(txtLoginCreado.Text);
            gvSolicitudes.DataBind();

           


            lblTotalSolicitudes.Text = gvSolicitudes.Rows.Count.ToString();
        }
    }
}