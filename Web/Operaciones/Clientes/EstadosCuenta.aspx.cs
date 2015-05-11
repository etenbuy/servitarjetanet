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


namespace Web.Operaciones.Clientes
{
    public partial class EstadosCuenta : System.Web.UI.Page
    {
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
           

        }

        private void BuildSolicitudes()
        {
            Controllers.SolicitudController controller = new Controllers.SolicitudController();


            DataTable dtSolicitudes = CollectionHelper.ConvertTo<Solicitud>(controller.Solicitudes_TarjetaGet_ByClient(UsuarioAutenticado.UserName, ddlTarjetas.SelectedItem.Text));

            Session["DSSolicitudes"] = dtSolicitudes;

            gvSolicitudes.DataSource = controller.Solicitudes_TarjetaGet_ByClient(UsuarioAutenticado.UserName, ddlTarjetas.SelectedItem.Text);
            gvSolicitudes.DataBind();

            foreach (GridViewRow row in gvSolicitudes.Rows)
            {
                if (row.Cells[2].Text == "PAGO A CLIENTE")
                {
                    row.Cells[2].ForeColor = Color.Blue;
                    row.Cells[2].Font.Bold = true;
                }
                if (row.Cells[2].Text == "SOLICITUD RECHAZADA")
                {
                    row.Cells[2].ForeColor = Color.Red;
                    row.Cells[2].Font.Bold = true;
                }

            }
        }
   
    }

}
