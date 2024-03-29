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
using System.IO;
using Controllers;

namespace Web.Operaciones.Clientes
{
    public partial class CrearSolicitud : PageBase
    {



        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                BuildTarjetas();
                SolicitudesPorMes();
            }
        }

        private void BuildTarjetas()
        {
            Controllers.ClienteController controllerCliente = new Controllers.ClienteController();

            Cliente cliente = new Cliente();
            cliente = controllerCliente.ObtenerCliente(UsuarioAutenticado.UserName);

            Controllers.TarjetaController controllerTarjeta = new Controllers.TarjetaController();
            ddlTarjetas.DataSource = controllerTarjeta.Get_Tarjetas(cliente.ClienteID);

            ddlTarjetas.DataTextField = "Numero";
            ddlTarjetas.DataValueField = "Id";
            ddlTarjetas.DataBind();

            ddlTarjetas.Items.Insert(0, new ListItem("Seleccionar...", ""));
        }
                
        private void SolicitudesPorMes()
        {
            Controllers.SolicitudController controller = new Controllers.SolicitudController();
            Controllers.TicketController controllerTicket = new Controllers.TicketController();
            Solicitud solicitudes = controller.GetSolicitudesByClientMontoFactura(UsuarioAutenticado.UserName, ddlTarjetas.SelectedItem.Text);

            Ticket ticket =  controllerTicket.GetTicketMontoMensual_Porcentaje();
            

            if (solicitudes.Monto > ticket.Monto_Mensual)
            {
                FileUploadFactura.Enabled = false;
                FileUploadRecibo.Enabled = false;
                primer_ticket.Enabled = false;
                lblMensaje.Text = "Monto maximo en factura mensual alcanzado";
            }
            else
            {
                primer_ticket.Enabled = true;
                FileUploadFactura.Enabled = true;
                FileUploadRecibo.Enabled = true;
                lblMensaje.Text = "";
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

            solicitud.Numero_Factura = txtNumeroFactura.Text;
            solicitud.Monto = decimal.Parse(txtMonto.Text);
            solicitud.Monto_Pagado = decimal.Parse(lblMontoPagar.Text);
            solicitud.SolicitudTipoID = 1;
            solicitud.Numero_TDC = ddlTarjetas.SelectedItem.Text;
            

            string fullPath = "";
            string fullPathrecibo = "";
            solicitud.Factura = "";

            if (FileUploadFactura.HasFile)
            {
                fullPath = Path.Combine(Server.MapPath("~/files"), FileUploadFactura.FileName);
                FileUploadFactura.SaveAs(fullPath);
            }
             if (FileUploadRecibo.HasFile)
            {
                fullPathrecibo = Path.Combine(Server.MapPath("~/files"), FileUploadRecibo.FileName);
                FileUploadRecibo.SaveAs(fullPathrecibo);
            }

             if (FileUploadFactura.FileName == null)
             {
                 solicitud.Factura_1 = "";
                
             }
             else
             {
                 solicitud.Factura_1 = FileUploadFactura.FileName;
             }
             if (FileUploadRecibo.FileName == null)
             {
                 solicitud.Recibo_1 = "";
                 
             }
             else
             {
                 solicitud.Recibo_1 = FileUploadRecibo.FileName;
             }


             Controllers.ControllerResult result = controller.CrearSolicitud(solicitud, UsuarioAutenticado.UserName,fullPath, fullPathrecibo);


             if (result.Resultado == Controllers.Result.Successful)



                txtNumeroFactura.Text = string.Empty;
                txtMonto.Text = string.Empty;
                lblMontoPagar.Text = string.Empty;
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

        protected void txtMonto_TextChanged(object sender, EventArgs e)
        {
            Ticket ticket = new Ticket();
            Controllers.TicketController controller = new Controllers.TicketController();
            ticket = controller.GetTicketMontoMensual_Porcentaje();
            lblMontoPagar.Text = Convert.ToString(decimal.Parse(txtMonto.Text) * ticket.Porcentaje / 100);
            
        }

        protected void ddlTarjetas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
