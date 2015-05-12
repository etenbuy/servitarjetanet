using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using BusinessObjects;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text;



namespace Web.Operaciones.Clientes
{
    public partial class EstadosCuenta : PageBase
    {

          protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
              
                BuildTarjetas();
               
                //builTotales();
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
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            BuildSolicitudes();

        }

        private void BuildSolicitudes()
        {
            Controllers.SolicitudController controller = new Controllers.SolicitudController();


            DataTable dtSolicitudes = CollectionHelper.ConvertTo<Solicitud>(controller.Solicitudes_EstadoCuentaGet_ByClient(UsuarioAutenticado.UserName, ddlTarjetas.SelectedItem.Text, ddlMes.SelectedItem.Text, ddlAno.SelectedItem.Text));

            Session["DSSolicitudes"] = dtSolicitudes;

            gvSolicitudes.DataSource = controller.Solicitudes_EstadoCuentaGet_ByClient(UsuarioAutenticado.UserName, ddlTarjetas.SelectedItem.Text, ddlMes.SelectedItem.Text, ddlAno.SelectedItem.Text);
            gvSolicitudes.DataBind();

            foreach (GridViewRow row in gvSolicitudes.Rows)
            {
                if (row.Cells[1].Text == "PAGO A CLIENTE")
                {
                    row.Cells[1].ForeColor = Color.Blue;
                    row.Cells[1].Font.Bold = true;
                }
                if (row.Cells[1].Text == "SOLICITUD RECHAZADA")
                {
                    row.Cells[1].ForeColor = Color.Red;
                    row.Cells[1].Font.Bold = true;
                }

            }
        }
   
    }

}
