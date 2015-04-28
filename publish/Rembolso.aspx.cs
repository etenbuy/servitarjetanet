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
using System.IO;
using System.Collections.Generic;


namespace Web
{
    public partial class Rembolso : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                //txtUsuario.Focus();
                
            }

        }

       


        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Controllers.SolicitudController controller = new Controllers.SolicitudController();

            Controllers.ClienteController controllerCliente = new Controllers.ClienteController();

            Solicitud solicitud = new Solicitud();

            Cliente cliente = controllerCliente.Get_IdMailClient(txtCorreo.Text);

            if (cliente.ClienteID == 0)
            {
                Alert("El correo sumistrado no esta registrado en nuestro sistema, por favor coloque el correo asignado a su usuario");
            }
            else {
                Solicitud solicitudID = controller.Get_IDClient(cliente.LoginCreado);

                solicitud.StatusSolicitudID = 1;

                //solicitud.SolicitudTipoID = int.Parse(ddlServicio.SelectedValue);

                solicitud.ClienteID = cliente.ClienteID;


                IList<Solicitud> solicitudes = controller.SolicitudesAlMes_Get_ByClient(cliente.LoginCreado);

                if (solicitudes.Count == 1)
                {
                    
                }
                if (solicitudes.Count == 2)
                {
                 
                    lblMensaje.Text = "Maximo de Ticket Utilizado por este Mes";

                }
                if (solicitudes.Count == 3)
                {
           
                    lblMensaje.Text = "Maximo de Ticket Utilizado por este Mes";
                }
                if (solicitudes.Count == 4)
                {
                  
                    lblMensaje.Text = "Maximo de Ticket Utilizado por este Mes";

                }
                if (solicitudes.Count == 5)
                {
                   
                    lblMensaje.Text = "Maximo de Ticket Utilizado por este Mes";

                }

                if (solicitudes.Count == 0 || solicitudes.Count == 1)
                {
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

                    Controllers.ControllerResult result = controller.CrearSolicitud(solicitud, cliente.LoginCreado, fullPath, fullPathrecibo);

                    if (result.Resultado == Controllers.Result.Successful)

                        txtCorreo.Text = string.Empty;
                    txtNota.Text = string.Empty;
                    txtMonto.Text = string.Empty;
                    // SolicitudesPorMes();
                    Alert(result.Mensaje);
                }


            }


        }

        private void SolicitudesPorMes()
        {
            Controllers.SolicitudController controller = new Controllers.SolicitudController();

            IList<Solicitud> solicitudes = controller.SolicitudesAlMes_Get_ByClient(UsuarioAutenticado.UserName);

            if (solicitudes.Count == 1)
            {
                Panel2.Enabled = true;
            }
            if (solicitudes.Count == 2)
            {
                FileUploadFactura.Enabled = false;
                FileUploadRecibo.Enabled = false;
                Panel2.Enabled = false;
                lblMensaje.Text = "Maximo de Ticket Utilizado por este Mes";

            }
            if (solicitudes.Count == 3)
            {
                FileUploadFactura.Enabled = false;
                FileUploadRecibo.Enabled = false;
                Panel2.Enabled = false;
                lblMensaje.Text = "Maximo de Ticket Utilizado por este Mes";
            }
            if (solicitudes.Count == 4)
            {
                FileUploadFactura.Enabled = false;
                FileUploadRecibo.Enabled = false;
                Panel2.Enabled = false;
                lblMensaje.Text = "Maximo de Ticket Utilizado por este Mes";

            }
            if (solicitudes.Count == 5)
            {
                FileUploadFactura.Enabled = false;
                FileUploadRecibo.Enabled = false;
                Panel2.Enabled = false;
                lblMensaje.Text = "Maximo de Ticket Utilizado por este Mes";

            }

            if (solicitudes.Count == 0)
            {
                FileUploadFactura.Enabled = true;
                FileUploadRecibo.Enabled = true;
                Panel2.Enabled = true;
                lblMensaje.Text = "";
                
            }

        }

        protected void txtMonto_TextChanged(object sender, EventArgs e)
        {
            string monto = txtMonto.Text;
            monto = "";
        }

    }
}
