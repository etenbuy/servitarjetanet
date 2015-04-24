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

                SolicitudesPorMes();
            }
        }

        private void SolicitudesPorMes()
        {
            Controllers.SolicitudController controller = new Controllers.SolicitudController();

            IList<Solicitud> solicitudes = controller.SolicitudesAlMes_Get_ByClient(UsuarioAutenticado.UserName);

            if (solicitudes.Count == 1)
            {
                primer_ticket.Enabled = true;
                FileUploadFactura.Enabled = true;
                FileUploadRecibo.Enabled = true;
                
                
            }
            if (solicitudes.Count == 2)
            {
                FileUploadFactura.Enabled = false;
                FileUploadRecibo.Enabled = false;
                primer_ticket.Enabled = false;
                lblMensaje.Text = "Ticket Utilizado";
                
            }
            if (solicitudes.Count == 3)
            {
                FileUploadFactura.Enabled = false;
                FileUploadRecibo.Enabled = false;
               
                primer_ticket.Enabled = false;
              
                lblMensaje.Text = "Ticket Utilizado";
               
            }
            if (solicitudes.Count == 4)
            {
                FileUploadFactura.Enabled = false;
                FileUploadRecibo.Enabled = false;
              
                primer_ticket.Enabled = false;
               
                lblMensaje.Text = "Ticket Utilizado";
                
            }
            if (solicitudes.Count == 5)
            {
                FileUploadFactura.Enabled = false;
                FileUploadRecibo.Enabled = false;
                
                primer_ticket.Enabled = false;
               
                lblMensaje.Text = "Ticket Utilizado";
                
            }

            if (solicitudes.Count == 0)
            {
                FileUploadFactura.Enabled = true;
                FileUploadRecibo.Enabled = true;
               
                primer_ticket.Enabled = true;
                
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

            solicitud.Monto = decimal.Parse(txtMonto.Text);

            solicitud.Nota = txtNota.Text;

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



                txtNota.Text = string.Empty;
                txtMonto.Text = string.Empty;
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
