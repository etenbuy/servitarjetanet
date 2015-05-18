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
using System.IO;
using Controllers;

namespace Web.Configuracion.Clientes
{
    public partial class CrearSolicitud : PageBase
    {



        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                BuildClientes();
               
                
            }
        }

        private void BuildClientes()
        {
            Controllers.ClienteController controllerCliente = new Controllers.ClienteController();

   
            ddlCliente.DataSource = controllerCliente.GetClientes();
            ddlCliente.DataTextField = "LoginCreado";
            ddlCliente.DataValueField = "ClienteID";
            ddlCliente.DataBind();

            ddlCliente.Items.Insert(0, new ListItem("Seleccionar...", ""));
        }

        private void BuildTarjetas()
        {
            Controllers.ClienteController controllerCliente = new Controllers.ClienteController();

            Cliente cliente = new Cliente();
            cliente = controllerCliente.ObtenerCliente(ddlCliente.SelectedItem.Text);

            Controllers.TarjetaController controllerTarjeta = new Controllers.TarjetaController();
            ddlTarjetas.DataSource = controllerTarjeta.Get_Tarjetas(cliente.ClienteID);

            ddlTarjetas.DataTextField = "Numero";
            ddlTarjetas.DataValueField = "Id";
            ddlTarjetas.DataBind();

            ddlTarjetas.Items.Insert(0, new ListItem("Seleccionar...", ""));
        }
                
       

      

        protected void btnCrear_Click(object sender, EventArgs e)
        {

            Controllers.SolicitudController controller = new Controllers.SolicitudController();

            Solicitud solicitud = new Solicitud();

            Solicitud solicitudID = controller.Get_IDClient(ddlCliente.Text);

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


             Controllers.ControllerResult result = controller.CrearSolicitud(solicitud, ddlCliente.Text, fullPath, fullPathrecibo);


             if (result.Resultado == Controllers.Result.Successful)



                txtNumeroFactura.Text = string.Empty;
                txtMonto.Text = string.Empty;
                lblMontoPagar.Text = string.Empty;
               
            
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

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildTarjetas();
        }
        protected void ddlTarjetas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
