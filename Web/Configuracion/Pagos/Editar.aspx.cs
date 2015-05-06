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
                cargarTipo();
                
           
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
            solicitud.Monto_Factura = decimal.Parse(txtMontoFactura.Text);
            solicitud.Numero_Factura = txtFactura.Text;
            solicitud.Monto_Pagado = decimal.Parse(txtMontoPagado.Text);
            solicitud.SolicitudID = int.Parse(txtSolicitudID.Text);
           // solicitud.StatusSolicitudID = int.Parse(ddlTipo.SelectedValue);
            solicitud.SolicitudTipoID = int.Parse(ddlTipo.SelectedValue);
            solicitud.LoginCreado = txtLoginCreado.Text;
            solicitud.Factura = "";
            solicitud.Monto = decimal.Parse(txtMontoFactura.Text);

            Controllers.ControllerResult result = controller.CrearSolicitud(solicitud, UsuarioAutenticado.UserName,"","");

           // Controllers.ControllerResult result = controller.ActualizarSolicitud(solicitud, UsuarioAutenticado.UserName);

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
